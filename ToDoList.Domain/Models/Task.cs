using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Enums;

namespace ToDoList.Domain.Models
{
    public class Task
    {
        public Guid UserId { get; set; }
        [StringLength(250)]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DateTimeCreation { get; set; }
        [EnumDataType(typeof(Priority), ErrorMessage = "Invalid priority")]
        public Priority Priority { get; set; }
        [EnumDataType(typeof(Status), ErrorMessage = "Invalid status")]
        public Status Status { get; set; }
    }

    public class GetAllTasksResponse: Task
    {
        public string Id { get; set; }
    }
}
