namespace PropertyManagementSystem.Models.DTO
{
    public class FeedbackResponseDto
    {
        public int Id { get; set; }
        public int RequestId { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public int CommentedUserId { get; set; }
        public bool IsAuthorLandlord { get; set; }
        public int Rating { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
