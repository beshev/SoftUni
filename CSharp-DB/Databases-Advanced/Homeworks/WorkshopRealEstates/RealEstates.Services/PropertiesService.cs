using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using RealEstates.Data;
using RealEstates.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RealEstates.Services.Models
{
    public class PropertiesService : BaseService, IPropertiesService
    {
        private readonly ApplicationDbContext dbContext;

        public PropertiesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(int size, int yardSize, byte floor, byte totalFloors, string district, int year,
            string type, string buildingType, int price)
        {
            var property = new Property()
            {
                Size = size,
                YardSize = yardSize <= 0 ? null : yardSize,
                Floor = floor <= 0 ? null : floor,
                TotalFloors = totalFloors <= 0 ? null : totalFloors,
                Year = year <= 0 ? null : year,
                Price = price <= 0 ? null : price
            };

            var dbDistrict = dbContext.Districts.FirstOrDefault(x => x.Name == district);
            if (dbDistrict == null)
            {
                dbDistrict = new District()
                {
                    Name = district
                };
            }
            property.District = dbDistrict;

            var dbType = dbContext.PropertyTypes.FirstOrDefault(x => x.Name == type);
            if (dbType == null)
            {
                dbType = new PropertyType()
                {
                    Name = type
                };
            }
            property.Type = dbType;

            var dbBuildingType = dbContext.Buildings.FirstOrDefault(x => x.Name == buildingType);
            if (dbBuildingType == null)
            {
                dbBuildingType = new Building
                {
                    Name = buildingType
                };
            }
            property.BuildingType = dbBuildingType;

            dbContext.Properties.Add(property);

            dbContext.SaveChanges();
        }

        public decimal AveragePricePerSquareMeter()
        {
            return dbContext.Properties
                 .Where(p => p.Price.HasValue)
                 .Average(x => x.Price / (decimal)x.Size) ?? 0;
        }

        public decimal AveragePricePerSquareMeter(int districtId)
        {
            return dbContext.Properties
                 .Where(p => p.Price.HasValue && p.DistrictId == districtId)
                 .Average(x => x.Price / (decimal)x.Size) ?? 0;
        }

        public double AverageSize(int districtId)
        {
            return dbContext.Properties
                 .Where(p => p.Price.HasValue && p.DistrictId == districtId)
                 .Average(x => x.Size);
        }

        public IEnumerable<PropertyInfoFullData> GetFullData(int count)
        {
            var properties = dbContext.Properties
                .ProjectTo<PropertyInfoFullData>(this.Mapper.ConfigurationProvider)
                .OrderByDescending(p => p.Price)
                .Take(count)
                .ToArray();

            return properties;
        }

        public IEnumerable<PropertyInfoDto> Search(int minPrice, int maxPrice, int minSquare, int maxSquare)
        {
            var propertyInfoDtos = dbContext.Properties
                .Where(p => (p.Price >= minPrice && p.Price <= maxPrice)
                && (p.Size >= minSquare && p.Size <= maxSquare))
                .ProjectTo<PropertyInfoDto>(this.Mapper.ConfigurationProvider)
                .ToList();

            return propertyInfoDtos;
        }
    }
}
