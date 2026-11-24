using System;
using System.Collections.Generic;
using System.Text;
using Todo.UI.Data;
using Todo.UI.Models;

namespace Todo.UI.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        public TodoRepository()
        {
            _todoItems = TodoDb.GetTodoItems(5);
        }
        private List<TodoItem> _todoItems = new List<TodoItem>();
        public List<TodoItem> GetAll()
        {
            return _todoItems.ToList();
        }
        public void Add(TodoItem item)
        {
            _todoItems.Add(item);
        }

        public void Remove(TodoItem item)
        {
            _todoItems.Remove(item);
        }
    }
}
