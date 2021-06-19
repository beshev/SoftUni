using AutoMapper;
using RealEstates.Services.Profiler;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstates.Services
{
    public class BaseService
    {
        public BaseService()
        {
            InitializeAutoMapper();
        }

        protected IMapper Mapper { get; set; }

        private void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<RealEstateProfiler>();
            });

            this.Mapper = config.CreateMapper();
        }
    }
}
