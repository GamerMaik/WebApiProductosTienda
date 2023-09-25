using ENTIDADES;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<EProduct> GetPerson(int id)
        {
            // var product = _personService.GetPersonById(id);
            return Ok();
        }

        [HttpPost]
        public ActionResult<EProduct> AddPerson([FromBody] EProduct product)
        {
            if (product == null)
            {
                return BadRequest("Invalid data");
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePerson(int id, [FromBody] EProduct product)
        {
            if (product == null)
            {
                return BadRequest("Invalid data");
            }

            bool updated = true;
            //var updated = _personService.UpdatePerson(person);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            bool deleted = true;
            //var deleted = _personService.DeletePerson(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }

}