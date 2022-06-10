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

        public void Update(Customers item)
        {
            throw new NotImplementedException();
        }
    }
}
