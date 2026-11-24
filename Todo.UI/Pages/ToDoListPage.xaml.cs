using Todo.UI.ViewModels;

namespace Todo.UI.Pages
{

	public partial class ToDoListPage : ContentPage
	{
		public ToDoListPage(TodoListViewModel vm)
		{
			InitializeComponent();

			this.BindingContext = vm;
		}
	}
}