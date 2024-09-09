﻿using AutoMapper;
using Core.Dtos;
using Data.Data;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Car_rental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarsDbContext ctx;
        private readonly IMapper mapper;

        public CarsController(CarsDbContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        // [C]reate [R]ead [U]pdate [D]elete

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var items = mapper.Map<List<CarsDto>>(ctx.Cars.ToList());
            return Ok(items);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = ctx.Cars.Find(id);
            if (product == null) return NotFound();

            ctx.Entry(product).Reference(x => x.Category).Load();

            return Ok(mapper.Map<CarsDto>(product));
        }

        [HttpPost]
        public IActionResult Create(CreateCarsDto model)
        {
            if (!ModelState.IsValid) return BadRequest();

            ctx.Cars.Add(mapper.Map<Cars>(model));
            ctx.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public IActionResult Edit(EditCarsDto model)
        {
            if (!ModelState.IsValid) return BadRequest();

            ctx.Cars.Update(mapper.Map<Cars>(model));
            ctx.SaveChanges();

            return Ok();
        }

        [HttpPatch("archive")]
        public IActionResult Archive(int id)
        {
            var product = ctx.Cars.Find(id);
            if (product == null) return NotFound();

            product.Archived = true;
            ctx.SaveChanges();

            return Ok();
        }

        [HttpPatch("restore")]
        public IActionResult Restore(int id)
        {
            var product = ctx.Cars.Find(id);
            if (product == null) return NotFound();

            product.Archived = false;
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
