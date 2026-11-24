using Todo.UI.Models;

namespace Todo.UI.Repositories
{
    public interface ITodoRepository
    {
        void Add(TodoItem item);
        List<TodoItem> GetAll();
        void Remove(TodoItem item);
    }
}