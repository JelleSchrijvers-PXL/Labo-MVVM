using MauiIcons.Fluent.Filled;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Todo.UI.ViewModels;
using Todo.UI.Repositories;
using Todo.UI.Services;
using Todo.UI.Pages;
using CommunityToolkit.Mvvm.Messaging;

namespace Todo.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseFluentFilledMauiIcons()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            #region Services
            builder.Services.AddSingleton<ITodoRepository, TodoRepository>();
            builder.Services.AddSingleton<TodoService>();
            builder.Services.AddTransientWithShellRoute<ToDoListPage,TodoListViewModel>(nameof(ToDoListPage));
            builder.Services.AddTransientWithShellRoute<ToDoDetailPage,TodoDetailViewModel>(nameof(ToDoDetailPage));
            builder.Services.AddSingleton<INavigationService, MauiNavigationService>();
            builder.Services.AddSingleton<IMessenger>(WeakReferenceMessenger.Default);
            #endregion

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
