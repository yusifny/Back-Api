using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi_1.Data.DAL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        // private static readonly List<Product> Products = new List<Product>()
        // {
        //     new Product{Id=1, Name = "Product1", Price = 10},
        //     new Product{Id=2, Name = "Product2", Price = 20},
        //     new Product{Id=3, Name = "Product3", Price = 30},
        //     new Product{Id=4, Name = "Product4", Price = 40}
        // };

        //[Route("all")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return StatusCode(200, _context.Products.ToList());
        }
        //[Route("one")]
        [HttpGet("{id:int}")]
        public IActionResult GetOne(int id)
        {
            Product product = _context.Products.FirstOrDefault(p=> p.Id == id);
            if (product == null) return NotFound();
            return StatusCode(200, product);
        }

        [HttpPost("")]
         public IActionResult Add(Product product)
         {
             Product newProduct = new Product();
             newProduct.Name = product.Name;
             newProduct.Price = product.Price;

             _context.Add(newProduct);
             _context.SaveChanges();
             
             return StatusCode(201, $"{product.Name} adlı məhsul əlavə olundu.");
         }
         
         [HttpDelete("{id:int}")]
         public IActionResult Delete(int id)
         {
             Product product = _context.Products.FirstOrDefault(p=> p.Id == id);
             if (product == null) return NotFound();
             _context.Remove(product);
             _context.SaveChanges();
             return StatusCode(209, $"{product.Name} adlı məhsul silindi.");
         }
    }
}

