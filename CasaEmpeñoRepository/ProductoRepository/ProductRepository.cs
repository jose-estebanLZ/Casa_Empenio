using CasaEmpeñoModel.Models;
using CasaEmpeñoModel.SPModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaEmpeñoRepository.ProductoRepository
{
    public class ProductRepository
    {
        public Producto Get(int id)
        {
            using (var context = new CasaEmpeñoEntities())
            {
                return context.Producto
                    .Find(id);
            }
        }

        public int Add(Producto product)
        {
            using (var context = new CasaEmpeñoEntities())
            {
                context.Producto.Add(product);
                context.SaveChanges();

                return context.Producto.Max(x => x.ProductoId);
            }
        }

        public void Update(Producto product)
        {
            using (var context = new CasaEmpeñoEntities())
            {
                context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public List<GetListProducts> GetGrid()
        {
            using (var context = new CasaEmpeñoEntities())
            {
                return context.Database
                    .SqlQuery<GetListProducts>("[dbo].[pGetListProducts]")
                    .ToList();
            }
        }
    }
}
