namespace CarShop.Data.Models
{
    using SUS.MvcFramework;
    using System;
    public class User : IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public bool IsMechanic { get; set; }
    }
}
