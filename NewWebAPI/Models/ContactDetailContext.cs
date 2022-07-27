using Microsoft.EntityFrameworkCore;

namespace NewWebAPI.Models
{
    public class ContactDetailContext : DbContext
    {
        public ContactDetailContext(DbContextOptions<ContactDetailContext> options)
            : base(options)
        {
        }
        public DbSet<ContactDetailItem> ContactDetails { get; set; } = default!;

    }
}
