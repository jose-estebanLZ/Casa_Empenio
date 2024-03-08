using CasaEmpeñoModel.Models;
using CasaEmpeñoModel.ViewModels;
using CasaEmpeñoRepository.ProductoRepository;
using CasaEmpeñoRepository.TransaccionRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaEmpeñoService.ProductService
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;
        private readonly TransactionRepository _transactionRepository;
        public ProductService()
        {
            _productRepository = new ProductRepository();
            _transactionRepository = new TransactionRepository();
        }

        public void AddTransaction(int productId, int typeTransaction)
        {
            var product = _productRepository.Get(productId);

            var transaction = new Transaccion()
            {
                ProductoId = productId,
                FechaHoraTransaccion = DateTime.Now,
                Monto = typeTransaction == 3 ? product.CostoVenta : product.CostoCompra,
                TipoTransaccionId = typeTransaction
            };

            _transactionRepository.Add(transaction);
        }

        public int Add(ProductViewModel product)
        {
            var ganancia = product.CostoCompra * 0.25m;

            var productModel = new Producto
            {
                ProductoId = product.ProductoId,
                TipoProductoId = product.TipoProductoId,
                EstadoProductoId = product.EstadoProductoId,
                Nombre = product.Nombre,
                FechaIngreso = product.FechaIngreso,
                CostoCompra = product.CostoCompra,
                CostoVenta = product.CostoCompra + ganancia,
                HoraDevolucion = product.HoraDevolucion
            };

            return _productRepository.Add(productModel);             
        }
    }
}
