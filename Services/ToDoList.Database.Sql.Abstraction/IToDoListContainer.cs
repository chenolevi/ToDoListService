namespace ToDoList.Database.Sql.Abstraction
{
    public interface IToDoListContainer
    {
        void AddTask(dtoModels.Task task);
        Task<dtoModels.Task> GetTask(Guid id);
        Task<IEnumerable<dtoModels.Task>> GetTasks();
        void UpdateTask(Guid id, dtoModels.Task task);
        void DeleteTask(Guid id);
    }
}