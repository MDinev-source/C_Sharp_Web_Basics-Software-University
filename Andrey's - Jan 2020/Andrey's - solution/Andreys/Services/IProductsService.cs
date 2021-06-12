﻿namespace Andreys.Services
{
    using Andreys.ViewModels.Products;
    using System.Collections.Generic;

    interface IProductService
    {
        int Add(string name, string description, string imageUrl, decimal price, string category, string gendetr);
        IEnumerable<ProductsHomeViewModel> GetAll();
        ProductDetailsViewModel GetProduct(int id);
        void DeleteById(int id);
    }
}