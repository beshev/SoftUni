using SUS.MvcFramework;
using System;
using System.Collections.Generic;

namespace CarShop.Data.Models
{
    public class User : IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Cars = new HashSet<Car>();
        }

        public bool IsMechanic { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}

