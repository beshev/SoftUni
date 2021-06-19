using RealEstates.Services.Models;
using System.Collections.Generic;

namespace RealEstates.Services
{
    public interface IPropertiesService
    {
        void Add(int size, int YardSize, byte Floor, byte TotalFloors,
            string District, int Year, string Type, string BuildingType, int Price);

        IEnumerable<PropertyInfoDto> Search(int minPrice, int maxPrice, int minSquare, int maxSquare);

        public decimal AveragePricePerSquareMeter(int districtId);

        public double AverageSize(int districtId);

        public IEnumerable<PropertyInfoFullData> GetFullData(int count);

        decimal AveragePricePerSquareMeter();
    }
}
