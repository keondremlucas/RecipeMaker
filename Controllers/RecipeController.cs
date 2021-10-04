using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RecipeMaker
{
    [ApiController]
    [Route("recipes/")]
    public class RecipeMakerController : ControllerBase
    {   
        private Database _db;
        public RecipeMakerController(Database db)
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult AddRecipe(Recipe recipe)
        {    
            _db.Add(recipe);
            _db.SaveChanges();
            return Ok(recipe);
        }

        [HttpGet("GetByID/{id}")]
        public IActionResult GetRecipeById(int id)
        {    
            var recipe = _db.Recipes.Where(r => r.Id == id).SingleOrDefault();
            if(recipe is null) return NotFound();
            return Ok(recipe);
        }

        [HttpGet("AllRecipes")]
         public IActionResult GetAllRecipes()
        {    
            var recipe = _db.Recipes.Where(r => r.Name != null);
            if(recipe is null) return NotFound();
        

            foreach(var r in recipe)
                return Ok(recipe);
            return Ok(recipe);
        }

        [HttpGet("GetRecipesByKeyword/{keyword}")]
         public IActionResult GetRecipesByKeyword(string keyword)
        {    
            var recipe = _db.Recipes.Where(r => r.Ingredients.Contains(keyword) || r.Ingredients.ToUpper().Contains(keyword.ToUpper()) || r.Ingredients.ToLower().Contains(keyword.ToLower()) );
            if(recipe is null) return NotFound();
            return Ok(recipe);
        }

        [HttpGet("GetCalories")]
         public IActionResult GetAllCalories()
        {    
            var recipe = _db.Recipes.Where(r => r.Name != null);
            if(recipe is null) return NotFound();
            var holder = new List<string>();
            foreach(var r in recipe)
              holder.Add($"{r.Name} - {r.Calories}");
            
            return Ok(holder);
        }
    }
}
