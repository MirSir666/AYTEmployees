using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYTEmployees.Blazor
{
    public class RoutesState
    {

        public bool Visible { get; private set; }

        public event Action OnChange;

        public void SetVal (bool val)
        {
            Visible = val;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
