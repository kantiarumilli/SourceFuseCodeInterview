using AcmeCorp.ContactInfo.Abstract.Facade;
using AcmeCorp.ContactInfo.Abstract.Services;
using AcmeCorp.ContactInfo.Entities.BO;
using AcmeCorp.ContactInfo.Entities.DBO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.ContactInfo.Facade
{
    public class OrderFacade : IOrderFacade
    {
        private readonly IOrderDBService orderDBService;
        private readonly IMapper mapper;

        public OrderFacade(IOrderDBService orderDBService, IMapper mapper)
        {
            this.orderDBService = orderDBService;
            this.mapper = mapper;
        }

        public async Task<string> CreateOrderAsync(OrderBO value)
        {
            if (value != null && String.IsNullOrEmpty(value.Id)) return string.Empty;

            return await orderDBService.CreateOrderAsync(mapper.Map<OrderDBO>(value));
        }

        public async Task<OrderBO> GetOrderAsync(string id)
        {
            if (String.IsNullOrEmpty(id)) return null;

            var returnVal = await orderDBService.GetOrderAsync(id);
            if (returnVal != null) return mapper.Map<OrderBO>(returnVal);

            return null;
        }

        public async Task<IEnumerable<OrderBO>> GetOrdersAsync(int pagesize, int pageNumber)
        {
            if (pagesize < 0 || pageNumber < 0 || pagesize > 500) return null;

            var retVal = await orderDBService.GetOrders(pagesize, pageNumber);
            if (retVal == null) return null;

            return mapper.Map<IEnumerable<OrderBO>>(retVal);
        }

        public async Task UpdateOrderAsync(OrderBO value)
        {
            if (String.IsNullOrEmpty(value.Id)) return;
            await orderDBService.UpdateOrderAsync(mapper.Map<OrderDBO>(value));
        }
    }
}
