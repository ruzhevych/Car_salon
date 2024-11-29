using AutoMapper;
using Core.Dtos;
using Core.Exceptions;
using Core.Interfaces;
using Data.Data;
using Data.Entities;
using Data.Repositories;
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
        //private readonly CarsDbContext ctx;

        private readonly IMapper mapper;
        private readonly IValidator<CreateCarsDto> validator;
        private readonly IRepository<Cars> carsR;
        private readonly IRepository<Category> categoryR;

        public CarsService(CarsDbContext ctx, IMapper mapper, IValidator<CreateCarsDto> validator, IRepository<Cars> carsR, IRepository<Category> categoryR)
        {
            this.mapper = mapper;
            this.validator = validator;
            this.carsR = carsR;
            this.categoryR = categoryR;
        }

        public async Task Archive(int id)
        {
            var product = await carsR.GetById(id);
            if (product == null)
                throw new HttpException("Product not found!", HttpStatusCode.NotFound);

            product.Archived = true;
            await carsR.Save();
        }

        public async Task Create(CreateCarsDto model)
        {
            // TODO: validate model
            //validator.ValidateAndThrow(model);

            await carsR.Insert(mapper.Map<Cars>(model));
            await carsR.Save();
        }

        public async Task Delete(int id)
        {
            var product = await carsR.GetById(id);
             if (product == null)
                throw new HttpException("Product not found!", HttpStatusCode.NotFound);

            await carsR.Delete(product);
            await carsR.Save();
        }

        public async Task Edit(EditCarsDto model)
        {
            // TODO: validate model

            await carsR.Update(mapper.Map<Cars>(model));
            await carsR.Save();
        }

        public async Task<CarsDto?> Get(int id)
        {
            var product = await carsR.GetById(id);
            if (product == null) 
                throw new HttpException("Product not found!", HttpStatusCode.NotFound);

            // load related table data
            // await ctx.Entry(product).Reference(x => x.Category).LoadAsync();

            return mapper.Map<CarsDto>(product);
        }

        public async Task<IEnumerable<CarsDto>> GetAll()
        {
            return mapper.Map<List<CarsDto>>(await carsR.Get(includeProperties: "Category"));
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            return mapper.Map<IEnumerable<CategoryDto>>(await categoryR.GetAll());
        }


        public async Task Restore(int id)
        {
            var product = await carsR.GetById(id);
            if (product == null) 
                throw new HttpException("Product not found!", HttpStatusCode.NotFound);

            product.Archived = false;
            await carsR.Save();
        }
    }
}
