using Microsoft.AspNetCore.Mvc;
using BusinessLogic;
using BusinessLogic.Repository;
using Microsoft.AspNetCore.Http;


namespace MagicDishWebApplication.Controllers
{
    public class RecipesController : Controller
    {
        private readonly ILogger<RecipesController> _logger;
        private IRecipeRepository _recipeRepository;
        public RecipesController(ILogger<RecipesController> logger, IRecipeRepository recipeRepository )
        {
            _recipeRepository = recipeRepository;
            _logger = logger;
        }
        // GET: RecipesController
        public async Task<IActionResult> Index()
    
        
        {
            List<Recipe> recipes = await _recipeRepository.GetAsync();
            return View(recipes);
        }

        // GET: RecipesController/Details/5
        public async  Task<ActionResult> Details(int id)
        {
            List<Recipe> recipes = await _recipeRepository.GetAsync();
            return View(recipes.FirstOrDefault(r => r.Id == id));
        }

        // GET: RecipesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecipesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Recipe recipe)
        {
            List<Recipe> recipes = await _recipeRepository.GetAsync();
            if (!ModelState.IsValid)
            {
                return View(recipe);
            }

            try
            {
                recipes.Add(recipe);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RecipesController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            List<Recipe> recipes = await _recipeRepository.GetAsync();
            if (!recipes.Any(p => p.Id == id))
            {
                //return StatusCode(StatusCodes.Status500InternalServerError);

                return NotFound();

                //return BadRequest();
            }
            return View(recipes.Single(p => p.Id == id));
        }

        // POST: RecipesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Recipe recipe)
        {
            List<Recipe> recipes = await _recipeRepository.GetAsync();

            if (!ModelState.IsValid)
            {
                return View(recipe);
            }

            try
            {
                var existingRecipe = recipes.First(r => r.Id == recipe.Id);

                existingRecipe.Id = recipe.Id;
                existingRecipe.Name = recipe.Name;
                existingRecipe.CookingTimeInMinutes = recipe.CookingTimeInMinutes;
                existingRecipe.IsVegeterian = recipe.IsVegeterian;
                existingRecipe.Description = recipe.Description;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RecipesController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            List<Recipe> recipes = await _recipeRepository.GetAsync();
            var existingRecipe = recipes.First(r => r.Id == id);
            return View(existingRecipe);
        }

        // POST: RecipesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Recipe recipe)
        {
            List<Recipe> recipes = await _recipeRepository.GetAsync();
            try
            {
                var existingRecipe = recipes.First(p => p.Id == id);
                recipes.Remove(existingRecipe);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
