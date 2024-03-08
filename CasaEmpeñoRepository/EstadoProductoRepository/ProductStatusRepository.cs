using CasaEmpeñoModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaEmpeñoRepository.EstadoProductoRepository
{
    public class ProductStatusRepository
    {
        public List<EstadoProducto> GetAll()
        {
            using (var context = new CasaEmpeñoEntities())
            {
                return context.EstadoProducto
                    .ToList();
            }
        }
    }
}
