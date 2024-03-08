using CasaEmpeñoModel.ViewModels;
using CasaEmpeñoRepository.TipoProductoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaEmpeñoService.ProductService
{
    public class ProductTypeService
    {
        private readonly ProductTypeRepository _productTypeRepository;
        public ProductTypeService()
        {
            _productTypeRepository = new ProductTypeRepository();
        }

        public List<ProductTypeViewModel> GetAll() =>
            _productTypeRepository
                .GetAll()
                .Select(x => new ProductTypeViewModel()
                {
                    TipoProductoId = x.TipoProductoId,
                    Nombre = x.Nombre
                })
                .ToList();
    }
}
