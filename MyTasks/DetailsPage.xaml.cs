using MyTasks.ViewModel;

namespace MyTasks;

public partial class DetailsPage : ContentPage
{

	public DetailsPage(DetailsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}