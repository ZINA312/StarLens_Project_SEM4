using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StarLens.Applicationn.CommentUseCases.Commands.AddComment;
using StarLens.Applicationn.CommentUseCases.Queries.GetCommentsByManyIds;
using StarLens.Applicationn.PublicationUseCases.Commands.UpdatePublication;
using StarLens.Applicationn.TopicUseCases.Commands.UpdateTopic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace StarLens.UI.ViewModels
{
    [QueryProperty(nameof(SerializedPublication), "publication")]
    public partial class PublicationViewViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        private Publication _publication;
        private string _serializedPublication = string.Empty;
        private List<Comment> _comments;
        private string _userName;
        private string _imageSource;
        private string _commentText = string.Empty;
        public PublicationViewViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public PublicationViewViewModel(IMediator mediator, Publication publication) : this(mediator)
        {
            Publication = publication;
        }
        public Publication Publication
        {
            get { return _publication; }
            set { _publication = value; OnPropertyChanged(); }
        }
        public string CommentText
        {
            get { return _commentText; }
            set { _commentText = value; OnPropertyChanged(); }
        }
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; OnPropertyChanged(); }
        }
        public string SerializedPublication
        {
            get { return _serializedPublication; }
            set { _serializedPublication = value; OnPropertyChanged(); }
        }
        public List<Comment> Comments
        {
            get => _comments;
            set { SetProperty(ref _comments, value); OnPropertyChanged(); }
        }
        [RelayCommand]
        async Task GoBackButtonClicked() => await GoBack();
        [RelayCommand]
        async Task AddCommentButtonClicked() => await AddComment();
        [RelayCommand]
        async Task UpdatePublication() => await GetPublication();
        public async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
        public async Task AddComment()
        {
            if (CommentText == string.Empty) { return; }
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "user.json");
            User user = null;
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                user = JsonSerializer.Deserialize<User>(json);
            }
            Comment comment = await _mediator.Send(new AddCommentRequest(user.Id, CommentText));
            CommentText = string.Empty;
            Publication.AddCommentId(comment.Id);
            _mediator.Send(new UpdatePublicationRequest(Publication));
            UpdateComments();
        }
        private async Task UpdateComments()
        {
            Comments = (await _mediator.Send(new GetCommentsByManyIdsRequest(Publication.CommentsIds))).ToList();
        }
        public async Task GetPublication()
        {
            Publication = JsonSerializer.Deserialize<Publication>(SerializedPublication);
            UserName = Publication.User.UserName;
            Comments = (await _mediator.Send(new GetCommentsByManyIdsRequest(Publication.CommentsIds))).ToList();
        }
    }
}
