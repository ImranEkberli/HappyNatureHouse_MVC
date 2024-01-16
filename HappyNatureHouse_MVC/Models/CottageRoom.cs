namespace HappyNatureHouse_MVC.Models
{
    public class CottageRoom
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;      
        public string Title { get; set; } = null!;
        public string Image { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int CottageId { get; set; }
        public Cottage Cottage { get; set; } = null!;
    }
}
