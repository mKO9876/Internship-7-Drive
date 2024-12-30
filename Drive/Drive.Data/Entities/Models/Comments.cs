﻿namespace Drive.Data.Entities.Models
{
    public class Comments
    {
        public Comments(string commentText) {
            CommentText = commentText;
            CommentingDate = DateTime.UtcNow;
        }
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int FileId { get; set; }
        public string CommentText { get; set; } = null!;
        public DateTime CommentingDate { get; set; }
        public Users User { get; set; } = null!;
    }
}
