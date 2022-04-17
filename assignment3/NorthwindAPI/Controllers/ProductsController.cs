using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Models;

namespace NorthwindAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly northwindContext _context;

        public ProductsController(northwindContext context)
        {
            _context = context;
        }

        // GET: api/Products/5
        [HttpGet("ByCategory/{category}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(int category)
        {
            List<Product> products = await (from _prods in _context.Products
                                            where (_prods.CategoryId == category && !_prods.Discontinued)
                                            select _prods).ToListAsync();
            if (products == null || products.Count == 0)
            {
                return NotFound();
            }
            return products;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await (from prods in _context.Products where !prods.Discontinued select prods).ToListAsync();
        }

    }
}
