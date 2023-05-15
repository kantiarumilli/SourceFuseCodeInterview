using AcmeCorp.ContactInfo.Entities.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.ContactInfo.Abstract.Facade
{
    public interface IContactFacade
    {
        Task<string> CreateContactAsync(ContactInfo.Entities.BO.ContactBO value);
        Task DeleteContactAsync(string id);
        Task<ContactInfo.Entities.BO.ContactBO> GetContactAsync(string id);
        IEnumerable<ContactInfo.Entities.BO.ContactBO> GetContacts(int pagesize, int pageNumber);
        Task UpdateContactAsync(ContactBO value);
    }
}
