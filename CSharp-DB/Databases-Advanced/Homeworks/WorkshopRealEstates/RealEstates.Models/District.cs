﻿using System.Collections.Generic;

namespace RealEstates.Models
{
    public class District
    {
        public District()
        {
            this.Properties = new HashSet<Property>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Property>Properties { get; set; }
    }
}