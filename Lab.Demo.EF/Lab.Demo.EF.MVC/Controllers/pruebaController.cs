using Lab.Demo.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.Demo.EF.MVC.Views
{
    public class pruebaController : Controller
    {
        public CategoriesLogic categoriesLogic;
        public pruebaController() : base()
        {
            categoriesLogic = new CategoriesLogic();
        }


        // GET: prueba
        public ActionResult Index()
        {
            var categories = categoriesLogic.GetAll();
            return View(categories);
        }

        // GET: prueba/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: prueba/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: prueba/Create
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

        // GET: prueba/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: prueba/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: prueba/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: prueba/Delete/5
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
