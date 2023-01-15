using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Database.Sql.Abstraction;
using ToDoList.Database.Sql.DatabaseTables;
using ToDoList.Database.Sql.Mapper;
using ToDoList.Enums;
using Microsoft.EntityFrameworkCore;

namespace ToDoList.Database.Sql
{
    internal class ToDoListContainer : IToDoListContainer
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IMapper _mapper;

        public ToDoListContainer(IServiceScopeFactory scopeFactory,
            IMapper mapper)
        {
            _scopeFactory = scopeFactory;
            _mapper = new MapperConfiguration(new MappersRegistration()).CreateMapper(); //mapper;
        }

        public void AddTask(Abstraction.dtoModels.Task task)
        {
            using var scope = _scopeFactory.CreateScope();
            using var dataContext = scope.ServiceProvider.GetService<ToDoListContext>();
            var newTask = _mapper.Map<DatabaseTables.Task>(task);
            dataContext.Task.Add(newTask);
            dataContext.SaveChanges();
        }

        public async Task<Abstraction.dtoModels.Task> GetTask(Guid id)
        {
            using var scope = _scopeFactory.CreateScope();
            using var dataContext = scope.ServiceProvider.GetService<ToDoListContext>();
            var task = await dataContext.Task.Where(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<Abstraction.dtoModels.Task>(task);
        }

        public async Task<IEnumerable<Abstraction.dtoModels.Task>> GetTasks()
        {
            using var scope = _scopeFactory.CreateScope();
            using var dataContext = scope.ServiceProvider.GetService<ToDoListContext>();
            var tasks = await dataContext.Task.ToListAsync();
            return _mapper.Map<IEnumerable<Abstraction.dtoModels.Task>>(tasks);
        }

        public void UpdateTask(Guid id, Abstraction.dtoModels.Task task)
        {           
            using var scope = _scopeFactory.CreateScope();
            using var dataContext = scope.ServiceProvider.GetService<ToDoListContext>();
            var taskToUpdate = dataContext.Task.Find(id);

            if (taskToUpdate == null)
                throw new ArgumentException($"Task ID: {id} not found");
            
            var mappedTask = _mapper.Map(task, taskToUpdate);
            dataContext.Task.Update(mappedTask);
            dataContext.SaveChanges();
        }

        public void DeleteTask(Guid id)
        {
            using var scope = _scopeFactory.CreateScope();
            using var dataContext = scope.ServiceProvider.GetService<ToDoListContext>();
            var taskToUpdate = dataContext.Task.Find(id);

            if (taskToUpdate == null)
                throw new ArgumentException($"Task ID: {id} not found");

            taskToUpdate.StatusId = (int)Enums.Status.Removed;
            dataContext.Task.Update(taskToUpdate);
            dataContext.SaveChanges();
        }
    }
}
