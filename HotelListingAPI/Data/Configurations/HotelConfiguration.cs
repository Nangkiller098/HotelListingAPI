using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListingAPI.Data.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            //builder.ToTable("RoleId");
            builder.HasData(

                new Hotel
                {
                    Id = 1,
                    Name = "Sokha",
                    Address = "sokha beach",
                    CountryId = 1,
                    Rating = 4.5
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Independence",
                    Address = "Independence",
                    CountryId = 2,
                    Rating = 4.5
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Angkor",
                    Address = "sr",
                    CountryId = 3,
                    Rating = 4.5
                }


                );
        }
    }
}
