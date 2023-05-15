using AcmeCorp.ContactInfo.Entities.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.ContactInfo.Entities.DBO
{
    public class OrderDBO : OrderBO
    {
        public ContactDBO Contact { get; set; }
    }
}
