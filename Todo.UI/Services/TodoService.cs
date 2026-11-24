using System;
using System.Collections.Generic;
using System.Text;
using Todo.UI.Models;
using Todo.UI.Repositories;

namespace Todo.UI.Services
{
    public class TodoService
    {
        private readonly ITodoRepository _repository;

        public TodoService(ITodoRepository repository)
        {
            _repository = repository;
        }
        public List<TodoItem> GetAllTodos()
        {
            return _repository.GetAll();
        }
        public TodoItem AddTodo(string title)
        {
            TodoItem item = new TodoItem
            {
                Title = title,
                IsCompleted = false,
            };
            _repository.Add(item);
            return item;
        }

        public void RemoveTodo(TodoItem item)
        {
            _repository.Remove(item);
        }
    }
}
