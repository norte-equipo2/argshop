using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwarePC.Data.Model
{
    public class Order : IdentityBase
    {
        public string userId;
        public DateTime orderDate;
        public float totalPrice;
        public int orderNumber;
        public int itemCount;

        public virtual ICollection<orderDetail> orderDetail { get; set; }
    }
}
