
namespace AYTEmployees.WifiTool.Abstractions
{
    public class NetworkData
    {
        public int StausId { get; set; }
        public string? Ssid { get; set; }
        public int IpAddress { get; set; }
        public string? GatewayAddress { get; set; }
        public object? NativeObject { get; set; }
        public string? Bssid { get; set; }
        public object? SignalStrength { get; set; }
        public object? SecurityType { get; set; }

        public string? MacAddress { get; set; }
    }
}
