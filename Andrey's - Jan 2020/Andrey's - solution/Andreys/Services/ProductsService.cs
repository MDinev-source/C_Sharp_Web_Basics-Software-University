namespace Andreys.Services
{
    using System;
    using System.Collections.Generic;
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
                Name=name,
                Description=description,
                ImageUrl=imageUrl,
                Price=price,
                Category=Enum.Parse<Category>(category),
                Gender=Enum.Parse<Gender>(gender)
            }
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductsHomeViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public ProductDetailsViewModel GetProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}
