namespace Git.Data.Models
{
    using SUS.MvcFramework;
    using System;
    using System.Collections.Generic;
    public class User : IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Repositories = new HashSet<Repository>();
            this.Commits = new HashSet<Commit>();
        }
        public ICollection<Repository> Repositories { get; set; }
        public ICollection<Commit> Commits { get; set; }
    }
}
