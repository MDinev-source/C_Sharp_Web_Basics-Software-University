namespace SharedTrip.Models
{
    using SUS.MvcFramework;
    using System;
    using System.Collections.Generic;
    public class User : IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.UserTrips = new HashSet<UserTrip>();
        }
        public ICollection<UserTrip> UserTrips { get; set; }
    }
}
