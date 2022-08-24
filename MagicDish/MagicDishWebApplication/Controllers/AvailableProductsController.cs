using Microsoft.AspNetCore.Mvc;
using BusinessLogic;
using BusinessLogic.Repository;
using Microsoft.AspNetCore.Http;



namespace MagicDishWebApplication.Controllers;

public class AvailableProductsController : Controller
{
    private readonly ILogger<AvailableProductsController> _logger;
    private IProductRepository _repository;

    public AvailableProductsController(ILogger<AvailableProductsController> logger, IProductRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    // GET: FoodRepoController
    public async Task<IActionResult> Index()
    {
        List<Product> products = await _repository.GetAsync();
        return View(products);
    }

    // GET: AvailableProductsController/Details/5
    public async Task<IActionResult> Details(int id)
    {
        List<Product> products = await _repository.GetAsync();
        return View(products.FirstOrDefault(p => p.Id == id));
    }

    // GET: AvailableProductsController/Create
    public async Task<IActionResult> Create()
    {
        return View();
    }

    // POST: AvailableProductsController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Product product)
    {
        List<Product> products = await _repository.GetAsync();

        if (!ModelState.IsValid)
        {
            return View(product);
        }

        try
        {
            products.Add(product);
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }

    // GET: AvailableProductsController/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        List<Product> products = await _repository.GetAsync();

        if (!products.Any(p => p.Id == id))
        {
            //return StatusCode(StatusCodes.Status500InternalServerError);

            return NotFound();

            //return BadRequest();
        }

        return View(products.Single(p => p.Id == id));
    }

    // POST: AvailableProductsController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Product product)
    {
        List<Product> products = await _repository.GetAsync();

        if (!ModelState.IsValid)
        {
            return View(product);
        }

        try
        {
            var existingProduct = products.First(a => a.Id == product.Id);

            existingProduct.Id = product.Id;
            existingProduct.Name = product.Name;
            existingProduct.ProductCategory = product.ProductCategory;
            existingProduct.UnitOfMeasure = product.UnitOfMeasure;

            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }

    // GET: AvailableProductsController/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        List<Product> products = await _repository.GetAsync();

        var existingProduct = products.First(p => p.Id == id);
        return View(existingProduct);
    }

    // POST: AvailableProductsController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, Product product)
    {
        List<Product> products = await _repository.GetAsync();

        try
        {
            var existingProduct = products.First(p => p.Id == id);
            products.Remove(existingProduct);

            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
