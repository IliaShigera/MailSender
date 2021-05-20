using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MailSender.Models
{
    public class AppContext : IdentityDbContext<User>
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options) =>
            Database.EnsureCreated();
    }
}
