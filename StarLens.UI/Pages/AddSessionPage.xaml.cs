using StarLens.UI.ViewModels;

namespace StarLens.UI.Pages;

public partial class AddSessionPage : ContentPage
{
	public AddSessionPage(AddSessionViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}