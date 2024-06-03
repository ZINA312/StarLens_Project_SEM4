using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using StarLens.Applicationn.UserUseCases.Commands.AddUser;
using StarLens.Applicationn.UserUseCases.Queries.GetUserByEmail;
using StarLens.Applicationn.UserUseCases.Queries.GetUsersByNickname;
using System.Text.RegularExpressions;

namespace StarLens.UI.ViewModels
{
    public partial class RegistrationViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        private string _email = string.Empty;
        private string _password = string.Empty;
        private string _nickname = string.Empty;
        private string _notifyLabel = string.Empty;
        private string _passwordEntryColor = "WhiteSmoke";
        private string _nicknameEntryColor = "WhiteSmoke";
        private string _emailEntryColor = "WhiteSmoke";

        public RegistrationViewModel(IMediator mediator)
        {
            _mediator = mediator;
            NotifyLabel = string.Empty;
        }
        public string Email
        { 
            get { return _email; }
            set { _email = value; OnPropertyChanged(); EmailChanged(); }
        }
        public string Password 
        { 
            get { return _password; }
            set { _password = value; OnPropertyChanged(); PasswordChanged(); }
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
        public string PasswordEntryColor
        {
            get { return _passwordEntryColor; }
            set { _passwordEntryColor = value; OnPropertyChanged();  }
        }
        public string NicknameEntryColor
        {
            get { return _nicknameEntryColor; }
            set { _nicknameEntryColor = value; OnPropertyChanged(); }
        }
        public string EmailEntryColor
        {
            get { return _emailEntryColor; }
            set { _emailEntryColor = value; OnPropertyChanged(); }
        }

        [RelayCommand]
        async Task RegisterButtonClicked() => await Register();
        [RelayCommand]
        async Task BackButtonClicked() => await GoBack();
        [RelayCommand]
        async Task PasswordChanged() => await PasswordEntryChanged();
        [RelayCommand]
        async Task EmailChanged() => await EmailEntryChanged();
        public async Task Register()
        {
            if (Email == string.Empty) { NotifyLabel = "Email is empty!"; EmailEntryColor = "Red"; return; }
            if (Password == string.Empty) { NotifyLabel = "Password is empty!"; PasswordEntryColor = "Red"; return; }
            if (NickName == string.Empty) { NotifyLabel = "NickName is empty!"; NicknameEntryColor = "Red"; return; }
            if (await _mediator.Send(new GetUserByEmailRequest(Email)) != null) { NotifyLabel = "Email is not available!"; EmailEntryColor = "Red"; return; }
            if (await _mediator.Send(new GetUsersByNicknameRequest(NickName)) != null) { NotifyLabel = "Nickname is not available!"; NicknameEntryColor = "Red"; return; }
            if (!IsValidPassword(Password))
            {
                PasswordEntryColor = "Red";
                NotifyLabel = "Invalid password format! Password must contain: \n·At least 8 characters\n·One uppercase letter\n·One lowercase letter\n·One digit\n·One special character";
                return;
            }
            if(!IsValidEmail(Email))
            {
                EmailEntryColor = "Red";
                NotifyLabel = "Invalid email format!";
                return;
            }
            if(!IsValidNickname(NickName))
            {
                PasswordEntryColor = "Red";
                NotifyLabel = "Invalid nickname format! Nickname must contain: \n·At least 3 characters\n·Only letters,digits and _";
                return;
            }
            await _mediator.Send(new AddUserRequest(NickName, Email, Password));
            User user = new User(NickName, Password, Email);
            string json = JsonConvert.SerializeObject(user);
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "user.json");
            File.WriteAllText(filePath, json);
            NickName = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            await Shell.Current.GoToAsync("UserPage");
        }
        public async Task PasswordEntryChanged()
        {
            if (!IsValidPassword(Password))
            {
                PasswordEntryColor = "Red";
                NotifyLabel = "Invalid password format! Password must contain: \n·At least 8 characters\n·One uppercase letter\n·One lowercase letter\n·One digit\n·One special character";
            }
            else
            {
                PasswordEntryColor = "Green";
                NotifyLabel = string.Empty;
            }
        }
        public async Task EmailEntryChanged()
        {
            if (!IsValidEmail(Email))
            {
                EmailEntryColor = "Red";
                NotifyLabel = "Invalid email format!";
            }
            else
            {
                EmailEntryColor = "Green";
                NotifyLabel = string.Empty;
            }
        }
        public async Task NicknameEntryChanged()
        {
            if (!IsValidNickname(NickName))
            {
                EmailEntryColor = "Red";
                NotifyLabel = "Invalid nickname format! Nickname must contain: \n·At least 3 characters\n·Only letters,digits and _";
            }
            else
            {
                EmailEntryColor = "Green";
                NotifyLabel = string.Empty;
            }
        }
        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";
            return Regex.IsMatch(email, pattern);
        }
        private bool IsValidPassword(string password)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$";
            return Regex.IsMatch(password, pattern);
        }
        private bool IsValidNickname(string nickname)
        {
            if (nickname.Length < 3 || nickname.Length > 18)
            {
                return false;
            }
            foreach (char c in nickname)
            {
                if (!char.IsLetterOrDigit(c) && c != '_')
                {
                    return false;
                }
            }
            return true;
        }

        public async Task GoBack()
        {
            Email = string.Empty;
            Password = string.Empty;
            NickName = string.Empty;
            NotifyLabel = string.Empty;
            await Shell.Current.GoToAsync("///LogInPage");
        }
    }
}
