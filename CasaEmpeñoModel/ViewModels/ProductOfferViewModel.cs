using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaEmpeñoModel.ViewModels
{
    public class ProductOfferViewModel
    {
        public int OfertaProductoId { get; set; }
        public int ProductoId { get; set; }
        public string NombreCliente { get; set; }
        public string Telefono { get; set; }
        public decimal Monto { get; set; }
    }
}
