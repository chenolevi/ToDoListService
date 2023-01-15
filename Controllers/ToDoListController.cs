using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoList.Domain.Interfaces;
using ToDoList.Domain.Models;
using Task = System.Threading.Tasks.Task;

namespace ToDoListService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoListController : ControllerBase
    {
        private readonly ILogger<ToDoListController> _logger;
        private readonly IToDoListLogic _toDoListLogic;

        public ToDoListController(ILogger<ToDoListController> logger,
            IToDoListLogic toDoListLogic)
        {
            _logger = logger;
            _toDoListLogic = toDoListLogic;
        }

        [HttpGet()]
        public async Task<IEnumerable<GetAllTasksResponse>>Get()
        {
            return await _toDoListLogic.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ToDoList.Domain.Models.Task> Get(Guid id)
        {
            return await _toDoListLogic.Get(id);
        }

        [HttpPost()]
        public async Task<Guid> Post([FromBody] ToDoList.Domain.Models.Task task)
        {
            var taskId = _toDoListLogic.Add(task);
            return taskId;
        }

        [HttpPut("{id}")]
        public async Task Put(Guid id, [FromBody] ToDoList.Domain.Models.Task task)
        {
            _toDoListLogic.Update(id, task);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            _toDoListLogic.Delete(id);
        }
    }
}