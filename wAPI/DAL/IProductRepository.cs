using BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wAPI.DAL
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProductByID(Guid ProductId);
        void InsertProduct(Product product);
        void DeleteProduct(Guid productID);
        void UpdateProduct(Product product);
        bool ProductExists(Guid ProductId);
    }
}
