using Lab.Demo.EF.Common;
using Lab.Demo.EF.Entities;
using Lab.Demo.EF.Logic;
using Lab.Demo.EF.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.Demo.EF.MVC.Controllers
{
    public class CategoriesController : Controller
    {
        CategoriesLogic categoriesLogic;
        public CategoriesController()
        {
            categoriesLogic = new CategoriesLogic();
        }
        // GET: Categories
        public ActionResult Index()
        {
            var categories = categoriesLogic.GetAll();
            var model = categories.Select(c => new CategoriesDTO(c));

            return View(model);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
            var category = categoriesLogic.GetCategoryById(id);
            var categoryDTO = new CategoriesDTO(category);
            return View(categoryDTO);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        public ActionResult Edit(CategoriesDTO category)
        {
            try
            {
                var categoriaModificada = new Categories()
                {
                    CategoryID = category.CategoryID,
                    CategoryName = category.CategoryName,
                    Description = category.Description
                };
                categoriesLogic.Update(categoriaModificada);
                return RedirectToAction("Index");
            }
            catch (IdCategoryNotFoundException e1)
            {
                //Console.WriteLine(e1.Message);
                return View();
            }
            catch
            {
                Console.WriteLine("Error al actualizar la base de datos");
                return View();
            }
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Categories/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
