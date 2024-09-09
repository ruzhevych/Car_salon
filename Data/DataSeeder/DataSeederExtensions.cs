using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataSeeder
{
    public static class DataSeederExtensions
    {
        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new[]
            {
                new Category() { Id = 1, Name = "Sedan" },
                new Category() { Id = 2, Name = "Coupe" },
                new Category() { Id = 3, Name = "Roadster" },
                new Category() { Id = 4, Name = "Convertible" },
                new Category() { Id = 5, Name = "Gran Coupe" },
                new Category() { Id = 6, Name = "Station wagon" },
                new Category() { Id = 7, Name = "Hatchback" },
                new Category() { Id = 8, Name = "Crossover" },
                new Category() { Id = 9, Name = "SUV" },
                new Category() { Id = 10, Name = "Roadster" }
            });
        }

        public static void SeedProducts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cars>().HasData(new List<Cars>()
            {
                new Cars() { Id = 1, Name = "BMW M3 g80", CategoryId = 1, Price = 2500, Quantity = 3, ImageUrl = "https://www.bmw.ua/content/dam/bmw/common/all-models/m-series/m3-sedan/2023/highlights/bmw-3-series-cs-m-automobiles-gallery-impressions-m3-competition-02_890.jpg" },

                new Cars() { Id = 2, Name = "BMW M5 f90", CategoryId = 1, Price = 2200, Quantity = 4, ImageUrl = "https://www.bmw.tj/content/dam/bmw/common/all-models/m-series/m5-sedan/2021/Overview/bmw-m5-cs-onepager-gallery-m5-core-02-wallpaper.jpg" },

                new Cars() { Id = 3, Name = "Mercedes-AMG GT 4-Door Coupé", CategoryId = 2, Price = 5000, Quantity = 1, ImageUrl = "https://img.sm360.ca/ir/w600h400/images/newcar/ca/2023/mercedes-benz/amg-gt-coupe-4-portes/53-4matic-/coupe/2023_mercedes-benz_53-4matic-plus_002.jpg" },

                new Cars() { Id = 4, Name = "Mercedes G-Class", CategoryId = 8, Price = 5000, Quantity = 2, ImageUrl = "https://www.mansory.com/sites/default/files/styles/1920x800_fullwidth_car_slider/public/2021-05/mansory-g63-viva-edition-wb-01.jpg?itok=z01RrRvs" },

                new Cars() { Id = 5, Name = "BMW X5M", CategoryId = 8, Price = 1000, Quantity = 5, ImageUrl = "https://static.tcimg.net/vehicles/primary/b98f3827e42dc106/2024-BMW-X5_M-white-full_color-driver_side_front_quarter.png" },

                new Cars() { Id = 6, Name = "Porsche 911 Turbo S", CategoryId = 2, Price = 5000, Quantity = 1, ImageUrl = "https://www.edelstark.com/fileadmin/_processed_/0/d/csm_Porsche-911-Turbo-S-mieten_588c45ad08.png" },

                new Cars() { Id = 7, Name = "BMW XM", CategoryId = 9, Price = 3000, Quantity = 2, ImageUrl = "https://www.motortrend.com/uploads/2022/09/2023-BMW-XM-1.jpg?w=768&width=768&q=75&format=webp" },

                new Cars() { Id = 8, Name = "Audi RS 6 Avant performance", CategoryId = 6, Price = 3000, Quantity = 2, ImageUrl = "https://finest-rent.de/wp-content/uploads/2023/10/rs6-e1698279154861.png" },
            });
        }
    }
}
