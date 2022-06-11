using Lab.Demo.Linq.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Demo.Linq.Logic
{
    public class ProductsLogic : BaseLogic, IABMLogic<Products>
    {
        public void Add(Products item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Products> GetAll()
        {
            return context.Products.ToList();
        }
        public List<Products> GetAllOrderByName()
        {
            return context.Products.OrderBy(p=> p.ProductName).ToList();
        }
        public List<Products> GetAllOrderByUnitsInStockDescending()
        {
            return context.Products.OrderByDescending(p=> p.UnitsInStock).ToList();
        }
        public Products GetFirstProduct()
        {
            var query = from p in context.Products
                        select p;

            return query.First();
        }
        public void Update(Products item)
        {
            throw new NotImplementedException();
        }

        public List<Products> GetOutOfStock()
        {
            var query = context.Products
                        .Where(p => p.UnitsInStock < 1);    
            
            return query.ToList();
        }


        public List<Products> GetInStockAndItCostsOver3()
        {
            var query = from p in context.Products
                        where p.UnitsInStock > 0 &&  p.UnitPrice > 3
                        select p;

            return query.ToList();
        }

        public Products GetId789OrNull()
        {
            return context.Products.FirstOrDefault(p => p.ProductID == 789);
        }
    }
}
