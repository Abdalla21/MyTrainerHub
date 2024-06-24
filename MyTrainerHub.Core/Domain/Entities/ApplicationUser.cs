using Microsoft.AspNetCore.Identity;

namespace MyTrainerHub.Core.Domain.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
        }

        public ApplicationUser(string? email, string? phoneNumber)
        {
            Email = email;
            PhoneNumber = phoneNumber;
        }
    }
}
