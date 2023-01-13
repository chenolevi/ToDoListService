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
        public async Task<ToDoList.Domain.Models.Task> Get(string id)
        {
            return await _toDoListLogic.Get(id);
        }

        [HttpPost()]
        public async Task<string> Post([FromBody] ToDoList.Domain.Models.Task task)
        {
            return await _toDoListLogic.Add(task);
        }

        [HttpPut("{id}")]
        public async Task Put(string id, [FromBody] ToDoList.Domain.Models.Task task)
        {
            await _toDoListLogic.Update(id, task);
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id)
        {
            await _toDoListLogic.Delete(id);
        }
    }
}