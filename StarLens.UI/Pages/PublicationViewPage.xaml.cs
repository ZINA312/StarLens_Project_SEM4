using StarLens.UI.ViewModels;

namespace StarLens.UI.Pages;

public partial class PublicationViewPage : ContentPage
{
	public PublicationViewPage(PublicationViewViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}