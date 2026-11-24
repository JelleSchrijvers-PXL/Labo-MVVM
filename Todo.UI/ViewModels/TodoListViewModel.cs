using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.UI.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using CommunityToolkit.Mvvm.Messaging;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using Todo.UI.Data;
    using Todo.UI.Messages;
    using Todo.UI.Models;
    using Todo.UI.Pages;
    using Todo.UI.Services;

    public partial class TodoListViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<TodoItem> _todoItems;
        private readonly TodoService _service;
        private readonly INavigationService _navigation;

        public TodoListViewModel(TodoService service, INavigationService navigation, IMessenger messenger)
        {
            _service = service;
            _navigation = navigation;
            messenger.Register<TodoAddMessage>(this, (_, message) =>
            {
                TodoItems.Add(message.Value);
            });
        }
        [RelayCommand]
        private async Task GoToDetail(TodoItem item = null)
        {
            Dictionary<string, object> routeParameters = null;

            if (item is not null)
                routeParameters = new Dictionary<string, object>
                {
                    { "SelectedTodo", item }
                };

            await _navigation.NavigateToAsync(nameof(ToDoDetailPage),routeParameters);
        }
        [RelayCommand]
        private async Task LoadData()
        {
            await Task.Delay(2000);
            TodoItems = new ObservableCollection<TodoItem>(_service.GetAllTodos());
        }
        [RelayCommand]
        private void DeleteTodo(TodoItem item)
        {
            _service.RemoveTodo(item);
            TodoItems.Remove(item);
        }
    }
}