using AutoMapper;
using ToDoList.Database.Sql.Abstraction;

namespace ToDoList.Domain.Mapper
{
    internal class MappersRegistration : MapperConfigurationExpression
    {
        public MappersRegistration()
        {
            CreateMap<Database.Sql.Abstraction.dtoModels.Task, Models.Task>();
            CreateMap<Database.Sql.Abstraction.dtoModels.Task, Models.GetTaskResponse>();
            CreateMap<Models.Task, Database.Sql.Abstraction.dtoModels.Task>();
            CreateMap<Models.GetTaskResponse, Database.Sql.Abstraction.dtoModels.Task>();
        }
    }
}
