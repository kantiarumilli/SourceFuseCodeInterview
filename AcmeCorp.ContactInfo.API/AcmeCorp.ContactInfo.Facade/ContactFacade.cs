using AcmeCorp.ContactInfo.Abstract.Facade;
using AcmeCorp.ContactInfo.Abstract.Services;
using AcmeCorp.ContactInfo.Entities.BO;
using AcmeCorp.ContactInfo.Entities.DBO;
using AutoMapper;

namespace AcmeCorp.ContactInfo.Facade
{
    public class ContactFacade : IContactFacade
    {
        private readonly IContactDBService contactDBService;
        private readonly IMapper mapper;

        public ContactFacade(IContactDBService contactDBService, IMapper mapper)
        {
            this.contactDBService = contactDBService;
            this.mapper = mapper;
        }

        public async Task<string> CreateContactAsync(ContactBO value)
        {
            if (value == null || !String.IsNullOrEmpty(value.Id)) return string.Empty;

            var dbEntity = mapper.Map<ContactDBO>(value);
            // Any necessary validations
            return await contactDBService.CreateContactAsync(dbEntity);
        }

        public async Task DeleteContactAsync(string id)
        {
            if (String.IsNullOrEmpty(id)) return;

            await contactDBService.DeleteContactAsync(id);
        }

        public async Task<ContactBO> GetContactAsync(string id)
        {
            if (String.IsNullOrEmpty(id)) return null;

            var dbEntity = await contactDBService.GetContactAsync(id);
            return mapper.Map<ContactBO>(dbEntity);
        }

        public IEnumerable<ContactBO> GetContacts(int pagesize, int pageNumber)
        {
            if (pageNumber < 1 || pagesize < 1 || pagesize > 500) return null;

            var dbEntities = contactDBService.GetContacts(pagesize, pageNumber);

            if (dbEntities != null)
                return mapper.Map<IEnumerable<ContactBO>>(dbEntities);

            return null;
        }

        public async Task UpdateContactAsync(ContactBO value)
        {
            if (value == null || String.IsNullOrEmpty(value.Id)) return;

            var dbEntity = mapper.Map<ContactDBO>(value);
            // Any necessary validations
            await contactDBService.UpdateContactAsync(dbEntity);
        }
    }
}