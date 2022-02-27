using APIWeb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_api.Contracts;

namespace web_api_tests
{
    public class UserServiceFake: IUserService
    {
        private readonly List<UserModel> users;

        public UserServiceFake()
        {
             users = new List<UserModel>()
        {
            new UserModel (1, "John", "Doe", "john.doe@test.com", "Password1"),
            new UserModel (2, "John", "Skeet", "john.Skeet@test.com", "Password2"),
            new UserModel (3, "Mark", "Seeman", "mark.Seeman@test.com", "Password3"),
            new UserModel (4, "Bob", "Martin", "bob.Martin@test.com", "Password3")
        };
        }
        public IEnumerable<UserModel> GetAllItems()
        {
            return users;
        }

        public UserModel Add(UserModel newItem)
        {
            Random rnd = new Random();
            newItem.Id = rnd.Next(1, 13);
            users.Add(newItem);
            return newItem;
        }

        public UserModel GetById(int id)
        {
            return users.FirstOrDefault(a => a.Id == id);
        }

        public void Remove(int id)
        {
            var existing = users.First(a => a.Id == id);
            users.Remove(existing);
        }
    }
}
