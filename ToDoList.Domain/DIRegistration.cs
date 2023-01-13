using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Interfaces;
using ToDoList.Domain.Logic;

namespace ToDoList.Domain
{
    public static class DIRegistration
    {
        public static IServiceCollection AddToDoListDomain(this IServiceCollection services)
        {
            services.AddSingleton<IToDoListLogic, ToDoListLogic>();
            return services;
        }
    }
}
