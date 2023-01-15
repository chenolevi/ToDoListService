using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Database.Sql.Mapper
{
    internal class MappersRegistration : MapperConfigurationExpression
    {
        public MappersRegistration() 
        {
            CreateMap<Abstraction.dtoModels.Task, DatabaseTables.Task>()
                .ForPath(dest => dest.StatusId, opt => opt.MapFrom(src => src.Status))
                .ForPath(dest => dest.PriorityId, opt => opt.MapFrom(src => src.Priority))
                .ForMember(x => x.DateTimeCreation, opt => opt.Ignore())
                .ForMember(x => x.Status, opt => opt.Ignore())
                .ForMember(x => x.Priority, opt => opt.Ignore());

            CreateMap<DatabaseTables.Task, Abstraction.dtoModels.Task>()
                .ForPath(dest => dest.Status, opt => opt.MapFrom(src => src.StatusId))
                .ForPath(dest => dest.Priority, opt => opt.MapFrom(src => src.PriorityId));
        }
    }
}
