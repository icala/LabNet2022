using Lab.Demo.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Demo.EF.UI
{
    internal class Program
    {
        EmployeesLogic employeesLogic = new EmployeesLogic();
        static void Main(string[] args)
        {
            var menu = new MenuConsola();
            menu.Menu();
        }

        
    }
}
