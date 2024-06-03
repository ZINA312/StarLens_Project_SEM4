using StarLens.UI.Pages;

namespace StarLens.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            
            InitializeComponent();
            Routing.RegisterRoute(nameof(RegistrationPage), typeof(RegistrationPage));
            Routing.RegisterRoute(nameof(UserPage), typeof(UserPage));
            Routing.RegisterRoute(nameof(FeedPage), typeof(FeedPage));
            Routing.RegisterRoute(nameof(SearchPage), typeof(SearchPage)); 
            Routing.RegisterRoute(nameof(AddPublicationPage), typeof(AddPublicationPage));
            Routing.RegisterRoute(nameof(ForumPage), typeof(ForumPage));
            Routing.RegisterRoute(nameof(AddSessionPage), typeof(AddSessionPage));
            Routing.RegisterRoute("UserViewPage", typeof(UserViewPage));
            Routing.RegisterRoute(nameof(TopicViewPage), typeof(TopicViewPage));
            Routing.RegisterRoute(nameof(AddTopicPage), typeof(AddTopicPage));
        }
    }
}
