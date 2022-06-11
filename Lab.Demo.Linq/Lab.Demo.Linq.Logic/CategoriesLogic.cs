using Lab.Demo.Linq.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Demo.Linq.Logic
{
    public class CategoriesLogic : BaseLogic, IABMLogic<Categories>
    {
        public void Add(Categories item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Categories> GetAll()
        {
            return context.Categories.ToList();
        }
        public List<Categories> GetAllAssociated()
        {
            var queryalt = context.Categories
                .Join(context.Products,
                        c => c.CategoryID,
                        p => p.CategoryID,
                        (c, p) => c);

            return queryalt.AsEnumerable().Distinct(new CategoriaComparerByName()).ToList();
        }

        private class CategoriaComparerByName : IEqualityComparer<Categories>
        {
            public bool Equals(Categories x, Categories y)
            {
                var x1 = x;
                var y1 = y;
                return x1.CategoryName.Equals(y1.CategoryName);
            }
            public int GetHashCode(Categories cat)
            {
                return cat.CategoryName.GetHashCode();
            }
        }
        public void Update(Categories item)
        {
            throw new NotImplementedException();
        }
    }

}
