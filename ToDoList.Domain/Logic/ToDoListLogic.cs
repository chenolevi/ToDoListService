using AutoMapper;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Database.Sql.Abstraction;
using ToDoList.Domain.Interfaces;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Logic
{
    internal class ToDoListLogic : IToDoListLogic
    {
        private readonly IToDoListContainer _dal;
        private readonly IMapper _mapper;

        public ToDoListLogic(IToDoListContainer dal,
            IMapper mapper) 
        {
            _dal = dal;
            _mapper = mapper;
        }

        public Guid Add(Models.Task task)
        {
            var newTask = _mapper.Map<Database.Sql.Abstraction.dtoModels.Task>(task);
            newTask.Id = Guid.NewGuid();
            BackgroundJob.Enqueue<IToDoListContainer>(dal => dal.AddTask(newTask));
            return newTask.Id;
        }

        public void Delete(Guid id)
        {
            BackgroundJob.Enqueue<IToDoListContainer>(dal => dal.DeleteTask(id));
        }

        public async Task<Models.Task> Get(Guid id)
        {
            var task = await _dal.GetTask(id);
            var mappedTask = _mapper.Map<Models.Task>(task);
            return mappedTask;
        }

        public async Task<IEnumerable<GetAllTasksResponse>> GetAll()
        {
            var tasks = await _dal.GetTasks();
            var mappedTasks = _mapper.Map<IEnumerable<GetAllTasksResponse>>(tasks);
            return mappedTasks;
        }

        public void Update(Guid id, Models.Task task)
        {
            var mappedTasks = _mapper.Map<Database.Sql.Abstraction.dtoModels.Task>(task);
            mappedTasks.Id= id;
            BackgroundJob.Enqueue<IToDoListContainer>(dal => dal.UpdateTask(id, mappedTasks));
        }
    }
}
