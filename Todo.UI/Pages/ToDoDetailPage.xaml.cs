using Todo.UI.ViewModels;

namespace Todo.UI.Pages;

public partial class ToDoDetailPage : ContentPage
{
	public ToDoDetailPage(TodoDetailViewModel vm)
	{
		InitializeComponent();

		this.BindingContext = vm;
	}
}