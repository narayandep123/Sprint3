using APIWeb.Model;
using web_api.Contracts;

namespace web_api.Services
{
    public class TaskService: ITaskService
    {
        public IEnumerable<TaskModel> GetAllItems() => throw new NotImplementedException();

        public TaskModel GetById(int id) => throw new NotImplementedException();

        public TaskModel Add(TaskModel newItem) => throw new NotImplementedException();

        public void Remove(int id) => throw new NotImplementedException();
    }
}
