using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace StarLens.Domain.Entities
{
    public class Topic : Entity
    {
        public Topic(int userId, string title, string text)
        {
            CreatorId = userId;
            Title = title;
            Text = text;
        }
        [JsonConstructor]
        public Topic(int id, int creatorId, string title, string text, List<int> commentsIds)
        {
            Id = id;
            CreatorId = creatorId;
            Title = title;
            Text = text;
            CommentsIds = commentsIds;
        }

        public int CreatorId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public List<int> CommentsIds { get; set; } = new List<int>();

        public void AddCommentId(int id)
        {
            CommentsIds.Add(id);
        }
    }
}