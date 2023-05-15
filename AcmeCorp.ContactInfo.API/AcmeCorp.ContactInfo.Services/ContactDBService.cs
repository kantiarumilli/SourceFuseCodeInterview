using AcmeCorp.ContactInfo.Abstract.Services;
using AcmeCorp.ContactInfo.Entities.DBO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.ContactInfo.Services
{
    public class ContactDBService : IContactDBService
    {
        private readonly ContactInfoContext contactInfoContext;

        public ContactDBService(ContactInfoContext contactInfoContext)
        {
            this.contactInfoContext = contactInfoContext;
        }

        public async Task<string> CreateContactAsync(ContactDBO dbEntity)
        {
            dbEntity.Id = Guid.NewGuid().ToString();
            await contactInfoContext.Contacts.AddAsync(dbEntity);
            await contactInfoContext.SaveChangesAsync();

            return dbEntity.Id;
        }

        public async Task DeleteContactAsync(string id)
        {
            var c = await GetContactAsync(id);

            if (c != null)
            {
                c.IsDeleted = true;
                await contactInfoContext.SaveChangesAsync();
            }
        }

        public async Task<ContactDBO> GetContactAsync(string id)
        {
            return await contactInfoContext.Contacts.SingleOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
        }

        public IEnumerable<ContactDBO> GetContacts(int pagesize, int pageNumber)
        {
            return contactInfoContext.Contacts.Where(c => !c.IsDeleted).OrderBy(c => c.Name).Skip((pageNumber - 1) * pagesize).Take(pagesize);
        }

        public async Task UpdateContactAsync(ContactDBO dbEntity)
        {
            var c = await GetContactAsync(dbEntity.Id);
            if (c != null)
            {
                c = dbEntity;
                await contactInfoContext.SaveChangesAsync();
            }
        }
    }
}
