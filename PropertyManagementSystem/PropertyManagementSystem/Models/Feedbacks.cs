namespace PropertyManagementSystem.Models
{
    public class Feedbacks
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public int CommentedUserId { get; set; }
        public bool IsAuthorLandlord { get; set; }
        public int Rating { get; set; }
        public DateTime CreationDate { get; set; }
        public User Author { get; set; }
        public User CommentedUser { get; set; }
        public Property Property { get; set; }
    }
}
