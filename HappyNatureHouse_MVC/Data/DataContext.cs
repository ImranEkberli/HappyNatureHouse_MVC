using HappyNatureHouse_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace HappyNatureHouse_MVC.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
                
        }
        public DbSet<Cottage> Cottages { get; set; }
        public DbSet<CottageImage> CottageImages { get; set; }
        public DbSet<CottageRoom> CottageRooms { get; set; }
    }
}
