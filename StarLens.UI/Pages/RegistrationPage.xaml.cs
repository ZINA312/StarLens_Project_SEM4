using StarLens.UI.ViewModels;

namespace StarLens.UI.Pages;

public partial class RegistrationPage : ContentPage
{
	public RegistrationPage(RegistrationViewModel viewmodel)
	{
		InitializeComponent();
		BindingContext = viewmodel;
	}
}