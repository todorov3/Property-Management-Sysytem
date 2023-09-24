namespace PropertyManagementSystem.Models
{
    public class Property
    {
        public int Id { get; set; }
        public int LandlordId { get; set; }
        public string TownName { get; set; }
        public string PropertyType { get; set; } //Enum
        public int Area { get; set; }
        public int NumOfRooms { get; set; }
        public int NumOfFloors { get; set; }
        public int NumOfBedrooms { get; set; }
        public int NumOfBathrooms { get; set; }
        public bool? PetsAllowed { get; set; }
        public int YardArea { get; set; }
        public decimal Price { get; set; }
        public IFormFile? Photo { get; set; }
        public DateOnly FreeDates { get; set; }
        public bool IsArchived { get; set; }
        public bool IsDeleted { get; set; }
        public User Landlord { get; set; }
    }
}
