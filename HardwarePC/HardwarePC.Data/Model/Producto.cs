using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwarePC.Data.Model
{
    public class Producto : IdentityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int MarcaId { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int QuantitySold { get; set; }
        public double AvgStars { get; set; }

        //Metodo virtual para poder sobrescribir
        public virtual Marca Marca { get; set; }
    }
}
