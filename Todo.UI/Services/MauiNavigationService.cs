using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.UI.Services
{
    public class MauiNavigationService : INavigationService
    {
        public Task InitializeAsync()
        {
            throw new NotImplementedException();
        }

        public Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = null)
        {
            return
                routeParameters != null
                    ? Shell.Current.GoToAsync(route, routeParameters)
                    : Shell.Current.GoToAsync(route);
        }

        public Task PopAsync()
        {
            return Shell.Current.GoToAsync("..");
        }
    }
}
