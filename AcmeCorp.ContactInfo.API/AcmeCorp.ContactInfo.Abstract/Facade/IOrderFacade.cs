using AcmeCorp.ContactInfo.Entities.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.ContactInfo.Abstract.Facade
{
    public interface IOrderFacade
    {
        Task<string> CreateOrderAsync(OrderBO value);
        Task<OrderBO> GetOrderAsync(string id);
        Task<IEnumerable<OrderBO>> GetOrdersAsync(int pagesize, int pageNumber);
        Task UpdateOrderAsync(OrderBO value);
    }
}
