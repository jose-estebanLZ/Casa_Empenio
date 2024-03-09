using CasaEmpeñoModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaEmpeñoRepository.OfertaProductoRepository
{
    public class ProductOfferRepository
    {
        public int Add(OfertaProducto productOffer)
        {
            using (var context = new CasaEmpeñoEntities())
            {
                context.OfertaProducto.Add(productOffer);
                context.SaveChanges();

                return context.OfertaProducto.Max(x => x.OfertaProductoId);
            }
        }

        public List<OfertaProducto> GetOfferListByProductId(int productId)
        {
            using (var context = new CasaEmpeñoEntities())
            {
                return context.OfertaProducto
                    .Where(x => x.ProductoId == productId)
                    .ToList();
            }
        }

    }
}
