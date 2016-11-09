using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LVL3.MVCApi.AutoMapperConfig
{
    static public class IncludeAllMappings
    {
        static public void include()
        {
            Mapper.Initialize(cfg =>
        cfg.AddProfiles(new[] {
                    typeof(LVL3.DependencyResolver.AutoMapperConfig.MappingConfig),
                    typeof(LVL3.MVCApi.AutoMapperConfig.Mapping)
            })
        );
        }
    }
}