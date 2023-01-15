using Azure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace ToDoList.Database.Sql.DatabaseTables
{
    [Table("Task", Schema = "dbo")]
    internal class Task
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column(TypeName = "datetime2")]
        public DateTime? DateTimeCreation { get; set; }

        [Required]
        public int StatusId { get; set; }

        [Required]
        public int PriorityId { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(int.MaxValue)]
        public string Description { get; set; }

        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }

        [ForeignKey("PriorityId")]
        public virtual Priority Priority { get; set; }
    }
}
