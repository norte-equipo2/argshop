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

        private List<Producto> productos;

        public InMemoryProductoData()
        {
            productos = new List<Producto>
            {
            new Producto() { Id = 1, Name = "Acer Aspire E 15", Category = CategoryType.Notebooks},
            new Producto() { Id = 2, Name = "WD M2 Blue 240gb", Category = CategoryType.Almacenamiento },
            new Producto() { Id = 3, Name = "Teclado Logitech", Category = CategoryType.Periféricos }
            };
        }
        
        public IEnumerable<Producto> GetAll()
        {
            return productos.OrderBy(o => o.Name);
        }
    }
}
