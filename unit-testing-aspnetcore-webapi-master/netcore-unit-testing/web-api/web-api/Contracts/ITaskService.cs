using APIWeb.Model;

namespace web_api.Contracts
{
    public interface ITaskService
    {
        IEnumerable<TaskModel> GetAllItems();
        TaskModel GetById(int id);

        TaskModel Add(TaskModel newItem);

        void Remove(int id);
    }
}
