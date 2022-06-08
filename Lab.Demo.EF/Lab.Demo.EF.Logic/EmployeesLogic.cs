using Lab.Demo.EF.Data;
using Lab.Demo.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Demo.EF.Logic
{
    public class EmployeesLogic:BaseLogic,IABMLogic<Employees>
    {
        public List<Employees> GetAll()
        {
            return context.Employees.ToList();
        }

        void IABMLogic<Employees>.Add(Employees item)
        {
            throw new NotImplementedException();
        }

        void IABMLogic<Employees>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        void IABMLogic<Employees>.Update(Employees item)
        {
            throw new NotImplementedException();
        }
    }
}
