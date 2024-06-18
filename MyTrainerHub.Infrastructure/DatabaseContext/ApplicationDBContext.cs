using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyTrainerHub.Core.Domain.Entities;

namespace MyTrainerHub.Infrastructure.DatabaseContext
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }
    }
}
