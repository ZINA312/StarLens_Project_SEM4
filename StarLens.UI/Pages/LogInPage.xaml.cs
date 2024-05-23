using StarLens.UI.ViewModels;

namespace StarLens.UI.Pages;

public partial class LogInPage : ContentPage
{
	public LogInPage(LogInViewModel viewModel)
	{
        InitializeComponent();
        BindingContext = viewModel;
    }
}