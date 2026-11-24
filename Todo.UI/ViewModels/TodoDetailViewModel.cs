using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.UI.Messages;
using Todo.UI.Models;
using Todo.UI.Services;

namespace Todo.UI.ViewModels
{
    public partial class TodoDetailViewModel : ObservableObject
    {
        private readonly TodoService _service;
        private readonly INavigationService _navigation;
        private readonly IMessenger _messenger;

        public TodoDetailViewModel(TodoService service, INavigationService navigation, IMessenger messenger)
        {
            _service = service;
            _navigation = navigation;
            _messenger = messenger;
        }

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        private string _title;
        [ObservableProperty]
        private string _description;
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        private DateTime _dueDate = DateTime.Now;
        private bool CanSaveTodo()
        {
            return !string.IsNullOrEmpty(Title) && DueDate != null;
        }
        [RelayCommand(CanExecute = nameof(CanSaveTodo))]
        private async Task Save()
        {
            TodoItem item =_service.SaveTodo(Title, Description, DueDate);
            _messenger.Send(new TodoAddMessage(item));
            await _navigation.PopAsync();
        }
    }
}
