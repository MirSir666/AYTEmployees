using AYTEmployees.Blazor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Logic
{


    public class UI
    {
        private readonly IBasePage page;

        public UI(IBasePage page)
        {
            this.page = page;
        }
        public async Task Working(Task action)
        {
            try
            {
                await action;
            }
            catch (Exception ex)
            {
                page.Alert(ex.Message, "网络错误");
                Debug.WriteLine(ex.Message);
                //throw;
            }
        }

        public void Working(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                page.Alert(ex.Message, "网络错误");
                Debug.WriteLine(ex.Message);
                //throw;
            }
        }
    }
}
