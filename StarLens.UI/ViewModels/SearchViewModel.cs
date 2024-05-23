using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StarLens.Applicationn.UserUseCases.Queries.GetUsersByNickname;
using StarLens.Applicationn.UserUseCases.Queries.SearchUsersByNickname;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        async Task SearchTextChanged() => await Search();

        public async Task Search()
        {
            FoundUsers = await _mediator.Send(new SearchUsersByNicknameRequest(SearchText));
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
