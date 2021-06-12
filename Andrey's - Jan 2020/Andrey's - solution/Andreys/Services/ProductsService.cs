namespace Andreys.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Andreys.Data;
    using Andreys.Models;
    using Andreys.ViewModels.Products;

    public class ProductsService : IProductsService
    {
        private readonly AndreysDbContext db;

        public ProductsService(AndreysDbContext db)
        {
            this.db = db;
        }
        public int Add(string name, string description, string imageUrl, decimal price, string category, string gender)
        {
            var product = new Product
            {
                Name = name,
                Description = description,
                ImageUrl = imageUrl,
                Price = price,
                Category = Enum.Parse<Category>(category),
                Gender = Enum.Parse<Gender>(gender)
            };

            this.db.Products.Add(product);
            db.SaveChanges();
            return product.Id;
        }

        public void DeleteById(int id)
        {
            var product = this.db.Products.Find(id);
            this.db.Products.Remove(product);
            this.db.SaveChanges();
        }

        public IEnumerable<ProductsHomeViewModel> GetAll()
        {
            return this.db.Products
                 .Select(x => new ProductsHomeViewModel
                 {
                     Id=x.Id,
                     Name=x.Name,
                     Price=x.Price,
                     ImageUrl=x.ImageUrl
                 })
                 .ToArray();
        }

        public ProductDetailsViewModel GetProduct(int id)
        {
            return this.db.Products
                .Where(x => x.Id == id)
                .Select(x => new ProductDetailsViewModel
                {
                    Id=x.Id,
                    Name=x.Name,
                    Price=x.Price,
                    Description=x.Description,
                    ImageUrl=x.ImageUrl,
                    Category=x.Category.ToString(),
                    Gender=x.Gender.ToString()
                }).FirstOrDefault();
        }
    }
}
