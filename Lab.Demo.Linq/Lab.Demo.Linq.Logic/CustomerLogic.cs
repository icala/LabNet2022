using Lab.Demo.Linq.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Demo.Linq.Logic
{
    public class CustomerLogic : BaseLogic, IABMLogic<Customers>
    {
        public void Add(Customers item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customers> GetAll()
        {
            return context.Customers.ToList();
        }
        public Customers GetFirstThatAddressContains(string cadena)
        {
            return context.Customers.First(c => c.Address.Contains(cadena));
        }

        public List<Customers> GetAllFromWARegion()
        {
            return context.Customers.Where(c => c.Region == "WA").ToList();
        }

        public List<Customers> GetFirst3FromWARegion(){
            return context.Customers.Where(c => c.Region == "WA").Take(3).ToList();
        }
        public List<string> GetNames()
        {
            var query = from c in context.Customers
                        select c.CompanyName;

            return query.ToList();
        }

        public List<Tuple<Customers,Orders>> GetFromWARegionAndNewerThan19970101() {
            var query = from c in context.Customers
                        join o in context.Orders on c.CustomerID equals o.CustomerID
                        where c.Region == "WA" && o.OrderDate > new DateTime(1997, 1, 1)
                        select new {c,o};

            return query.AsEnumerable().Select(t => new Tuple<Customers, Orders>(t.c,t.o)).ToList();
        }

        public List<Tuple<Customers, int>> GetCustomersAndAssociatedOrdersQuantity()
        {
            var query = from c in context.Customers
                        join o in context.Orders on c.CustomerID equals o.CustomerID
                        group c by c.CustomerID into gr
                        select new {cust = gr.FirstOrDefault(), cant = gr.Count()};

            return query.AsEnumerable().Select(item => new Tuple<Customers, int>(item.cust, item.cant )).ToList();
        }

        public void Update(Customers item)
        {
            throw new NotImplementedException();
        }
    }
}
