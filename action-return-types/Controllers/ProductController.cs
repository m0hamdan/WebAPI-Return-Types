using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using action_return_types.Models;

namespace action_return_types.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        [HttpGet("single/{id}")]
        public Product GetProduct(int id)
        {
            return new Product { Id = id, Name = $"Product {id}" };
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id <= 0)
            {
                return ValidationProblem(detail: "invalid id");
            }
            if (id < 100)
            {
                return Ok(new Product { Id = id, Description = $"Description {id}", Name = $"Product {id}", Price = id * 1.5 });
            }


            return NotFound();

        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public async Task<ActionResult<Product>> CreateProduct(Product newProduct)
        {
            if (newProduct.Id > 0)
            {
                return BadRequest();
            }
            //simulate add to repo
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            return newProduct;
        }
    }
}
