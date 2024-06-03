using StarLens.UI.ViewModels;

namespace StarLens.UI.Pages;

public partial class UserViewPage : ContentPage
{
	public UserViewPage(UserViewViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}