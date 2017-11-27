using System;
using System.Threading.Tasks;
using Recipe.Data;
using Recipe.Model;
using System.Collections.Generic;

namespace Recipe.Service
{
    public class RecipeService : IRecipeService
    {
        public async Task<Model.Recipe> Create(Model.Recipe recipe)
        {
            var dbRecipe = await DBRepository<Model.Recipe>.CreateItemAsync(recipe);
            recipe.Id = dbRecipe.Id;

            return recipe;
        }

        public async void Delete(string id)
        {
            var recipe = GetById(id);
            if (recipe != null)
                await DBRepository<Model.Recipe>.DeleteItemAsync(id.ToString());
        }

        public async Task<IEnumerable<Model.Recipe>> GetAll(string userId)
        {
            var recipes = await DBRepository<Model.Recipe>.GetItemsAsync(r => r.CreatedById == userId);
            return recipes;
        }

        public async Task<Model.Recipe> GetById(string id)
        {
            var recipe = await DBRepository<Model.Recipe>.GetItemAsync(id.ToString());
            return recipe;
        }

        public async void Update(Model.Recipe recipe)
        {
            var dbRecipe = await GetById(recipe.Id);

            if (dbRecipe == null)
                throw new Exception("Recipe not found");

            // update recipe properties
            dbRecipe.Description = recipe.Description;
            dbRecipe.Notes = recipe.Notes;
            dbRecipe.Steps = recipe.Steps;
            dbRecipe.Title = recipe.Title;

            await DBRepository<Model.Recipe>.UpdateItemAsync(recipe.Id, dbRecipe);
        }
    }
}
