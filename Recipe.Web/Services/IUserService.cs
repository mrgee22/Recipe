using Recipe.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recipe.Web.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<User> GetById(int id);
        Task<User> Create(User user, string password);
        void Update(User userParam, string password = null);
        void Delete(int id);
    }
}
