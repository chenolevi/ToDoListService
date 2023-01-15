using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Interfaces;
using ToDoList.Domain.Logic;
using ToDoList.Domain.Mapper;

namespace ToDoList.Domain
{
    public static class DIRegistration
    {
        public static IServiceCollection AddToDoListDomain(this IServiceCollection services)
        {
            services.AddSingleton<IToDoListLogic, ToDoListLogic>();
            var mapperConfig = new MapperConfiguration(new MappersRegistration());
            services.AddSingleton(mapperConfig.CreateMapper());
            return services;
        }
    }
}
