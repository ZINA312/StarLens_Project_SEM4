using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StarLens.Applicationn.CommentUseCases.Commands.AddComment;
using StarLens.Applicationn.CommentUseCases.Queries.GetCommentById;
using StarLens.Applicationn.CommentUseCases.Queries.GetCommentsByManyIds;
using StarLens.Applicationn.TopicUseCases.Commands.UpdateTopic;
using StarLens.Applicationn.UserUseCases.Queries.GetUserById;
using System.Text.Json;

namespace StarLens.UI.ViewModels
{
    [QueryProperty(nameof(SerializedTopic), "topic")]
    public partial class TopicViewViewModel : ObservableObject
    {
        private readonly IMediator _mediator;
        private Topic _topic;
        private User _creator;
        private string _serializedTopic = string.Empty;
        private List<Comment> _comments;
        private string _commentText = string.Empty;

        public TopicViewViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public TopicViewViewModel(IMediator mediator, Topic topic) : this(mediator)
        {
            Topic = topic;
        }
        public User Creator
        {
            get => _creator;
            set { SetProperty(ref _creator, value); OnPropertyChanged(); }
        }
        public Topic Topic
        {
            get => _topic;
            set { SetProperty(ref _topic, value); OnPropertyChanged(); }
        }
        public string SerializedTopic
        {
            get => _serializedTopic;
            set { _serializedTopic = value; OnPropertyChanged(); }
        }
        public List<Comment> Comments
        {
            get => _comments;
            set { SetProperty(ref _comments, value); OnPropertyChanged(); }
        }
        public string CommentText
        {
            get { return _commentText; }
            set { _commentText = value; OnPropertyChanged(); }
        }
        [RelayCommand]
        async Task BackButtonClicked() => await GoBack();
        [RelayCommand]
        async Task UpdateTopic() => await GetTopic();
        [RelayCommand]
        async Task AddCommentButtonClicked() => await AddComment();
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
            Topic.AddCommentId(comment.Id);
            _mediator.Send(new UpdateTopicRequest(Topic));
            UpdateComments();
        }
        public async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
        private async Task UpdateComments()
        {
            Comments = (await _mediator.Send(new GetCommentsByManyIdsRequest(Topic.CommentsIds))).ToList();
        }
        public async Task GetTopic()
        {
            Topic = JsonSerializer.Deserialize<Topic>(SerializedTopic);
            Creator = await _mediator.Send(new GetUserByIdRequest(Topic.CreatorId));
            Comments = (await _mediator.Send(new GetCommentsByManyIdsRequest(Topic.CommentsIds))).ToList();
        }   
    }
}
