using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StarLens.Applicationn.TopicUseCases.Commands.AddTopic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace StarLens.UI.ViewModels
{
    public partial class AddTopicViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        private string _title = string.Empty;
        private string _text = string.Empty;
        private string _notifyLabel = string.Empty;

        public AddTopicViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public string Title 
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged(); }
        }
        public string Text
        {
            get { return _text; }
            set {  _text = value; OnPropertyChanged(); } 
        }
        public string NotifyLabel
        {
            get { return _notifyLabel; }
            set { _notifyLabel = value; OnPropertyChanged(); }
        }
        [RelayCommand]
        async Task AddTopicButtonClicked() => AddTopic();
        [RelayCommand]
        async Task BackButtonClicked() => await GoBack();
        public async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
        public async Task AddTopic()
        {
            if (Title == string.Empty) { NotifyLabel = "Title cannot be empty!"; return; }
            if (Text == string.Empty) { NotifyLabel = "Text cannot be empty!"; return; }
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "user.json");
            User user = null;
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                user = JsonSerializer.Deserialize<User>(json);
            }
            await _mediator.Send(new AddTopicRequest(Title, Text, user.Id));
            Title = string.Empty;
            Text = string.Empty;
            NotifyLabel = string.Empty;
        }
    }
}
