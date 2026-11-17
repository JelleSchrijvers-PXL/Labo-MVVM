using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.UI.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using Todo.UI.Data;
    using Todo.UI.Models;

    public class TodoListViewModel : INotifyPropertyChanged
    {
        public ICommand AddToDoCommand { get; private set; }
        private string _newTodoTitle;
        private ObservableCollection<TodoItem> _todoItems;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string NewTodoTitle
        {
            get
            {
                return _newTodoTitle;
            }
            set
            {
                _newTodoTitle = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<TodoItem> TodoItems
        {
            get => _todoItems;
            set
            {
                _todoItems = value;
                OnPropertyChanged();
            }
        }

        public TodoListViewModel()
        {
            this.TodoItems = new ObservableCollection<TodoItem>();

            //TODO: Initialise commands:
            AddToDoCommand = new Command(AddTodo);
            LoadDataCommand = new Command(LoadData);
        }

        private void AddTodo()
        {
            //TODO: add item to TodoItems, use NewTodoTitle as Title for the new item
            //TODO: clear the NewTodoTitle

            TodoItem item = new TodoItem
            {
                Title = this.NewTodoTitle,
                IsCompleted = false
            };
            
            this.TodoItems.Add(item);

            this.NewTodoTitle = string.Empty;
        }

        public ICommand LoadDataCommand { get; private set; }
        private void LoadData()
        {
            TodoItems = new ObservableCollection<TodoItem>(TodoDb.GetTodoItems(15));

            //foreach (TodoItem item in TodoDb.GetTodoItems(15)) 
            //{
            //    TodoItems.Add(item);
            //}
        }

        private void DeleteTodo(TodoItem item)
        {
            //TODO: remove item from TodoItems
        }
    }
}
