using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StarLens.Applicationn.PublicationUseCases.Queries.GetPublicationByUserId;
using StarLens.Applicationn.SubscriptionUseCases.Commands.AddSubscription;
using StarLens.Applicationn.SubscriptionUseCases.Commands.RemoveSubscription;
using StarLens.Applicationn.SubscriptionUseCases.Queries.GetUserSubscribes;
using System.Text.Json;
using System.Threading.Tasks;

namespace StarLens.UI.ViewModels
{
    [QueryProperty(nameof(SerializedUser), "user")]
    public partial class UserViewViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        private User _user;
        private string _serializedUser = string.Empty;
        private string _avatarImageSource = "dotnet_bot.png";
        private IEnumerable<Publication> _publications;
        private Color _subscribeButtonColor;
        private bool _isSubscribed;
        private string _subscribeButtonText;

        public bool IsSubscribed
        {
            get => _isSubscribed;
            set { SetProperty(ref _isSubscribed, value); OnPropertyChanged(); }
        }

        public string SubscribeButtonText
        {
            get => _subscribeButtonText;
            set { SetProperty(ref _subscribeButtonText, value); OnPropertyChanged(); }
        }

        public Color SubscribeButtonColor
        {
            get => _subscribeButtonColor;
            set { SetProperty(ref _subscribeButtonColor, value); OnPropertyChanged(); }
        }
        public UserViewViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public UserViewViewModel(IMediator mediator, User user) : this(mediator)
        {
            User = user;
        }

        public User User
        {
            get => _user;
            set { SetProperty(ref _user, value); OnPropertyChanged(); }
        }
        [RelayCommand]
        async Task BackButtonClicked() => await GoBack(); 
        [RelayCommand]
        async Task UpdateUser() => await GetUser();
        [RelayCommand]
        async Task SubscribeButtonClicked() => await Subscribe();
        [RelayCommand]
        async Task OpenPublication(Publication publication) => await GoToPublicationPage(publication);

        public async Task GoToPublicationPage(Publication publication)
        {
            var serializedPublication = JsonSerializer.Serialize(publication);
            await Shell.Current.GoToAsync($"PublicationViewPage?publication={Uri.EscapeDataString(serializedPublication)}");
        }
        public async Task Subscribe()
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "user.json");
            User user = null;
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                user = JsonSerializer.Deserialize<User>(json);
            }
            if (IsSubscribed)
            {
                var userSubscribes = await _mediator.Send(new GetUserSubscribesRequest(user.Id));
                var subscription = userSubscribes.FirstOrDefault(s => s.SubscribedUser == User.Id);
                if (subscription != null)
                {
                    await _mediator.Send(new RemoveSubscriptionRequest(subscription));
                }
            }
            else
            {
                
                var subscription = new Subscription(user.Id, User.Id);
                await _mediator.Send(new AddSubscriptionRequest(subscription));
            }
            GetUser();
        }
        public async Task GetUser()
        {
            User = JsonSerializer.Deserialize<User>(Uri.UnescapeDataString(_serializedUser));
            Publications = await _mediator.Send(new GetPublicationByUserIdRequest(User.Id));
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "user.json");
            User user = null;
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                user = JsonSerializer.Deserialize<User>(json);
            }
            var userSubscribes = await _mediator.Send(new GetUserSubscribesRequest(user.Id));
            IsSubscribed = userSubscribes.Any(s => s.SubscribedUser == User.Id);
            if (IsSubscribed)
            {
                SubscribeButtonText = "Unsubscribe";
                SubscribeButtonColor = Color.Parse("LightGray");
            }
            else
            {
                SubscribeButtonText = "Subscribe";
                SubscribeButtonColor = Color.FromHex("#512bd4");
            }
        }
        public async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
        public string AvatarImageSource
        {
            get { return _avatarImageSource; }
            set { _avatarImageSource = value; OnPropertyChanged(); }
        }
        public string SerializedUser
        {
            get => _serializedUser;
            set { _serializedUser = value; OnPropertyChanged(); }
        }
        public IEnumerable<Publication> Publications
        {
            get { return _publications; }
            set { _publications = value; OnPropertyChanged(); }
        }
    }
}
