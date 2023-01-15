using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Database.Sql.Abstraction;
using ToDoList.Database.Sql.Mapper;

namespace ToDoList.Database.Sql
{
    public static class DIRegistration
    {
        public static IServiceCollection AddToDoListDal(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = string.Format(configuration.GetConnectionString("BaseConnectionStrings"),
                configuration.GetConnectionString("ToDoListDB"));
            
            services.AddDbContext<ToDoListContext>(options => options.UseSqlServer(connectionString));
            services.AddSingleton<IToDoListContainer, ToDoListContainer>();

            //var mapperConfig = new MapperConfiguration(new MappersRegistration());
            //services.AddSingleton(mapperConfig.CreateMapper());

            return services;
        }
    }
}
