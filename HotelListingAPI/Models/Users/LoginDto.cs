using System.ComponentModel.DataAnnotations;

namespace HotelListingAPI.Models.Users
{
    public class LoginDto
    {
        [Required]
        [StringLength(15, ErrorMessage = "Your Password is limited to {2} to {1} charactor", MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
