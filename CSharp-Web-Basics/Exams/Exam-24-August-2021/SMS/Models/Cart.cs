using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Models
{
    public class Cart
    {
        public Cart()
        {
            this.Products = new HashSet<Product>();
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
