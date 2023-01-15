using AutoMapper;
using ToDoList.Database.Sql.Abstraction;

namespace ToDoList.Domain.Mapper
{
    internal class MappersRegistration : MapperConfigurationExpression
    {
        public MappersRegistration()
        {
            CreateMap<Database.Sql.Abstraction.dtoModels.Task, Models.Task>();
            CreateMap<Database.Sql.Abstraction.dtoModels.Task, Models.GetAllTasksResponse>();
            CreateMap<Models.Task, Database.Sql.Abstraction.dtoModels.Task>();
            CreateMap<Models.GetAllTasksResponse, Database.Sql.Abstraction.dtoModels.Task>();
        }
    }
}
