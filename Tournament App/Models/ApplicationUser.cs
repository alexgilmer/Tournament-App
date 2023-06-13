using Microsoft.AspNetCore.Identity;

namespace Tournament_App.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Self properties

        // FK properties
        public Guid? TeamId { get; set; }

        // Navigation properties
        public virtual Team? Team { get; set; }
    }
}
