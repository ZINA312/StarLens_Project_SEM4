using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StarLens.Applicationn.UserUseCases.Queries.GetUserByEmail;
using Newtonsoft.Json;

namespace StarLens.UI.ViewModels
{
    public partial class LogInViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        private string _email = string.Empty;
        private string _password = string.Empty;
        private string _notifyLabel = string.Empty;
        
        public LogInViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged(); }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }
        public string NotifyLabel
        {
            get { return _notifyLabel; }
            set { _notifyLabel = value; OnPropertyChanged(); }
        }
        [RelayCommand]
        async Task LogInClicked() => await LogIn();
        [RelayCommand]
        async Task RegisterClicked() => await GoToRegisterPage();

        public async Task LogIn()
        {
            if(Email == string.Empty) { NotifyLabel = "Email is empty!"; return; }
            if(Password == string.Empty) { NotifyLabel = "Password in empty!"; return; }
            User user = await _mediator.Send(new GetUserByEmailRequest(Email));
            if(user == null || user.Password != Password) { NotifyLabel = "Incorrect email or password!"; return; }
            string json = JsonConvert.SerializeObject(user);
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "user.json");
            File.WriteAllText(filePath, json);
            Email = string.Empty;
            Password = string.Empty;
            NotifyLabel = string.Empty;
            await Shell.Current.GoToAsync("UserPage");
        }

        public async Task GoToRegisterPage()
        {
            await Shell.Current.GoToAsync("RegistrationPage");
        }
    }
}
