using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StarLens.Applicationn.TopicUseCases.Queries.GetTopicsByTitle;
using System.Text.Json;


namespace StarLens.UI.ViewModels
{
    public partial class ForumViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        private string _searchText = string.Empty;
        private IEnumerable<Topic> _foundTopics;

        public ForumViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IEnumerable<Topic> FoundTopics
        {
            get { return _foundTopics; }
            set { _foundTopics = value; OnPropertyChanged(); }
        }
        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; OnPropertyChanged(); }
        }
        [RelayCommand]
        async Task FeedButtonClicked() => await GoToFeedPage();
        [RelayCommand]
        async Task SearchButtonClicked() => await GoToSearchPage();
        [RelayCommand]
        async Task AddPublicationButtonClicked() => await GoToAddPublicationPage();
        [RelayCommand]
        async Task UserButtonClicked() => await GoToUserPage();
        [RelayCommand]
        async Task SearchTextChanged() => await Search();
        [RelayCommand]
        async Task GoToTopicViewPage(Topic topic) => await OpenTopicPage(topic);
        [RelayCommand]
        async Task AddTopicButtonClicked() => await GoToAddTopicPage();

        public async Task OpenTopicPage(Topic topic)
        {
            var serializedTopic = JsonSerializer.Serialize(topic);
            await Shell.Current.GoToAsync($"TopicViewPage?topic={Uri.EscapeDataString(serializedTopic)}");
        }
        public async Task Search()
        {
            if(SearchText == string.Empty) { return; }
            FoundTopics = await _mediator.Send(new GetTopicsByTitleRequest(SearchText));
        }
        public async Task GoToAddTopicPage()
        {
            await Shell.Current.GoToAsync("AddTopicPage", false);
        }
        public async Task GoToAddPublicationPage()
        {
            await Shell.Current.GoToAsync("AddPublicationPage", false);
        }
        public async Task GoToFeedPage()
        {
            await Shell.Current.GoToAsync("FeedPage", false);
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
