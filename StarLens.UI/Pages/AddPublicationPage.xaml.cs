using StarLens.UI.ViewModels;

namespace StarLens.UI.Pages;

public partial class AddPublicationPage : ContentPage
{
	public AddPublicationPage(AddPublicationViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}