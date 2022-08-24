using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MagicDishWebApplication.Data;
using MagicDishWebApplication.Models;

namespace MagicDishWebApplication.Controllers
{
    public class RecipesModelsController : Controller
    {
        private readonly MagicDishWebApplicationContext _context;

        public RecipesModelsController(MagicDishWebApplicationContext context)
        {
            _context = context;
        }

        // GET: RecipesModels
        public async Task<IActionResult> Index()
        {
              return _context.Recipes != null ? 
                          View(await _context.Recipes.ToListAsync()) :
                          Problem("Entity set 'MagicDishWebApplicationContext.Recipes'  is null.");
        }

        // GET: RecipesModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Recipes == null)
            {
                return NotFound();
            }

            var recipesModel = await _context.Recipes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipesModel == null)
            {
                return NotFound();
            }

            return View(recipesModel);
        }

        // GET: RecipesModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RecipesModels/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CookingTimeInMinutes,IsVegeterian,Description")] RecipesModel recipesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recipesModel);
        }

        // GET: RecipesModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Recipes == null)
            {
                return NotFound();
            }

            var recipesModel = await _context.Recipes.FindAsync(id);
            if (recipesModel == null)
            {
                return NotFound();
            }
            return View(recipesModel);
        }

        // POST: RecipesModels/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CookingTimeInMinutes,IsVegeterian,Description")] RecipesModel recipesModel)
        {
            if (id != recipesModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipesModelExists(recipesModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(recipesModel);
        }

        // GET: RecipesModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Recipes == null)
            {
                return NotFound();
            }

            var recipesModel = await _context.Recipes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recipesModel == null)
            {
                return NotFound();
            }

            return View(recipesModel);
        }

        // POST: RecipesModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Recipes == null)
            {
                return Problem("Entity set 'MagicDishWebApplicationContext.Recipes'  is null.");
            }
            var recipesModel = await _context.Recipes.FindAsync(id);
            if (recipesModel != null)
            {
                _context.Recipes.Remove(recipesModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipesModelExists(int id)
        {
          return (_context.Recipes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
