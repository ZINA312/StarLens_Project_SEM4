using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StarLens.Applicationn.UserUseCases.Queries.GetUsersByNickname;
using StarLens.Applicationn.UserUseCases.Queries.SearchUsersByNickname;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using StarLens.UI.Pages;

namespace StarLens.UI.ViewModels
{
    public partial class SearchViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        private string _searchText;
        private IEnumerable<User> _foundusers;
        public SearchViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IEnumerable<User> FoundUsers 
        {
            get {  return _foundusers; }
            set { _foundusers = value; OnPropertyChanged(); }
        }
        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; OnPropertyChanged(); }
        }
        [RelayCommand]
        async Task FeedButtonClicked() => await GoToFeedPage();
        [RelayCommand]
        async Task UserButtonClicked() => await GoToUserPage();
        [RelayCommand]
        async Task AddPublicationButtonClicked() => await GoToAddPublicationPage();
        [RelayCommand]
        async Task ForumButtonClicked() => await GoToForumPage();
        [RelayCommand]
        async Task SearchTextChanged() => await Search();
        [RelayCommand]
        async Task GoToUserViewPage(User user) => await OpenUserPage(user);


        public async Task OpenUserPage(User user)
        {
            var serializedUser = JsonSerializer.Serialize(user);
            await Shell.Current.GoToAsync($"UserViewPage?user={Uri.EscapeDataString(serializedUser)}");
        }
        public async Task Search()
        {
            FoundUsers = await _mediator.Send(new SearchUsersByNicknameRequest(SearchText));
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
        public async Task GoToUserPage()
        {
            await Shell.Current.GoToAsync("UserPage", false);
        }

    }
}
