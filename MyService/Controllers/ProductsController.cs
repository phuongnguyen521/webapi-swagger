using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyService.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly MyStockContext context;
        public ProductsController(MyStockContext context) => this.context = context;

        //GET: api/Products
        [HttpGet] //Get all products
        public IEnumerable<Product> GetProducts() => context.Products.ToList();

        //POST: api/Products
        [HttpPost]
        public void PostProduct (Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        //DELETE: api/Products/5
        [HttpDelete("{id}")]
        public void DeleteProducts (int id)
        {
            var product = context.Products.Find(id);
            if (product is not null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }

        }
    }
}
