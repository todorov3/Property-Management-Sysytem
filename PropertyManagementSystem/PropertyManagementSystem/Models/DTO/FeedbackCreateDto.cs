namespace PropertyManagementSystem.Models.DTO
{
    public class FeedbackCreateDto
    {
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public int CommentedUserId { get; set; }
        public bool IsAuthorLandlord { get; set; }
        public double Rating { get; set; }
        public int PropertyId { get; set; }
    }
}
