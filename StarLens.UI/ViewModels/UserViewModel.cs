using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StarLens.Applicationn.PublicationUseCases.Queries.GetPublicationById;
using StarLens.Applicationn.PublicationUseCases.Queries.GetPublicationByUserId;
using StarLens.Applicationn.UserUseCases.Queries.GetUserById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace StarLens.UI.ViewModels
{
    public partial class UserViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        private User _user = null;
        private string _avatarImageSource = "dotnet_bot.png";
        private IEnumerable<Publication> _publications;
    
        public UserViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public User CurrentUser
        {
            get { return _user; }
            set { _user = value; OnPropertyChanged(); }
        }
        public string AvatarImageSouce
        {
            get { return _avatarImageSource; }
            set { _avatarImageSource = value; OnPropertyChanged(); }
        }
        public IEnumerable<Publication> Publications
        {
            get { return _publications; }
            set { _publications = value; OnPropertyChanged(); }
        }

        [RelayCommand]
        async Task OnLoadUser() => await LoadUser();
        [RelayCommand]
        async Task FeedButtonClicked() => await GoToFeedPage();
        [RelayCommand]
        async Task SearchButtonClicked() => await GoToSearchPage();
        [RelayCommand]
        async Task ForumButtonClicked() => await GoToForumPage();
        [RelayCommand]
        async Task AddPublicationButtonClicked() => await GoToAddPublicationPage();
        [RelayCommand]
        async Task LogOutButtonClicked() => await LogOut();
        [RelayCommand]
        async Task OpenPublication(Publication publication) => await GoToPublicationPage(publication);

        public async Task GoToPublicationPage(Publication publication)
        {
            var serializedPublication = JsonSerializer.Serialize(publication);
            await Shell.Current.GoToAsync($"PublicationViewPage?publication={Uri.EscapeDataString(serializedPublication)}");
        }
        public async Task LoadUser()
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "user.json");
            User user = null;
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                user = JsonSerializer.Deserialize<User>(json);
            }
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                CurrentUser = user;
            });
            Publications = await _mediator.Send(new GetPublicationByUserIdRequest(user.Id));
            Publications = Publications.OrderBy(p => DateTime.Parse(p.Date)).ToList();
        }
        public async Task GoToAddPublicationPage()
        {
            await Shell.Current.GoToAsync("AddPublicationPage", false);
        }
        public async Task GoToForumPage()
        {
            await Shell.Current.GoToAsync("ForumPage", false);
        }
        public async Task GoToFeedPage()
        {
            await Shell.Current.GoToAsync("FeedPage", false);
        }
        public async Task GoToSearchPage()
        {
            await Shell.Current.GoToAsync("SearchPage", false);
        }
        public async Task LogOut()
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "user.json");
            if (File.Exists(filePath))
            {
                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    CurrentUser = null;
                });
                File.WriteAllText(filePath, string.Empty);
            }
            await Shell.Current.GoToAsync("///LogInPage");
        }
    }
}
