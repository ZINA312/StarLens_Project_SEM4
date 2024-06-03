using StarLens.UI.ViewModels;

namespace StarLens.UI.Pages;

public partial class AddTopicPage : ContentPage
{
	public AddTopicPage(AddTopicViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}