using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Enums;

namespace ToDoList.Database.Sql.Abstraction.dtoModels
{
    public class Task
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public DateTime? DateTimeCreation { get; set; }

        public Status Status { get; set; }

        public Priority Priority { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
