using StarLens.UI.ViewModels;

namespace StarLens.UI.Pages;

public partial class ForumPage : ContentPage
{
	public ForumPage(ForumViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}