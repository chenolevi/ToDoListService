using ToDoList.Domain;

namespace ToDoListService
{
    public static class DIRegistration
    {
        public static IServiceCollection AddToDoListServices(this IServiceCollection services)
        {
            services.AddToDoListDomain();
            return services;
        }
    }
}
