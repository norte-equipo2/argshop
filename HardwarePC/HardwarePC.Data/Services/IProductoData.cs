using HardwarePC.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwarePC.Data.Services
{
    public interface IProductoData
    {
        IEnumerable<Producto> GetAll();
    }
}
