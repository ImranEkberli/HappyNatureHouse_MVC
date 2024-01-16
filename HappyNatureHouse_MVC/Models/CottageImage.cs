namespace HappyNatureHouse_MVC.Models
{
    public class CottageImage
    {
        public int Id { get; set; }
        public string Image { get; set; } = null!;
        public int CottageId { get; set; }
        public Cottage Cottage { get; set; } = null!;
        public int? CottageRoomId { get; set; }
        public CottageRoom? CottageRoom { get; set; }
    }
}
