using BusinessLogic;
using BusinessLogic.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagicDishWebApplication.Controllers
{
    public class FoodRepoController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private IProductQuantityRepository _repository;

        public FoodRepoController(ILogger<HomeController> logger, IProductQuantityRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        // GET: FoodRepoController
        public async Task<IActionResult> Index()
        {
            List<ProductQuantity> products = await _repository.GetAsync();
            return View(products);
        }
        
        // GET: FoodRepoController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            List<ProductQuantity> products = await _repository.GetAsync();
            return View(products.FirstOrDefault(p => p.Product.Id == id));
        }

        // GET: FoodRepoController/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: FoodRepoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductQuantity product)
        {
            List<ProductQuantity> products = await _repository.GetAsync();

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

        // GET: FoodRepoController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            List<ProductQuantity> products = await _repository.GetAsync();

            if (!products.Any(p => p.Product.Id == id))
            {
                //return StatusCode(StatusCodes.Status500InternalServerError);

                return NotFound();

                //return BadRequest();
            }
            return View(products.Single(p => p.Product.Id == id));
        }

        // POST: FoodRepoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductQuantity productQuantity)
        {
            List<ProductQuantity> products = await _repository.GetAsync();

            if (!ModelState.IsValid)
            {
                return View(productQuantity);
            }

            try
            {
                var existingProduct = products.First(a => a.Product.Id == productQuantity.Product.Id);

                existingProduct.Product.Id = productQuantity.Product.Id;
                existingProduct.Product.Name = productQuantity.Product.Name;
                existingProduct.Product.ProductCategory = productQuantity.Product.ProductCategory;
                existingProduct.Product.UnitOfMeasure = productQuantity.Product.UnitOfMeasure;
                existingProduct.Quantity = productQuantity.Quantity;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FoodRepoController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            List<ProductQuantity> products = await _repository.GetAsync();

            var existingProduct = products.First(p => p.Product.Id == id);
            return View(existingProduct);
        }

        // POST: FoodRepoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, ProductQuantity product)
        {
            List<ProductQuantity> products = await _repository.GetAsync();

            try
            {
                var existingAlbum = products.First(p => p.Product.Id == id);
                products.Remove(existingAlbum);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
