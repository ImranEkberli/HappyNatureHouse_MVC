namespace HappyNatureHouse_MVC.Models
{
    public class Slide
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Image { get; set; } = null!;
        public bool Status { get; set; }
    }
}
