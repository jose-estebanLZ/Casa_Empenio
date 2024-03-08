using CasaEmpeñoModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaEmpeñoRepository.TipoProductoRepository
{
    public class ProductTypeRepository
    {
        public List<TipoProducto> GetAll()
        {
            using (var context = new CasaEmpeñoEntities())
            {
                return context.TipoProducto
                    .ToList();
            }
        }
    }
}
