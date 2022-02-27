using APIWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_api.Contracts;

namespace web_api_tests
{
    public class TaskServiceFake : ITaskService
    {
        private readonly List<TaskModel> tasks;

        public TaskServiceFake()
        {
            tasks = new List<TaskModel>()
        {
            new TaskModel (1, 1, 2, 1, "This ia test Task", DateTime.Parse("2022-01-13")),
            new TaskModel (2, 1, 3, 2, "This ia test Task", DateTime.Parse("2022-01-13")),
            new TaskModel (3, 2, 4, 2, "This ia test Task", DateTime.Parse("2022-01-13"))
        };
        }
        public IEnumerable<TaskModel> GetAllItems()
        {
            return tasks;
        }

        public TaskModel Add(TaskModel newItem)
        {
            Random rnd = new Random();
            newItem.Id = rnd.Next(1, 13);
            tasks.Add(newItem);
            return newItem;
        }

        public TaskModel GetById(int id)
        {
            return tasks.FirstOrDefault(a => a.Id == id);
        }

        public void Remove(int id)
        {
            var existing = tasks.First(a => a.Id == id);
            tasks.Remove(existing);
        }

    }
}
