using Microsoft.EntityFrameworkCore;
using ToDoList.Database.Sql.DatabaseTables;


namespace ToDoList.Database.Sql
{
    internal class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options)
        {
        }

        public virtual DbSet<DatabaseTables.Task> Task { get; set; }
        public virtual DbSet<Priority> Priority { get; set; }
        public virtual DbSet<Status> Status { get; set; }     
    }
}

