using HardwarePC.Data.Model;
using HardwarePC.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace HardwarePC.WebSite.Controllers
{
    public class OrderController : BaseController
    {
        // GET: Shop
        private readonly BaseDataService<CartItem> MyContext = new BaseDataService<CartItem>();
        private readonly ArtShopDbContext db = new ArtShopDbContext();

        [Authorize]
        public ActionResult Index(int CartId)
        {
            
            var order = new Order
            {
                orderDate = DateTime.Now,
                totalPrice = 5000,
                itemCount = 40,
                userId = "asd",
                orderNumber = 1
            };
            this.CheckAuditPattern(order, true);
            var orderDet = new orderDetail
            {
                price = (float)MyContext.GetById(CartId).Price,
                productId = MyContext.GetById(CartId).ProductId,
                quantity = MyContext.GetById(CartId).Quantity,
            };
            this.CheckAuditPattern(orderDet, true);
            order.orderDetail = new List<orderDetail>() { orderDet };
            db.Order.Add(order);
            db.SaveChanges();
            return View();
        }        
    }
}