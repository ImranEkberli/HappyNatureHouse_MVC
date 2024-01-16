namespace HappyNatureHouse_MVC.Models
{
    public class Cottage
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public string Image { get; set; } = null!;
        public int RoomCount { get; set; }
        public int GuestCount { get; set; }
        public int SingleBed { get; set; }
        public int DoubleBed { get; set; }
        public bool Status { get; set; }
        public List<CottageRoom>? CottageRooms { get; set; }
        public List<CottageImage>? CottageImages { get; set; }
    }
}
