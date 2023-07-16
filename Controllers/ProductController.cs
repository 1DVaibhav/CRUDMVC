using Microsoft.AspNetCore.Mvc;

namespace CRUDMVC.Controllers
{
    using CRUDMVC.Models;
    using Microsoft.AspNetCore.Mvc;

    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>
    {
        new Product { ProductId = 1, ProductName = "Product 1", Price = 10.99m },
        new Product { ProductId = 2, ProductName = "Product 2", Price = 19.99m },
        // Add more initial products here if needed
    };

        // GET: Product
        public IActionResult Index()
        {
            return View(products);
        }

        // GET: Product/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                // Assign a new unique ProductId
                product.ProductId = products.Max(p => p.ProductId) + 1;
                products.Add(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Product/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingProduct = products.FirstOrDefault(p => p.ProductId == id);
                if (existingProduct == null)
                {
                    return NotFound();
                }

                existingProduct.ProductName = product.ProductName;
                existingProduct.Price = product.Price;

                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        // GET: Product/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            products.Remove(product);
            return RedirectToAction(nameof(Index));
        }
    }

}
