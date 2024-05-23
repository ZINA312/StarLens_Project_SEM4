using StarLens.UI.ViewModels;

namespace StarLens.UI.Pages;

public partial class UserPage : ContentPage
{
	public UserPage(UserViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}