using APIWeb.Model;
using web_api.Contracts;

namespace web_api.Services
{
    public class UserService:IUserService
    {
        public IEnumerable<UserModel> GetAllItems() => throw new NotImplementedException();

        public UserModel GetById(int id) => throw new NotImplementedException();

        public UserModel Add(UserModel newItem) => throw new NotImplementedException();

        public void Remove(int id) => throw new NotImplementedException();
    }
}
