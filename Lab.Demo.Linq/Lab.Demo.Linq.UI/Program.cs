using Lab.Demo.Linq.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Demo.Linq.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ej1();
            Ej2();
        }

        static void Ej1() {
            
            Console.Clear();
            Console.WriteLine("Ejercicio 1");
            Console.WriteLine("Consulta que devuelve el primer cliente que tiene 'Hanover' en la direccion:");
            var customeLogic = new CustomerLogic();
            var customer = customeLogic.GetFirstThatAddressContains("Hanover");
            Console.WriteLine($"Company Name:{customer.CompanyName}");
            Console.WriteLine($"Address:{customer.Address}");
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();
        }

        static void Ej2()
        {

            Console.Clear();
            Console.WriteLine("Ejercicio 2");
            Console.WriteLine("Productos sin stock:");
            var productsLogic = new ProductsLogic();
            var productos = productsLogic.GetOutOfStock();
            foreach (var p in productos)
            {
                Console.WriteLine($"{p.ProductID}  -  {p.ProductName}");
            }
            Console.ReadKey();
        }

        static void Ej3()
        {

            Console.Clear();
            Console.WriteLine("Ejercicio 3");
            Console.WriteLine("");

            Console.ReadKey();
        }
    }
}
