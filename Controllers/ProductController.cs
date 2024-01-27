using CRUDWithWebAPI.DAL;
using CRUDWithWebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDWithWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MyAppDBContext _context;
        public ProductController(MyAppDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var product = _context.Products.ToList();
                if (product.Count == 0)
                {
                    return NotFound("Products not available.");
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var product = _context.Products.Find(id); 
                if(product == null)
                {
                    return NotFound($"Product details not found with id{id}");
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Product model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
                return Ok("Product Created.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Put(Product model)
        {
            if(model == null || model.Id == 0)
            {
                if (model == null)
                {
                    return BadRequest("Model data is invalid.");
                }
                else if(model.Id == 0)
                {
                    return BadRequest($"Product Id {model.Id} is Invalid");
                }
            }
            try
            {
                    var product = _context.Products.Find(model.Id);
                if(product == null)
                {
                    return NotFound($"Product not found with id {model.Id}");
                }
                product.ProductName = model.ProductName;
                product.Price = model.Price;
                product.Qty = model.Qty;
                _context.SaveChanges();
                return Ok("Product detail updated.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var product =_context.Products.Find(id);
                if (product == null)
                {
                    return NotFound($"Product not found whit id {id}");
                
                }
                _context.Products.Remove(product);
                _context.SaveChanges();
                return Ok("Product details deleted.");
        }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
    }
}
    }
}
