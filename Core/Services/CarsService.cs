using AutoMapper;
using Core.Dtos;
using Core.Exceptions;
using Core.Interfaces;
using Data.Data;
using Data.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CarsService : ICarsService
    {
        private readonly CarsDbContext ctx;
        private readonly IMapper mapper;
        private readonly IValidator<CreateCarsDto> validator;

        public CarsService(CarsDbContext ctx, IMapper mapper, IValidator<CreateCarsDto> validator)
        {
            this.ctx = ctx;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task Archive(int id)
        {
            var product = await ctx.Cars.FindAsync(id);
            if (product == null)
                throw new HttpException("Product not found!", HttpStatusCode.NotFound);

            product.Archived = true;
            await ctx.SaveChangesAsync();
        }

        public async Task Create(CreateCarsDto model)
        {
            // TODO: validate model
            //validator.ValidateAndThrow(model);

            ctx.Cars.Add(mapper.Map<Cars>(model));
            await ctx.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var product = await ctx.Cars.FindAsync(id);
             if (product == null)
                throw new HttpException("Product not found!", HttpStatusCode.NotFound);

            ctx.Cars.Remove(product);
            await ctx.SaveChangesAsync();
        }

        public async Task Edit(EditCarsDto model)
        {
            // TODO: validate model

            ctx.Cars.Update(mapper.Map<Cars>(model));
            await ctx.SaveChangesAsync();
        }

        public async Task<CarsDto?> Get(int id)
        {
            var product = await ctx.Cars.FindAsync(id);
            if (product == null) 
                throw new HttpException("Product not found!", HttpStatusCode.NotFound);

            // load related table data
            await ctx.Entry(product).Reference(x => x.Category).LoadAsync();

            return mapper.Map<CarsDto>(product);
        }

        public async Task<IEnumerable<CarsDto>> GetAll()
        {
            return mapper.Map<List<CarsDto>>(await ctx.Cars.ToListAsync());
        }

        public async Task Restore(int id)
        {
            var product = await ctx.Cars.FindAsync(id);
            if (product == null) 
                throw new HttpException("Product not found!", HttpStatusCode.NotFound);

            product.Archived = false;
            await ctx.SaveChangesAsync();
        }
    }
}
