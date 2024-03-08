using CasaEmpeñoModel.ViewModels;
using CasaEmpeñoRepository.EstadoProductoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaEmpeñoService.ProductStatusService
{
    public class ProductStatusService
    {
        private readonly ProductStatusRepository _productStatusRepository;
        public ProductStatusService()
        {
            _productStatusRepository = new ProductStatusRepository();
        }

        public List<ProductStatusViewModel> GetAll() =>
            _productStatusRepository
                .GetAll()
                .Select(x => new ProductStatusViewModel()
                {
                    EstadoProductoId = x.EstadoProductoId,
                    Nombre = x.Nombre
                })
                .ToList();
    }
}
