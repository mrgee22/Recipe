using Recipe.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recipe.Service
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<User> GetById(string id);
        Task<User> Create(User user, string password);
        void Update(User userParam, string password = null);
        void Delete(string id);
    }
}
