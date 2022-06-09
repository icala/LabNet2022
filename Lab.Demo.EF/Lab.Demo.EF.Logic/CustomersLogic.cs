using Lab.Demo.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Demo.EF.Logic
{
    public class CustomersLogic : BaseLogic, IABMLogic<Customers>
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

        public void Update(Customers item)
        {
            throw new NotImplementedException();
        }


    }
}
