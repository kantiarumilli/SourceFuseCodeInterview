using AcmeCorp.ContactInfo.Abstract.Facade;
using AcmeCorp.ContactInfo.Entities.BO;
using Microsoft.AspNetCore.Mvc;

namespace AcmeCorp.ContactInfo.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderFacade orderFacade;

        public OrderController(IOrderFacade orderFacade)
        {
            this.orderFacade = orderFacade;
        }
        [HttpGet]
        public async Task<IEnumerable<OrderBO>> GetAsync(int pagesize, int pageNumber)
        {
            return await orderFacade.GetOrdersAsync(pagesize, pageNumber);
        }

        // GET api/<ContactInfoController>/5
        [HttpGet("{id}")]
        public async Task<OrderBO> GetAsync(string id)
        {
            return await orderFacade.GetOrderAsync(id);
        }

        // POST api/<ContactInfoController>
        [HttpPost]
        public async Task<string> PostAsync([FromBody] OrderBO value)
        {
            return await orderFacade.CreateOrderAsync(value);
        }

        // PUT api/<ContactInfoController>/5
        [HttpPut("{id}")]
        public async Task PutAsync([FromBody] OrderBO value)
        {
            await orderFacade.UpdateOrderAsync(value);
        }

    }
}
