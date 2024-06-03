using StarLens.UI.ViewModels;

namespace StarLens.UI.Pages;

public partial class TopicViewPage : ContentPage
{
	public TopicViewPage(TopicViewViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

}