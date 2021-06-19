using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstates.Services
{
    public interface IDistrictsService
    {
        IEnumerable<DistrictInfoDto> GetMostExpensiveDistricts(int count);
    }
}
