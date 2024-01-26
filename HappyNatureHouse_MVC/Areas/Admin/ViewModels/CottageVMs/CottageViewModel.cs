namespace HappyNatureHouse_MVC.Areas.Admin.ViewModels.CottageVMs
{
    public class CottageViewModel
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
        public DateTime CreateDate { get; set; }
        public DateTime? ModifierDate { get; set; }
        public bool Status { get; set; }
    }
}
