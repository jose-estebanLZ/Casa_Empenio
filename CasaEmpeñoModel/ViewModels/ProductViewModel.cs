using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaEmpeñoModel.ViewModels
{
    public class ProductViewModel
    {
        public int ProductoId { get; set; }
        public int TipoProductoId { get; set; }
        public int EstadoProductoId { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public decimal? CostoCompra { get; set; }
        public TimeSpan? HoraDevolucion { get; set; }
    }
}
