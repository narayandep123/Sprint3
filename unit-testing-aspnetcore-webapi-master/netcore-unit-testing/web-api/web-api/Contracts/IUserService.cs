using APIWeb.Model;

namespace web_api.Contracts
{
    public interface IUserService
    {
        IEnumerable<UserModel> GetAllItems();
        UserModel GetById(int id);

        UserModel Add(UserModel newItem);

        void Remove(int id);
    }
}
