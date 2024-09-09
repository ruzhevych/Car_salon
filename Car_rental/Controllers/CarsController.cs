using Data.Data;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car_rental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarsDbContext ctx;

        public CarsController(CarsDbContext ctx)
        {
            this.ctx = ctx;
        }

        // [C]reate [R]ead [U]pdate [D]elete

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(ctx.Cars.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = ctx.Cars.Find(id);
            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create(Cars model)
        {
            if (!ModelState.IsValid) return BadRequest();

            ctx.Cars.Add(model);
            ctx.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Edit(Cars model)
        {
            if (!ModelState.IsValid) return BadRequest();

            ctx.Cars.Update(model);
            ctx.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var product = ctx.Cars.Find(id);
            if (product == null) return NotFound();

            ctx.Cars.Remove(product);
            ctx.SaveChanges();

            return Ok();
        }
    }
}
