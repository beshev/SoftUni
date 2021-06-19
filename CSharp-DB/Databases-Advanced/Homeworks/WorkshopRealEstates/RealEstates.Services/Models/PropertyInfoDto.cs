using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstates.Services.Models
{
    public class PropertyInfoDto
    {
        public string DistrictName { get; set; }

        public int Size { get; set; }

        public decimal Price { get; set; }

        public string PropertyType { get; set; }

        public string BuildingType { get; set; }
    }
}
