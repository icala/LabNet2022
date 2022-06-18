using Lab.Demo.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Lab.Demo.EF.Common;
using System.Data.Entity;

namespace Lab.Demo.EF.Logic
{
    public class CategoriesLogic : BaseLogic, IABMLogic<Categories>
    {
        public void Add(Categories item)
        {
            context.Categories.Add(item);
            context.SaveChanges();
        }
        public async Task AddAsync(Categories item)
        {
            context.Categories.Add(item);
            await context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var categoriaABorrar = context.Categories.FirstOrDefault(c => c.CategoryID == id);
            if (categoriaABorrar == null) throw new IdCategoryNotFoundException();
            context.Categories.Remove(categoriaABorrar);
            context.SaveChanges();
        }
        public async Task DeleteAsync(int id)
        {
            var categoriaABorrar = await context.Categories.FirstOrDefaultAsync(c => c.CategoryID == id);
            if (categoriaABorrar == null) throw new IdCategoryNotFoundException();
            context.Categories.Remove(categoriaABorrar);
            await context.SaveChangesAsync();
        }

        public List<Categories> GetAll()
        {
            return context.Categories.ToList();
        }

        public async Task<List<Categories>> GetAllAsync()
        {
            return await context.Categories.ToListAsync();
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
        public virtual async Task<Categories> GetCategoryByIdAsync(int idCategory)
        {
            try
            {
            return await context.Categories.FindAsync(idCategory);
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
        public async Task UpdateAsync(Categories item)
        {
            Categories categoriaUpdate = await context.Categories.FirstOrDefaultAsync(c => c.CategoryID == item.CategoryID);
            if (categoriaUpdate == null) throw new IdCategoryNotFoundException();
            categoriaUpdate.Description = item.Description;
            categoriaUpdate.CategoryName = item.CategoryName;
            await context.SaveChangesAsync();
        }
    }
}
