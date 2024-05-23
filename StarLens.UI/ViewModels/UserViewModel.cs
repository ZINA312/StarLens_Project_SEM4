using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using StarLens.Applicationn.UserUseCases.Queries.GetUserById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarLens.UI.ViewModels
{
    public partial class UserViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        private User _user = null;
        private string _avatarImageSource = "dotnet_bot.png";

    
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

        [RelayCommand]
        async Task OnLoadUser() => await LoadUser();
        [RelayCommand]
        async Task FeedButtonClicked() => await GoToFeedPage();
        [RelayCommand]
        async Task SearchButtonClicked() => await GoToSearchPage();
        [RelayCommand]
        async Task LogOutButtonClicked() => await LogOut();



        public async Task LoadUser()
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "user.json");
            User user = null;
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                user = JsonConvert.DeserializeObject<User>(json);
            }
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                CurrentUser = user;
            });
            
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
