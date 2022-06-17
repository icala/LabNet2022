using Lab.Demo.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Lab.Demo.EF.Common;

namespace Lab.Demo.EF.Logic
{
    public class CategoriesLogic : BaseLogic, IABMLogic<Categories>
    {
        public void Add(Categories item)
        {
            context.Categories.Add(item);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var categoriaABorrar = context.Categories.FirstOrDefault(c => c.CategoryID == id);
            if (categoriaABorrar == null) throw new IdCategoryNotFoundException();
            context.Categories.Remove(categoriaABorrar);
            context.SaveChanges();
        }

        public List<Categories> GetAll()
        {
            return context.Categories.ToList();
        }

        public Categories GetCategoryById(int idCategory)
        {
            try
            {
            return context.Categories.Find(idCategory);
            }
            catch (InvalidOperationException)
            {
                throw new IdCategoryNotFoundException();
            }              
        }

        public void Update(Categories item)
        {
            Categories categoriaUpdate = context.Categories.FirstOrDefault(c => c.CategoryID == item.CategoryID);
            if (categoriaUpdate == null) throw new IdCategoryNotFoundException();
            categoriaUpdate.Description = item.Description;
            categoriaUpdate.CategoryName = item.CategoryName;
            context.SaveChanges();

        }

        public int GetNextId()
        {
            var ultimaCat = context.Categories.OrderByDescending(c => c.CategoryID).FirstOrDefault();
            if (ultimaCat == null)
                return 1;
            return ultimaCat.CategoryID;
        }


    }
}
