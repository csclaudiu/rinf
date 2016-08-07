using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessModels;
using System.Runtime.Caching;

namespace wAPI.DAL
{
    public class ProductRepository : IProductRepository
    {

        private ObjectCache TempRepository = MemoryCache.Default;

        public void DeleteProduct(Guid productID)
        {
            TempRepository.Remove(productID.ToString());
        }

        public Product GetProductByID(Guid ProductId)
        {
            return (Product)TempRepository.Get(ProductId.ToString());
        }

        public IEnumerable<Product> GetProducts()
        {
            return TempRepository.Select(p => (Product)p.Value).ToList();
        }

        public void InsertProduct(Product product)
        {
            TempRepository.AddOrGetExisting(product.id.ToString(), product, new CacheItemPolicy());
        }

        public bool ProductExists(Guid ProductId)
        {
            return TempRepository.Contains(ProductId.ToString());
        }

        public void UpdateProduct(Product product)
        {
            TempRepository.Remove(product.id.ToString());
            TempRepository.Add(product.id.ToString(), product, new CacheItemPolicy());
        }
    }
}