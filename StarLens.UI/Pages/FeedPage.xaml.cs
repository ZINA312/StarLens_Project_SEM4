using StarLens.UI.ViewModels;

namespace StarLens.UI.Pages;

public partial class FeedPage : ContentPage
{
	public FeedPage(FeedViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}