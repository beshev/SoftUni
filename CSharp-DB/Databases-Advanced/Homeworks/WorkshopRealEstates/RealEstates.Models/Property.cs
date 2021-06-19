using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstates.Models
{
    public class Property
    {
        public Property()
        {
            Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }

        public int Size { get; set; }

        public int? YardSize { get; set; }

        public byte? Floor { get; set; }

        public byte? TotalFloors { get; set; }

        public int DistrictId { get; set; }
        public District District { get; set; }

        public int? Year { get; set; }

        public int TypeId { get; set; }
        public virtual PropertyType Type { get; set; }

        public int BuildingTypeId { get; set; }
        public virtual Building BuildingType { get; set; }

        public int? Price { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
