using CasaEmpeñoModel.Models;
using CasaEmpeñoModel.SPModels;
using CasaEmpeñoModel.ViewModels;
using CasaEmpeñoRepository.OfertaProductoRepository;
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
        private readonly ProductOfferRepository _productOfferRepository;
        public ProductService()
        {
            _productRepository = new ProductRepository();
            _transactionRepository = new TransactionRepository();
            _productOfferRepository = new ProductOfferRepository();
        }

        public void AddTransaction(int productId, int typeTransaction, decimal? amount = 0)
        {
            var product = _productRepository.Get(productId);

            if(amount == 0)
            {
                amount = typeTransaction == 3 ? product.CostoVenta : product.CostoCompra;
            }

            var transaction = new Transaccion()
            {
                ProductoId = productId,
                FechaHoraTransaccion = DateTime.Now,
                Monto = amount,
                TipoTransaccionId = typeTransaction
            };

            _transactionRepository.Add(transaction);
        }

        public int AddProductOffer(ProductOfferViewModel productOffer)
        {
            var offer = new OfertaProducto()
            {
                ProductoId = productOffer.ProductoId,
                NombreCliente = productOffer.NombreCliente,
                Telefono = productOffer.Telefono,
                Monto = productOffer.Monto
            };

            return _productOfferRepository.Add(offer);
        }

        public bool IsLargestOffer(int productOfferId, int productId)
        {
            var lstProductOffer = _productOfferRepository.GetOfferListByProductId(productId);

            var maxOffer = lstProductOffer
                .OrderByDescending(x => x.Monto)
                .First();

            return maxOffer.OfertaProductoId == productOfferId;
        }

        public void MakeSale(int productId)
        {
            var lstProductOffer = _productOfferRepository.GetOfferListByProductId(productId);

            if (lstProductOffer.Count < 3)
            {
                return;
            }

            var maxOffer = lstProductOffer
                .OrderByDescending(x => x.Monto)
                .First();

            AddTransaction(productId, 3, maxOffer.Monto);
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

        public List<GetListProducts> GetGrid() => _productRepository.GetGrid();
    }
}
