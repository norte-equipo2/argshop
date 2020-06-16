using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwarePC.Data.Model
{
    public class Producto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryType Category { get; set; }
    }
}
