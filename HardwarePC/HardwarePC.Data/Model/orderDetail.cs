using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwarePC.Data.Model
{
    public class orderDetail : IdentityBase
    {
        public int orderId;
        public int productId;
        public float price;
        public int quantity;
        public virtual Order order { get; set; }
    }
}
