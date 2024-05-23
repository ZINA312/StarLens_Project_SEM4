using StarLens.UI.Pages;

namespace StarLens.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            
            InitializeComponent();
            Routing.RegisterRoute(nameof(RegistrationPage), typeof(RegistrationPage));
            Routing.RegisterRoute(nameof(LogInPage), typeof(LogInPage));
            Routing.RegisterRoute(nameof(UserPage), typeof(UserPage));
            Routing.RegisterRoute(nameof(FeedPage), typeof(FeedPage));
            Routing.RegisterRoute(nameof(SearchPage), typeof(SearchPage)); 
        }
    }
}
