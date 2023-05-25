using AutoMapper;
using HotelListingAPI.Contracts;
using HotelListingAPI.Data;
using HotelListingAPI.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace HotelListingAPI.Repositoy
{
    public class AuthManager : IAuthManager
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApiUser> _userManager;

        public AuthManager(IMapper mapper, UserManager<ApiUser> userManager)
        {
            this._mapper = mapper;
            this._userManager = userManager;
        }
        public async Task<bool> Login(LoginDto loginDto)
        {
            bool isValidUsers = false;
            try
            {
                var user = await _userManager.FindByEmailAsync(loginDto.Email);
                isValidUsers = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            }
            catch (Exception)
            {


            }
            return isValidUsers;
        }
        public async Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto)
        {
            var user = _mapper.Map<ApiUser>(userDto);
            user.UserName = userDto.Email;
            var result = await _userManager.CreateAsync(user, userDto.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }
            return result.Errors;
        }
    }
}
