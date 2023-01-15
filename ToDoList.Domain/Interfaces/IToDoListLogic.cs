using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Domain.Interfaces
{
    public interface IToDoListLogic
    {
        Task<IEnumerable<Models.GetAllTasksResponse>> GetAll();
        Task<Models.Task> Get(Guid id);
        Guid Add(Models.Task task);
        void Update(Guid id, Models.Task task);
        void Delete(Guid id);
    }
}
