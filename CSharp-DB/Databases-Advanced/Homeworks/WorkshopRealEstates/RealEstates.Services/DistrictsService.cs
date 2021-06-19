using AutoMapper.QueryableExtensions;
using RealEstates.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstates.Services
{
    public class DistrictsService : BaseService, IDistrictsService
    {
        private readonly ApplicationDbContext dbContext;

        public DistrictsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<DistrictInfoDto> GetMostExpensiveDistricts(int count)
        {
            var districtsAvg = this.dbContext.Districts
                .ProjectTo<DistrictInfoDto>(this.Mapper.ConfigurationProvider)
                .OrderByDescending(d => d.AveragePricePerSquareMeter)
                .Take(count)
                .ToList();

            return districtsAvg;
        }
    }
}
