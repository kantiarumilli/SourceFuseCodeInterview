using AcmeCorp.ContactInfo.Entities.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.ContactInfo.Abstract.Services
{
    public interface IContactDBService
    {
        Task<string> CreateContactAsync(ContactDBO dbEntity);
        Task DeleteContactAsync(string id);
        Task<ContactDBO> GetContactAsync(string id);
        IEnumerable<ContactDBO> GetContacts(int pagesize, int pageNumber);
        Task UpdateContactAsync(ContactDBO dbEntity);
    }
}
