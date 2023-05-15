using AcmeCorp.ContactInfo.Abstract.Services;
using AcmeCorp.ContactInfo.Entities.BO;
using AcmeCorp.ContactInfo.Entities.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.ContactInfo.Services
{
    public class OrderDBService : IOrderDBService
    {
        private readonly ContactInfoContext contactInfoContext;

        public OrderDBService(ContactInfoContext contactInfoContext)
        {
            this.contactInfoContext = contactInfoContext;
        }
        public async Task<string> CreateOrderAsync(OrderDBO value)
        {
            value.Id = Guid.NewGuid().ToString();

            contactInfoContext.Order.Add(value);
            await contactInfoContext.SaveChangesAsync();

            return value.Id;
        }

        public async Task<OrderDBO> GetOrderAsync(string id)
        {
            return await contactInfoContext.Order.FindAsync(id);
        }

        public Task<List<OrderDBO>> GetOrders(int pagesize, int pageNumber)
        {
            return Task.FromResult(contactInfoContext.Order.Skip((pageNumber - 1) * pagesize).Take(pagesize).ToList());
        }

        public async Task UpdateOrderAsync(OrderDBO value)
        {
            var result = await contactInfoContext.Order.FindAsync(value.Id);
            result = value;
            await contactInfoContext.SaveChangesAsync();
        }
    }
}
