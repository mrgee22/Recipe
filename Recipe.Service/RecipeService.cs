using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recipe.Model;

namespace Recipe.Service
{
    public class RecipeService : IRecipeService
    {
        public Task<Model.Recipe> Create(Model.Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Model.Recipe> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(Model.Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}
