using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StarLens.Applicationn.PublicationUseCases.Queries.GetPublicationByUserId;
using StarLens.Applicationn.SubscriptionUseCases.Queries.GetUserSubscribes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace StarLens.UI.ViewModels
{
    public partial class FeedViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        private IEnumerable<Publication> _publications;

        public FeedViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IEnumerable<Publication> Publications
        {
            get { return _publications; }
            set { _publications = value; OnPropertyChanged(); }
        }
        [RelayCommand]
        async Task LoadPublications() => await Load();
        [RelayCommand]
        async Task SearchButtonClicked() => await GoToSearchPage();
        [RelayCommand]
        async Task UserButtonClicked() => await GoToUserPage();
        [RelayCommand]
        async Task AddPublicationButtonClicked() => await GoToAddPublicationPage();
        [RelayCommand]
        async Task ForumButtonClicked() => await GoToForumPage();
        [RelayCommand]
        async Task OpenPublication(Publication publication) => await GoToPublicationPage(publication);

        public async Task GoToPublicationPage(Publication publication)
        {
            var serializedPublication = JsonSerializer.Serialize(publication);
            await Shell.Current.GoToAsync($"PublicationViewPage?publication={Uri.EscapeDataString(serializedPublication)}");
        }
        public async Task Load()
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "user.json");
            User user = null;
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                user = JsonSerializer.Deserialize<User>(json);
            }
            var subscriptions = await _mediator.Send(new GetUserSubscribesRequest(user.Id));
            var subscribedUserIds = subscriptions.Select(s => s.SubscribedUser);
            var publications = await GetPublicationsByUserIds(subscribedUserIds);

            Publications = publications;
        }
        private async Task<IEnumerable<Publication>> GetPublicationsByUserIds(IEnumerable<int> userIds)
        {
            var tasks = userIds.Select(userId => _mediator.Send(new GetPublicationByUserIdRequest(userId)));
            var results = await Task.WhenAll(tasks);
            var publications = results.SelectMany(result => result);
            return publications;
        }
        public async Task GoToAddPublicationPage()
        {
            await Shell.Current.GoToAsync("AddPublicationPage", false);
        }
        public async Task GoToForumPage()
        {
            await Shell.Current.GoToAsync("ForumPage", false);
        }
        public async Task GoToSearchPage()
        {
            await Shell.Current.GoToAsync("SearchPage", false);
        }
        public async Task GoToUserPage()
        {
            await Shell.Current.GoToAsync("UserPage", false);
        }
    }
}
