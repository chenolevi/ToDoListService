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
        Task<Models.Task> Get(string id);
        Task<string> Add(Models.Task task);
        Task Update(string id, Models.Task task);
        Task Delete(string id);
    }
}
