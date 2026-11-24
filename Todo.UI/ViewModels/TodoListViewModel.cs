using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.UI.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using Todo.UI.Data;
    using Todo.UI.Models;
    using Todo.UI.Services;

    public partial class TodoListViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddTodoCommand))]
        private string _newTodoTitle = "";
        [ObservableProperty]
        private ObservableCollection<TodoItem> _todoItems;
        private readonly TodoService _service;

        public TodoListViewModel(TodoService service)
        {
            _service = service;
        }
        private bool CanAddTodo()
        {
            return this.NewTodoTitle.Length >= 10;
        }
        [RelayCommand(CanExecute = nameof(CanAddTodo))]
        private void AddTodo()
        {
            TodoItem item = _service.AddTodo(this.NewTodoTitle);
            TodoItems.Add(item);
            this.NewTodoTitle = string.Empty;
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