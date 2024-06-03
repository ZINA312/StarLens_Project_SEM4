using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StarLens.Applicationn.PublicationUseCases.Queries.GetPublicationByUserId;
using StarLens.Applicationn.SubscriptionUseCases.Commands.AddSubscription;
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
        
        public async Task Subscribe()
        {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "user.json");
            User user = null;
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                user = JsonSerializer.Deserialize<User>(json);
            }
            var subscription = new Subscription(user.Id, User.Id);
            await _mediator.Send(new AddSubscriptionRequest(subscription));
        }
        public async Task GetUser()
        {
            User = JsonSerializer.Deserialize<User>(Uri.UnescapeDataString(_serializedUser));
            Publications = await _mediator.Send(new GetPublicationByUserIdRequest(User.Id));
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
