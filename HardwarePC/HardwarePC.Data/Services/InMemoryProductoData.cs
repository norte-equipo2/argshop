using HardwarePC.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwarePC.Data.Services
{
    public class InMemoryProductoData : IProductoData
    {

        private static List<Producto> productos;

        public InMemoryProductoData()
        {
            if (productos is null)
            {

                productos = new List<Producto>

            {
            new Producto() { Id = 1, Name = "Acer Aspire E 15", Category = "A"},
            new Producto() { Id = 2, Name = "WD M2 Blue 240gb", Category = "B" },
            new Producto() { Id = 3, Name = "Teclado Logitech", Category = "C" }
            };
            }
        }

        public IEnumerable<Producto> GetAll()
        {
            return productos.OrderBy(o => o.Name);
        }

        public void Insert(Producto objProducto)
        {
            productos.Add(objProducto);
        }

        public void Update(Producto objProducto)
        {
            throw new NotImplementedException();
        }
    }
}
