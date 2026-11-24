namespace Todo.UI.Pages;

public partial class ToDoDetailPage : ContentPage
{
	public ToDoDetailPage(ToDoDetailPage vm)
	{
		InitializeComponent();

		this.BindingContext = vm;
	}
}