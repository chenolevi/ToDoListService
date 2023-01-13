using Hangfire;
using ToDoList.Domain;

namespace ToDoListService
{
    public static class DIRegistration
    {
        public static IServiceCollection AddToDoListServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddToDoListDomain()
                    .AddHangfire(configuration);
            return services;
        }
    }
}
