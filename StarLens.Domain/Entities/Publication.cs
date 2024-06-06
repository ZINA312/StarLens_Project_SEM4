using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json.Serialization;

namespace StarLens.Domain.Entities
{
    public class Publication : Entity
    {
        public Publication(int userid, string title, string description, TechCard? techCard)
        {
            UserId = userid;
            Title = title;
            Description = description;
            TechInfo = techCard;
            Date = DateTime.Now.ToString("d");
        }

        [JsonConstructor]
        public Publication(string title, int userId, User user, string description,
                       List<int> likedByUsersIds, List<int> commentsIds,
                       TechCard techInfo, string date, int id)
        {
            this.Title = title;
            this.UserId = userId;
            this.User = user;
            this.Description = description;
            this.LikedByUsersIds = likedByUsersIds;
            this.CommentsIds = commentsIds;
            this.TechInfo = techInfo;
            this.Date = date;
            this.Id = id;
        }

        public string Title { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<int> LikedByUsersIds { get; set; } = new List<int>();
        public List<int> CommentsIds { get; set; } = new List<int>();
        public TechCard? TechInfo { get; set; }
        public string Date { get; set; } = string.Empty;

        public void AddCommentId(int id)
        {
            CommentsIds.Add(id);
        }
    }
}