using AcmeCorp.ContactInfo.Entities.BO;
using AcmeCorp.ContactInfo.Entities.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.ContactInfo.Abstract.Services
{
    public interface IOrderDBService
    {
        Task<string> CreateOrderAsync(OrderDBO value);
        Task<OrderDBO> GetOrderAsync(string id);
        Task<List<OrderDBO>> GetOrders(int pagesize, int pageNumber);
        Task UpdateOrderAsync(OrderDBO value);
    }
}
