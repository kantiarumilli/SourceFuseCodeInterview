using AcmeCorp.ContactInfo.Abstract.Facade;
using AcmeCorp.ContactInfo.Entities;
using AcmeCorp.ContactInfo.Entities.BO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AcmeCorp.ContactInfo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInfoController : ControllerBase
    {
        private readonly IContactFacade contactFacade;

        public ContactInfoController(IContactFacade contactFacade)
        {
            this.contactFacade = contactFacade;
        }
        // GET: api/<ContactInfoController>
        [HttpGet]
        public IEnumerable<ContactBO> Get(int pagesize, int pageNumber)
        {
            return contactFacade.GetContacts(pagesize, pageNumber);
        }

        // GET api/<ContactInfoController>/5
        [HttpGet("{id}")]
        public async Task<ContactBO> GetAsync(string id)
        {
            return await contactFacade.GetContactAsync(id);
        }

        // POST api/<ContactInfoController>
        [HttpPost]
        public async Task<string> PostAsync([FromBody] ContactBO value)
        {
            return await contactFacade.CreateContactAsync(value);
        }

        // PUT api/<ContactInfoController>/5
        [HttpPut("{id}")]
        public async Task PutAsync([FromBody] ContactBO value)
        {
            await contactFacade.UpdateContactAsync(value);
        }

        // DELETE api/<ContactInfoController>/5
        [HttpDelete("{id}")]
        public async Task DeleteAsync(string id)
        {
            await contactFacade.DeleteContactAsync(id);
        }
    }
}
