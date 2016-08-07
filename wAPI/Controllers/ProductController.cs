using System;
using System.Web.Http;
using BusinessModels;
using wAPI.DAL;

namespace wAPI.Controllers
{
    // [Authorize]
    public class ProductController : ApiController
    {
        private IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Product
        public IHttpActionResult Get()
        {
            var result = _repository.GetProducts();
            return Ok(result);
        }

        // GET: api/Product/5
        public IHttpActionResult Get(Guid id)
        {
            if (_repository.ProductExists(id))
                return Ok(_repository.GetProductByID(id));
            else
                return NotFound();
        }

        // POST: api/Product
        public IHttpActionResult Post([FromBody]Product newProduct)
        {
            newProduct.id = Guid.NewGuid();
            _repository.InsertProduct(newProduct);
            return Ok(newProduct);
        }

        // PUT: api/Product/5
        public IHttpActionResult Put(Guid id, [FromBody]Product value)
        {
            if (!_repository.ProductExists(id))
                return NotFound();

            _repository.UpdateProduct(value);
            return Ok(value);
        }

        // DELETE: api/Product/5
        public IHttpActionResult Delete(Guid id)
        {
            if (!_repository.ProductExists(id))
                return NotFound();

            _repository.DeleteProduct(id);
            return Ok();
        }
    }
}
