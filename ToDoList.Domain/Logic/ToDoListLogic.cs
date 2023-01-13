using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Interfaces;
using ToDoList.Domain.Models;

namespace ToDoList.Domain.Logic
{
    internal class ToDoListLogic : IToDoListLogic
    {
        public Task<string> Add(Models.Task task)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Models.Task> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetAllTasksResponse>> GetAll()
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task Update(string id, Models.Task task)
        {
            throw new NotImplementedException();
        }
    }
}
