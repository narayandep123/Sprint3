using APIWeb.Model;
using web_api.Contracts;

namespace web_api.Services
{
    public class ProjectService: IProjectService
    {
        public IEnumerable<ProjectModel> GetAllItems() => throw new NotImplementedException();

        public ProjectModel GetById(int id) => throw new NotImplementedException();

        public ProjectModel Add(ProjectModel newItem) => throw new NotImplementedException();

        public void Remove(int id) => throw new NotImplementedException();
    }
}
