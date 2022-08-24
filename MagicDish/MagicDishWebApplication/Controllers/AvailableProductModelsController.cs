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
    public class AvailableProductModelsController : Controller
    {
        private readonly MagicDishWebApplicationContext _context;

        public AvailableProductModelsController(MagicDishWebApplicationContext context)
        {
            _context = context;
        }

        // GET: AvailableProductModels
        public async Task<IActionResult> Index()
        {
              return _context.AvailableProducts != null ? 
                          View(await _context.AvailableProducts.ToListAsync()) :
                          Problem("Entity set 'MagicDishWebApplicationContext.AvailableProducts'  is null.");
        }

        // GET: AvailableProductModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AvailableProducts == null)
            {
                return NotFound();
            }

            var availableProductModel = await _context.AvailableProducts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (availableProductModel == null)
            {
                return NotFound();
            }

            return View(availableProductModel);
        }

        // GET: AvailableProductModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AvailableProductModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,UnitOfMeasure,ProductCategory")] AvailableProductModel availableProductModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(availableProductModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(availableProductModel);
        }

        // GET: AvailableProductModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AvailableProducts == null)
            {
                return NotFound();
            }

            var availableProductModel = await _context.AvailableProducts.FindAsync(id);
            if (availableProductModel == null)
            {
                return NotFound();
            }
            return View(availableProductModel);
        }

        // POST: AvailableProductModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,UnitOfMeasure,ProductCategory")] AvailableProductModel availableProductModel)
        {
            if (id != availableProductModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(availableProductModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvailableProductModelExists(availableProductModel.Id))
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
            return View(availableProductModel);
        }

        // GET: AvailableProductModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AvailableProducts == null)
            {
                return NotFound();
            }

            var availableProductModel = await _context.AvailableProducts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (availableProductModel == null)
            {
                return NotFound();
            }

            return View(availableProductModel);
        }

        // POST: AvailableProductModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AvailableProducts == null)
            {
                return Problem("Entity set 'MagicDishWebApplicationContext.AvailableProducts'  is null.");
            }
            var availableProductModel = await _context.AvailableProducts.FindAsync(id);
            if (availableProductModel != null)
            {
                _context.AvailableProducts.Remove(availableProductModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvailableProductModelExists(int id)
        {
          return (_context.AvailableProducts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
