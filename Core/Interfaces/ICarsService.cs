using Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICarsService
    {
        Task<IEnumerable<CategoryDto>> GetCategories();
        Task<IEnumerable<CarsDto>> GetAll();
        Task<CarsDto?> Get(int id);
        Task Edit(EditCarsDto model);
        Task Create(CreateCarsDto model);
        Task Delete(int id);
        Task Archive(int id);
        Task Restore(int id);
    }
}
