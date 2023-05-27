using HotelListingAPI.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace HotelListingAPI.Contracts
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto);
        Task<string> CreateRefreshToken();
        Task<AuthResponseDto> Login(LoginDto loginDto);
        Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request);
    }
}
