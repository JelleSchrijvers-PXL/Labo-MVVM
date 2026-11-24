using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.UI.Services
{
    public interface INavigationService
    {
        Task InitializeAsync();

        Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = null);

        Task PopAsync();
    }
}
