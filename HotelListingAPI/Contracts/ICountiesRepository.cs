using HotelListingAPI.Data;

namespace HotelListingAPI.Contracts
{
    public interface ICountiesRepository : IGenericRepository<Country>
    {
        Task<Country> GetDetails(int id);
    }
}
