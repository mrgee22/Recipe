using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe.Data;

namespace Recipe.Web.Controllers
{
    [Route("api/[controller]")]
    public class RecipeController : Controller
    {
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
        [ActionName("Index")]
        public async Task<IActionResult> Index()
        {
            var items = await RecipeRepository<Model.Recipe>.GetItemsAsync(r => r.CreatedBy == 1);
            return View(items);
        }
    }
}