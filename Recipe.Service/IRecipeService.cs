using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recipe.Service
{
    public interface IRecipeService
    {
        Task<Model.Recipe> GetById(string id);
        Task<IEnumerable<Model.Recipe>> GetAll(string userId);
        Task<Model.Recipe> Create(Model.Recipe recipe);
        void Update(Model.Recipe recipe);
        void Delete(string id);
    }
}
