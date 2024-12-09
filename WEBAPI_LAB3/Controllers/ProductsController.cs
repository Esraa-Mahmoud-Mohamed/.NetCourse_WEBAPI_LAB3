using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBAPI_LAB3.DTOs.ProductDTOs;
using WEBAPI_LAB3.Models;

namespace WEBAPI_LAB3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        ProductContext db;
        public ProductsController(ProductContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult getAll()
        {
            List<Product> products = db.Product.ToList();
            List<DisplayProduct> prodsDTO = new List<DisplayProduct>();
            foreach (Product p in products)
            {
                DisplayProduct prodDTO = new DisplayProduct()
                {
                    Name = p.Name,
                    Price = (int)p.Price,
                    Quantity = (int)p.Quantity,
                    catName = p.Catalog.Name
                };
                prodsDTO.Add(prodDTO);
            }
            return Ok(prodsDTO);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            Product p = db.Product.Where(n => n.Id == id).FirstOrDefault();
            if (p == null) return NotFound();
            else
            {
                DisplayProduct proDTO = new DisplayProduct()
                {
                    Name = p.Name,
                    Price = (int)p.Price,
                    Quantity = (int)p.Quantity,
                    catName = p.Catalog.Name
                };
                return Ok(proDTO);
            }
        }

        [HttpPost]
        public IActionResult add(AddProduct proDTO)
        {
            Product p = new Product()
            {
                Name = proDTO.Name,
                Price = proDTO.Price,
                Quantity = proDTO.Quantity,
                catid = proDTO.catid
            };
            db.Product.Add(p);
            db.SaveChanges();

            return Ok();
        }
    }
}
