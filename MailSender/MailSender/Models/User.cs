using Microsoft.AspNetCore.Identity;

namespace MailSender.Models
{
    public class User : IdentityUser
    {
        public User() { }

        public User(string email, string name) =>
            (Email, UserName) = (email, name);
    }
}
