using SUS.MvcFramework;
using System;
using System.Collections.Generic;

namespace Git.Data.Models
{
    public class User : IdentityUser<string>
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            Repositories = new HashSet<Repository>();
            Commits = new HashSet<Commit>();
        }

        public IEnumerable<Repository> Repositories { get; set; }

        public IEnumerable<Commit> Commits { get; set; }
    }
}
