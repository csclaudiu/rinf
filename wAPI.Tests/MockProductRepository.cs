using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModels;
using wAPI.DAL;

namespace wAPI.Tests
{
    public class MockProductRepository : IProductRepository
    {
        private List<Product> _dummy;
        public List<Product> dummy
        {
            get { return _dummy; }
        }

        public MockProductRepository()
        {
            _dummy = new List<Product>();
            for(int i=0; i< 5; i++)
            {
                _dummy.Add(new Product() { id = new Guid(), name = string.Format("Product {0}", i), description = string.Format("Product desc {0}", i) });
            }
        }

        public void DeleteProduct(Guid productID)
        {
            var itemFound = _dummy.Where(p => p.id == productID).FirstOrDefault();
            if(itemFound != null)
            {
                _dummy.Remove(itemFound);
            }
        }

        public Product GetProductByID(Guid ProductId)
        {
            var itemFound = _dummy.Where(p => p.id == ProductId).FirstOrDefault();
            return itemFound;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dummy;
        }

        public void InsertProduct(Product product)
        {
            _dummy.Add(product);
        }

        public bool ProductExists(Guid ProductId)
        {
            return _dummy.Any(d => d.id == ProductId);
        }

        public void UpdateProduct(Product product)
        {
            var itemFound = _dummy.Where(p => p.id == product.id).FirstOrDefault();
            if (itemFound != null)
            {
                itemFound.name = product.name;
                itemFound.description = product.description;
            }
        }
    }
}
