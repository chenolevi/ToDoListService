using Hangfire;
using ToDoList.Database.Sql;
using ToDoList.Domain;

namespace ToDoListService
{
    public static class DIRegistration
    {
        public static IServiceCollection AddToDoListServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddToDoListDomain()
                    .AddToDoListDal(configuration)
                    .AddHangfire(configuration);
            return services;
        }
    }
}
