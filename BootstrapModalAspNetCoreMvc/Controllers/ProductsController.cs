using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BootstrapModalAspNetCoreMvc.Data;
using BootstrapModalAspNetCoreMvc.Models;

namespace BootstrapModalAspNetCoreMvc.Controllers
{
    public class ProductsController : Controller
    {
        private readonly List<Models.Products> ProductsList;

        public ProductsController()
        {
            ProductsList = new List<Products>
            {
                new Products{ID=1,Name="Product1",Description="Product1 Description",Price=30},
                new Products{ID=1,Name="Product2",Description="Product2 Description",Price=60},
                new Products{ID=1,Name="Product3",Description="Product3 Description",Price=70},
                new Products{ID=1,Name="Product4",Description="Product4 Description",Price=99},
                new Products{ID=1,Name="Product5",Description="Product5 Description",Price=120},
                new Products{ID=1,Name="Product6",Description="Product6 Description",Price=500},
            };
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(ProductsList);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = ProductsList
                .FirstOrDefault(m => m.ID == id);
            if (products == null)
            {
                return NotFound();
            }

            return PartialView(products);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return PartialView();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Price,Description")] Products products)
        {
            if (ModelState.IsValid)
            {
                ProductsList.Add(products);
                return RedirectToAction(nameof(Index));
            }
            return PartialView(products);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var products = ProductsList.Where(c=>c.ID == id);
            if (products == null)
            {
                return NotFound();
            }
            return PartialView(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Price,Description")] Products products)
        {
            if (id != products.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ProductsList.Remove(products);
                    ProductsList.Add(products);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.ID))
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
            return View(products);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var product = ProductsList.Where(c => c.ID == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }

            return PartialView(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
             var product = ProductsList.Where(c => c.ID == id).FirstOrDefault();
           ProductsList.Remove(product);
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
            return ProductsList.Any(e => e.ID == id);
        }
    }
}
