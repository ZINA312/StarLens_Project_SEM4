using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using StarLens.Applicationn.UserUseCases.Commands.AddUser;
using StarLens.Applicationn.UserUseCases.Queries.GetUserByEmail;
using StarLens.Applicationn.UserUseCases.Queries.GetUsersByNickname;
using StarLens.UI.Pages;

namespace StarLens.UI.ViewModels
{
    public partial class RegistrationViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        private string _email = string.Empty;
        private string _password = string.Empty;
        private string _nickname = string.Empty;
        private string _notifyLabel = string.Empty;

        public RegistrationViewModel(IMediator mediator)
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
        public string NickName 
        { 
            get { return _nickname; } 
            set { _nickname = value; OnPropertyChanged(); } 
        }
        public string NotifyLabel
        { 
            get { return _notifyLabel; } 
            set { _notifyLabel = value; OnPropertyChanged(); }
        }

        [RelayCommand]
        async Task RegisterButtonClicked() => await Register();
        [RelayCommand]
        async Task BackButtonClicked() => await GoBack();

        public async Task Register()
        {
            if (Email == string.Empty) { NotifyLabel = "Email is empty!"; return; }
            if (Password == string.Empty) { NotifyLabel = "Password is empty!"; return; }
            if (NickName == string.Empty) { NotifyLabel = "NickName is empty!"; return; }
            if (await _mediator.Send(new GetUserByEmailRequest(Email)) != null) { NotifyLabel = "Email is not available!"; return; }
            var us = await _mediator.Send(new GetUsersByNicknameRequest(NickName));
            if (await _mediator.Send(new GetUsersByNicknameRequest(NickName)) != null) { NotifyLabel = "Nickname is not available!"; return; }
            await _mediator.Send(new AddUserRequest(NickName, Email, Password));
            User user = new User(NickName, Password, Email);
            string json = JsonConvert.SerializeObject(user);
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "user.json");
            File.WriteAllText(filePath, json);
            NickName = string.Empty;
            Email = string.Empty ;
            Password = string.Empty ;
            await Shell.Current.GoToAsync("UserPage");
        }

        public async Task GoBack()
        {
            await Shell.Current.GoToAsync("///LogInPage");
        }
    }
}
