using Microsoft.EntityFrameworkCore;

namespace HotelListingAPI.Data
{
    public class HotelListingDbContext : DbContext
    {
        public HotelListingDbContext(DbContextOptions options) : base(options)
        {


        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> countries { get; set; }
        //protected override void ConfigureConventions(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    //modelBuilder.Entity<Country>().HasData(
        //    //    new Country
        //    //    {
        //    //        Id = 1,
        //    //        Name = "test",
        //    //        ShortName = "t",
        //    //    },
        //    //    new Country
        //    //    {
        //    //        Id=2,
        //    //        Name="test2",
        //    //        ShortName="t2"

        //    //    }
        //    //    );
        //}
    }
}
