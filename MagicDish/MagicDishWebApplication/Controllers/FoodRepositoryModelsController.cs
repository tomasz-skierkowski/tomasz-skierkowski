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
    public class FoodRepositoryModelsController : Controller
    {
        private readonly MagicDishWebApplicationContext _context;

        public FoodRepositoryModelsController(MagicDishWebApplicationContext context)
        {
            _context = context;
        }

        // GET: FoodRepositoryModels
        public async Task<IActionResult> Index()
        {
              return _context.FoodRepositories != null ? 
                          View(await _context.FoodRepositories.ToListAsync()) :
                          Problem("Entity set 'MagicDishWebApplicationContext.FoodRepositories'  is null.");
        }

        // GET: FoodRepositoryModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FoodRepositories == null)
            {
                return NotFound();
            }

            var foodRepositoryModel = await _context.FoodRepositories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (foodRepositoryModel == null)
            {
                return NotFound();
            }

            return View(foodRepositoryModel);
        }

        // GET: FoodRepositoryModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FoodRepositoryModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] FoodRepositoryModel foodRepositoryModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foodRepositoryModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(foodRepositoryModel);
        }

        // GET: FoodRepositoryModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FoodRepositories == null)
            {
                return NotFound();
            }

            var foodRepositoryModel = await _context.FoodRepositories.FindAsync(id);
            if (foodRepositoryModel == null)
            {
                return NotFound();
            }
            return View(foodRepositoryModel);
        }

        // POST: FoodRepositoryModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] FoodRepositoryModel foodRepositoryModel)
        {
            if (id != foodRepositoryModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodRepositoryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodRepositoryModelExists(foodRepositoryModel.Id))
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
            return View(foodRepositoryModel);
        }

        // GET: FoodRepositoryModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FoodRepositories == null)
            {
                return NotFound();
            }

            var foodRepositoryModel = await _context.FoodRepositories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (foodRepositoryModel == null)
            {
                return NotFound();
            }

            return View(foodRepositoryModel);
        }

        // POST: FoodRepositoryModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FoodRepositories == null)
            {
                return Problem("Entity set 'MagicDishWebApplicationContext.FoodRepositories'  is null.");
            }
            var foodRepositoryModel = await _context.FoodRepositories.FindAsync(id);
            if (foodRepositoryModel != null)
            {
                _context.FoodRepositories.Remove(foodRepositoryModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodRepositoryModelExists(int id)
        {
          return (_context.FoodRepositories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
