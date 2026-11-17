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

    public partial class TodoListViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddTodoCommand))]
        private string _newTodoTitle = "";
        [ObservableProperty]
        private ObservableCollection<TodoItem> _todoItems;
        public TodoListViewModel()
        {
            this.TodoItems = new ObservableCollection<TodoItem>();
        }
        private bool CanAddTodo()
        {
            return this.NewTodoTitle.Length >= 10;
        }
        [RelayCommand(CanExecute = nameof(CanAddTodo))]
        private void AddTodo()
        {
            TodoItem item = new TodoItem
            {
                Title = this.NewTodoTitle,
                IsCompleted = false
            };
            
            this.TodoItems.Add(item);

            this.NewTodoTitle = string.Empty;
        }
        [RelayCommand]
        private async Task LoadData()
        {
            await Task.Delay(2000);
            TodoItems = new ObservableCollection<TodoItem>(TodoDb.GetTodoItems(15));
        }
        [RelayCommand]
        private void DeleteTodo(TodoItem item)
        {
            //TODO: remove item from TodoItems
            this.TodoItems.Remove(item);
        }
    }
}