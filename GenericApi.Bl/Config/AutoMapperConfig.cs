﻿using Microsoft.Extensions.DependencyInjection;
using System;

namespace GenericApi.Bl.Config
{
    public static class AutoMapperConfig
    {
        public static IServiceCollection ConfigAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}
