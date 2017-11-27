using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.Data;
using Recipe.Service;
using Microsoft.AspNetCore.Authorization;

namespace Recipe.Web.Controllers
{
    [Route("api/[controller]")]
    public class RecipeController : Controller
    {
        private IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        //[HttpGet("[action]")]
        //public IEnumerable<Model.Recipe> GetRecipes()
        //{
        //    return new List<Model.Recipe>
        //    {
        //        new Model.Recipe{RecipeId = 1, CreatedBy = 1, Description ="Jolof", Notes ="Gasdkl=aksd", Title="Jol",
        //         Steps = new List<Model.Step>
        //            { new Model.Step{StepId = 1, Description="Open" }, new Model.Step{StepId = 2, Description="Tap" }}},
        //        new Model.Recipe{RecipeId = 2, CreatedBy = 1, Description ="James", Notes ="Anmnasd", Title="Jol2",
        //            Steps = new List<Model.Step>
        //            { new Model.Step{StepId = 1, Description="Open" }, new Model.Step{StepId = 2, Description="Tap" }}
        //        }
        //    };
        //}

        [Authorize]
        [HttpGet("[action]")]
        public IActionResult GetRecipes(string userId)
        {
            var items = _recipeService.GetAll(userId);
            return View(items);
        }

        [Authorize]
        [HttpPost("[action]")]
        public IActionResult CreateRecipe([FromBody]Model.Recipe recipe)
        {
            try
            {
                // save 
                _recipeService.Create(recipe);
                return Ok();
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public IActionResult UpdateRecipe(Model.Recipe recipe)
        {
            try
            {
                _recipeService.Update(recipe);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteRecipe(string recipeId)
        {
            try
            {
                _recipeService.Delete(recipeId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}