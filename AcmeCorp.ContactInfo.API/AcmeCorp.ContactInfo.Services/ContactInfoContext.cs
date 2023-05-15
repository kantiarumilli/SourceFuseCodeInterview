using AcmeCorp.ContactInfo.Entities;
using AcmeCorp.ContactInfo.Entities.DBO;
using Microsoft.EntityFrameworkCore;

namespace AcmeCorp.ContactInfo.Services
{
    public class ContactInfoContext : DbContext
    {
        public ContactInfoContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ContactDBO> Contacts { get; set; }
        public DbSet<OrderDBO> Order { get; set; }
    }
}