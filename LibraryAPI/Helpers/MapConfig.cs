using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Helpers
{
    public class MapConfig
    {
        public static IMapper Mapper => Lazy.Value;

        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<LibraryMappings>();
                cfg.AddProfile<AutoMapperProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
    }
}
