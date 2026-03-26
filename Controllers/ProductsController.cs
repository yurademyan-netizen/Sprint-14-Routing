using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductsWithRouting.Models;
using ProductsWithRouting.Services;

namespace ProductsWithRouting.Controllers
{
    public class ProductsController : Controller
    {
        private List<Product> myProducts;

        public ProductsController(Data data)
        {
            myProducts = data.Products;
        }

        [HttpGet]
        [Route("products/index")]
        [Route("items/index")]
        [Route("items")]
        [Route("products")]
        public IActionResult Index([FromQuery]int filterId, [FromQuery]string filtername)
        {
            IEnumerable<Product> filteredProducts = myProducts;

            if (filterId != 0)
            {
                filteredProducts = filteredProducts.Where(x => x.Id == filterId);
            }
            if (filtername != null)
            {
                filteredProducts = filteredProducts.Where(x => x.Name.Contains(filtername));
            }

            return View(filteredProducts);
        }

        [Route("products/{id:int}")]
        public IActionResult View(int id)
        {
            Product product = myProducts.FirstOrDefault(x => x.Id == id);

            //Task 11 - Bobro Mykola
            if (product is null)
            {
                return RedirectToAction("ProductNotFound", new { id = id });
            }
            //Task 11 - end

            return View(product);
        }

        public IActionResult ProductNotFound(int? id)
        {
            return View(id);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Product product = myProducts.FirstOrDefault(x => x.Id == id);

            return View(product);
        } 

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            var existingProduct = myProducts.FirstOrDefault(x => x.Id == product.Id);

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;

            return RedirectToAction("Index");
        } 
        
        [HttpPost]
        //[Route("Products/create")]
        //[Route("Products/new")]
        public IActionResult Create(Product product)
        {
            if(product.Name == null || product.Description == null)
            {
                ViewBag.ErrorMessage = "Please fill in all fields.!";
                return View(product); 
            }

            myProducts.Add(product);

            return RedirectToAction("Index"); 
        }

        [HttpGet]
        //[Route("Products/create")]
        //[Route("Products/new")]
        public IActionResult Create()
        {
            Product newProduct = new Product();

            newProduct.Id = myProducts.Any() ? myProducts.Max(x => x.Id) + 1 : 1;

            return View(newProduct);
        }

        public IActionResult Delete(int id)
        {
            Product product = myProducts.FirstOrDefault(x => x.Id == id);

            if (product != null)
            {
                myProducts.Remove(product);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
