using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StarLens.Applicationn.PublicationUseCases.Commands.AddPublication;
using Microsoft.Maui.Graphics.Skia;
using SkiaSharp;
using System.Text.Json;


namespace StarLens.UI.ViewModels
{
    public partial class AddPublicationViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        private string _selectImageSource;
        private string _title = string.Empty;
        private string _description = string.Empty;
        private string _notifyLabel = string.Empty;
        private List<Session> _sessions = [];

        

        public AddPublicationViewModel(IMediator mediator)
        {
            _mediator = mediator;
            MessagingCenter.Subscribe<AddSessionViewModel, Session>(this, AddSessionViewModel.SessionAddedMessage, (sender, session) =>
            {
                Sessions = Sessions.Append(session).ToList();
            });
            _selectImageSource = "select_image.png";
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged(); }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; OnPropertyChanged(); }
        }
        public string NotifyLabel
        {
            get { return _notifyLabel; }
            set { _notifyLabel = value; OnPropertyChanged(); }
        }
        public string SelectedImageSource
        {
            get { return _selectImageSource; }
            set { _selectImageSource = value; OnPropertyChanged(); }
        }
        public List<Session> Sessions
        {
            get { return _sessions; }
            set { _sessions = value; OnPropertyChanged(); }
        }
        [RelayCommand]
        async Task AddImageButtonClicked() => await AddImage();
        [RelayCommand]
        async Task AddSessionButtonClicked() => await GoToSessionPage();
        [RelayCommand]
        async Task PublishButtonClicked() => await Publish();
        [RelayCommand]
        async Task FeedButtonClicked() => await GoToFeedPage();
        [RelayCommand]
        async Task SearchButtonClicked() => await GoToSearchPage();
        [RelayCommand]
        async Task ForumButtonClicked() => await GoToForumPage();
        [RelayCommand]
        async Task UserButtonClicked() => await GoToUserPage();


        public async Task AddImage()
        {
            var photo = await MediaPicker.PickPhotoAsync();

            if (photo != null)
            {
                var filePath = photo.FullPath;
                FileStream stream = null;
                try
                {
                    stream = File.OpenRead(filePath);

                    using (var skiaBitmap = SKBitmap.Decode(stream))
                    {
                        var width = skiaBitmap.Width;
                        var height = skiaBitmap.Height;
                        var minWidth = 100;
                        var minHeight = 100;
                        var maxWidth = 10000;
                        var maxHeight = 10000;
                        var maxFileSize = 20 * 1024 * 1024;

                        if (width < minWidth || height < minHeight || width > maxWidth || height > maxHeight || stream.Length > maxFileSize)
                        {
                            NotifyLabel = "Image selection error, minimum and maximum width and height are 100 and 10000 pixels, weight should not exceed 20 MB";
                            return;
                        }
                    }
                }
                catch { }
                NotifyLabel = string.Empty;
                SelectedImageSource = filePath;
            }
        }
        public async Task Publish()
        {
            if (Title.Length > 50 || Title == string.Empty) { NotifyLabel = "Invalid title, it must be less then 50 symbols and not empty!"; return; }
            if (Description.Length > 150 || Description == string.Empty) { NotifyLabel = "Invalid description, it must be less then 150 symbols and not empty!"; return; }
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "user.json");
            User user = null;
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                user = JsonSerializer.Deserialize<User>(json);
            }
            Publication newPublication = new Publication(user.Id, Title, Description, new TechCard(Sessions.ToList()));
            await _mediator.Send(new AddPublicationRequest(newPublication));
            Title = string.Empty;
            Description = string.Empty;
            NotifyLabel = string.Empty;
            Sessions = [];
            SelectedImageSource = "select_image.png";
        }
        public async Task GoToSessionPage()
        {
            await Shell.Current.GoToAsync("AddSessionPage", false);
        }
        public async Task GoToForumPage()
        {
            await Shell.Current.GoToAsync("ForumPage", false);
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
