using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaEmpeñoModel.SPModels
{
    public class GetListProducts
    {
        public int ProductId { get; set; }
        public string Nombre { get; set; }
        public string TipoProducto { get; set; }
        public string Estado { get; set; }
        public string FechaIngreso { get; set; }
        public string HoraDevolucion { get; set; }
        public bool SePuedeDevolver { get; set; }
        public bool SePuedeVender { get; set; }
    }
}
