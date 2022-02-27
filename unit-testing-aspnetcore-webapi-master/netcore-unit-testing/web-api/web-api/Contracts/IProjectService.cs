using APIWeb.Model;

namespace web_api.Contracts
{
    public interface IProjectService
    {
        IEnumerable<ProjectModel> GetAllItems();
        ProjectModel GetById(int id);

        ProjectModel Add(ProjectModel newItem);

        void Remove(int id);
    }
}
