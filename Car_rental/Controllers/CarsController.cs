﻿using AutoMapper;
using Core.Dtos;
using Core.Interfaces;
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
        private readonly ICarsService carsService;

        public CarsController(ICarsService carsService)
        {
            this.carsService = carsService;
        }

        // [C]reate [R]ead [U]pdate [D]elete

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await carsService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await carsService.Get(id));
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await carsService.GetCategories());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarsDto model)
        {
            await carsService.Create(model);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit(EditCarsDto model)
        {
            await carsService.Edit(model);
            return Ok();
        }

        [HttpPatch("archive")]
        public async Task<IActionResult> Archive(int id)
        {
            await carsService.Archive(id);
            return Ok();
        }

        [HttpPatch("restore")]
        public async Task<IActionResult> Restore(int id)
        {
            await carsService.Restore(id);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
             await carsService.Delete(id);
            return Ok();
        }
    }
}
