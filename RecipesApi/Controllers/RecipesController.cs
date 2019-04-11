using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeApi.Models;

namespace RecipeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository;
        public RecipesController(IRecipeRepository context)
        {
            _recipeRepository = context;
        }

        // GET: api/Recipes
        /// <summary>
        /// Get all recipes ordered by name
        /// </summary>
        /// <returns>array of recipes</returns>
        
        [HttpGet]
        public IEnumerable<Recipe> GetRecipes(string name=null,string chef=null, string ingredientName = null)
        {
            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(chef) && string.IsNullOrEmpty(ingredientName))
                return _recipeRepository.GetAll();
            return _recipeRepository.GetBy(name, chef, ingredientName);
        }

        // GET: api/Recipes/5
        /// <summary>
        /// Get the recipe with given id
        /// </summary>
        /// <param name="id">the id of the recipe</param>
        /// <returns>The recipe</returns>
        
        [HttpGet("{id}")]
        public ActionResult<Recipe> GetRecipe(int id)
        {
            Recipe recipe = _recipeRepository.GetBy(id);
            if (recipe == null) return NotFound();
            return recipe;
        }
    }
}