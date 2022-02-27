using APIWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_api.Contracts;

namespace web_api_tests
{
    public class ProjectServiceFake :IProjectService
    {
        private readonly List<ProjectModel> projects;

        public ProjectServiceFake()
        {
             projects = new List<ProjectModel>()
        {
            new ProjectModel (1, "TestProject1", "This is a test project", DateTime.Parse("2022-01-13")),
            new ProjectModel (2, "TestProject1", "This is a test project", DateTime.Parse("2022-01-13")),
            new ProjectModel (3, "TestProject1", "This is a test project", DateTime.Parse("2022-01-13")),
            new ProjectModel (4, "TestProject1", "This is a test project", DateTime.Parse("2022-01-13"))
        };
        }
        public IEnumerable<ProjectModel> GetAllItems()
        {
            return projects;
        }

        public ProjectModel Add(ProjectModel newItem)
        {
            Random rnd = new Random();
            newItem.Id = rnd.Next(1, 13);
            projects.Add(newItem);
            return newItem;
        }

        public ProjectModel GetById(int id)
        {
            return projects.FirstOrDefault(a => a.Id == id);
        }

        public void Remove(int id)
        {
            var existing = projects.First(a => a.Id == id);
            projects.Remove(existing);
        }
    }
}
