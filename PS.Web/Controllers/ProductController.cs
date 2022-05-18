using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PS.Domain;
using PS.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PS.Web.Controllers
{
    public class ProductController : Controller
    {
      readonly  IProductService prodService;
       readonly  ICategoryService catService;
        // GET: ProductController

        public ProductController(IProductService prodService, ICategoryService catService)
        {
            this.prodService = prodService;
            this.catService = catService;
        }
        public ActionResult Index(String filter)
        {
            if(!String.IsNullOrEmpty(filter))
            return View(prodService.GetMany(p=>p.Name.StartsWith(filter))
                .ToList());
            return View(prodService.GetAll());
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            var categories = catService.GetAll();
            ViewBag.CategoryId = new SelectList(categories, "CategoryId", "Name");
            return View();

            
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product p, IFormFile file)
        {
            try
            {
                if (file != null)
                {
                    p.Image = file.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "uploads", file.FileName);
                    using (Stream stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                prodService.Add(p);
                prodService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
