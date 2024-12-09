using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBAPI_LAB3.DTOs.CatalogDTOs;
using WEBAPI_LAB3.DTOs.ProductDTOs;
using WEBAPI_LAB3.Models;

namespace WEBAPI_LAB3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        ProductContext db;
        public CatalogController(ProductContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult getAll()
        {
            List<Catalog> catalogs = db.Catalog.ToList();
            List<DisplayCatalog> catalogsDTO = new List<DisplayCatalog>();
            foreach (Catalog c in catalogs)
            {
                DisplayCatalog catalogDTO = new DisplayCatalog()
                {
                    Name = c.Name,
                    Description = c.Description,
                    productname = c.Products.Select(n => n.Name).ToList()
                };
                catalogsDTO.Add(catalogDTO);
            }
            return Ok(catalogsDTO);
        }

        [HttpGet("{id}")]
        public IActionResult getbyid(int id)
        {
            Catalog c = db.Catalog.Where(n => n.Id == id).FirstOrDefault();
            if (c == null) return NotFound();
            else
            {
                DisplayCatalog cDTO = new DisplayCatalog()
                {
                    Name = c.Name,
                    Description = c.Description,
                    productname = c.Products.Select(n => n.Name).ToList()
                };
                return Ok(cDTO);
            }
        }
    }
}
