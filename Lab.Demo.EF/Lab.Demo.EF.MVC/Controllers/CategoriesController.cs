using Lab.Demo.EF.Common;
using Lab.Demo.EF.Entities;
using Lab.Demo.EF.Entities.DTOs;
using Lab.Demo.EF.Logic;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.Demo.EF.MVC.Controllers
{
    public class CategoriesController : Controller
    {
        CategoriesLogic categoriesLogic;
        ProductsLogic productsLogic;
        public CategoriesController()
        {
            categoriesLogic = new CategoriesLogic();
            productsLogic = new ProductsLogic();
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
            var category = categoriesLogic.GetCategoryById(id);
            var products = productsLogic.GetFromCategory(id);
            var productsDTO = products.Select(p => new ProductsDTO(p)).ToList();
            var model = new CategoriesDatailsDTO() {
                Category = new CategoriesDTO(category),
                Products = productsDTO
            };
            return View(model);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        public ActionResult Create(CategoriesDTO category)
        {
            try
            {
                var idNuevo = categoriesLogic.GetNextId();
                categoriesLogic.Add(new Categories() { CategoryID = idNuevo, CategoryName = category.CategoryName, Description = category.Description, });


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
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)
        {
            var category = categoriesLogic.GetCategoryById(id);
            var categoryDTO = new CategoriesDTO(category);
            return View(categoryDTO);
        }

        // POST: Categories/Delete/5
        [HttpPost]
        public ActionResult Delete(CategoriesDTO category)
        {
            try
            {
                categoriesLogic.Delete(category.CategoryID);

                return RedirectToAction("Index");
            }

            catch (IdCategoryNotFoundException e1)
            {
                return View();
            }
            catch (DbUpdateException e)
            {
                //Console.WriteLine("Error al actualizar la base de datos");
                var ej = e.InnerException.GetType();
                if (e.InnerException is System.Data.Entity.Core.UpdateException)
                {
                    if (e.InnerException.InnerException is SqlException)
                    {
                        var sqlex = (SqlException)e.InnerException.InnerException;
                        if (sqlex.Number == 547)
                        {
                            var errorMsg = "Hay productos que tienen esta categoria, por lo tanto no puede ser borrada";
                            return View("ErrorInfo", new ErrorForView() { ErrorMsg = errorMsg });
                        }
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
