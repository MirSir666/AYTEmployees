using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Microsoft.Maui.Devices.Sensors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AYTEmployees.Manage.TTS.WebSocketHelper;

namespace AYTEmployees.Blazor
{
    public interface IBasePage
    {
        void Logout();
        void Home();
        void Goto(string url);
        void Alert(string message, string title = null);
        Task AsyncAlert(string message, string title = null);

        void BeginInvokeOnMainThread(Action action);
        ValueTask JavaScriptRunAsync(string identifier, params object?[]? args);

        void UIJavaScriptRunAsync(string identifier, params object?[]? args);

        Task<Location> GetCurrentLocation();

    }
    public class BasePage: IBasePage
    {
        private readonly NavigationManager navigationManager;
        private readonly RoutesState routesState;
        private readonly IJSRuntime jSRuntime;

        public BasePage(NavigationManager navigationManager, RoutesState routesState , IJSRuntime  jSRuntime) {
            this.navigationManager = navigationManager;
            this.routesState = routesState;
            this.jSRuntime = jSRuntime;
        }

        public void Home()
        {
            routesState.SetVal(true);
            Goto("workbenches");
        }

        public void Logout()
        {
            routesState.SetVal(false);

        }

        public void Goto(string url)
        {
            navigationManager.NavigateTo(url);
        }

        public void GoBack()
        {
        }


        public async void Alert(string message, string title = null)
        {

            await AsyncAlert(message,title);
        }

        public Task AsyncAlert(string message, string title = null)
        {
            //MainThread.BeginInvokeOnMainThread(() => {
            //    jSRuntime.InvokeVoidAsync("alert", message, title);
            //});

            UIJavaScriptRunAsync("alert", message, title);
            return Task.CompletedTask;
        }

        public ValueTask JavaScriptRunAsync(string identifier, params object?[]? args)
        {
           return jSRuntime.InvokeVoidAsync(identifier,args);
        }

        public void UIJavaScriptRunAsync(string identifier, params object?[]? args)
        {
            MainThread.BeginInvokeOnMainThread(() => {
                jSRuntime.InvokeVoidAsync(identifier, args);
            });
        }

        public void BeginInvokeOnMainThread(Action action)
        {
             MainThread.BeginInvokeOnMainThread(action);
        }

        private CancellationTokenSource _cancelTokenSource;
        private bool _isCheckingLocation;
        /// <summary>
        /// 获取当前位置
        /// 虽然检查设备 的最后已知位置 可能更快，但它可能不准确。
        /// 使用该方法 GetLocationAsync 查询设备的当前位置。
        /// 可以配置查询的准确性和超时。
        /// 最好是使用 GeolocationRequest 和 CancellationToken 参数的方法重载，
        /// 因为可能需要一些时间才能获取设备的位置。
        /// </summary>
        /// <returns></returns>
        public  async Task<Location> GetCurrentLocation()
        {
            await CheckPermissionsLocation();
            Location location = null;
            try
            {
                _isCheckingLocation = true;

                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

                _cancelTokenSource = new CancellationTokenSource();

#if IOS
                //从 iOS 14 开始，用户可能会限制应用检测完全准确的位置。
                //该 Location.ReducedAccuracy 属性指示位置是否使用降低的准确性。
                //若要请求完全准确性，请将 GeolocationRequest.RequestFullAccuracy 属性设置为 true
                request.RequestFullAccuracy = true;
#endif

                 location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

                if (location != null)
                {
                   // result = $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}";
                   // Console.WriteLine(result);
                    return location;
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
                //result = $"not supported on device, {fnsEx.Message}";

                await AsyncAlert("设备上不支持" + fnsEx.Message, "提示");
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
                // result = $"not enabled on device, {fneEx.Message}";

                await AsyncAlert("未在设备上启用"+ fneEx.Message, "提示");
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
                //bool permissionGranted = false;
                //while (!permissionGranted)
                //{
                //    PermissionStatus locationWhenInUse = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

                //    permissionGranted = locationWhenInUse == PermissionStatus.Granted;
                //}
                //location = await GetCurrentLocation();
               await AsyncAlert("权限异常", "提示");
            }
            catch (Exception ex)
            {
                // Unable to get location
                //result = $"Unable to get location, {ex.Message}";
                //
                await AsyncAlert("无法获取位置"+ex.Message, "提示");
            }
            finally
            {
                _isCheckingLocation = false;
            }
            return new Location();
        }
        public  async Task<string> CheckPermissionsLocation()
        {
            //检查权限的当前状态
            PermissionStatus status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            //请求权限
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            }

            return status.ToString();
        }
    }
}
