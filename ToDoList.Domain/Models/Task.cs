using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Enums;

namespace ToDoList.Domain.Models
{
    public class Task
    {
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreation { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
    }

    public class GetAllTasksResponse: Task
    {
        public string Id { get; set; }
    }
}
