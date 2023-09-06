using Microsoft.AspNetCore.Identity;

namespace Ryder.Domain.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePictureUrl { get; set; }
        public Address Address { get; set; }
    }
}