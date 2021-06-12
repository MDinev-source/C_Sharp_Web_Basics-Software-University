namespace Andreys.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    interface IProductService
    {
        int Add(string name, string description, string imageUrl, decimal price, string category, string gendetr);
    }
}
