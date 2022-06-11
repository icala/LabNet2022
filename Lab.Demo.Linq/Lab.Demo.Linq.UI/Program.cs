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
            Ej3();
            Ej4();
            Ej5();
            Ej6();
            Ej7();
            Ej8();
            Ej9();
            Ej10();
            Ej11();
            Ej12();
            Ej13();
        }

        static void Ej1()
        {

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
            Console.WriteLine("Productos en stock que valen mas de 3");
            var productsLogic = new ProductsLogic();
            var productos = productsLogic.GetInStockAndItCostsOver3();
            foreach (var p in productos)
            {
                Console.WriteLine($"{p.ProductID}  -  {p.ProductName}");
            }
            Console.ReadKey(); ;
        }
        static void Ej4()
        {

            Console.Clear();
            Console.WriteLine("Ejercicio 4");
            Console.WriteLine("Clientes de la region WA");
            var customerLogic = new CustomerLogic();
            var clientes = customerLogic.GetAllFromWARegion();
            foreach (var c in clientes)
            {
                Console.WriteLine($"{c.CustomerID}  -  {c.CompanyName}");
            }
            Console.ReadKey(); ;
        }

        static void Ej5()
        {

            Console.Clear();
            Console.WriteLine("Ejercicio 5");
            Console.WriteLine("Producto con id = 789 o null");
            var productsLogic = new ProductsLogic();
            var producto = productsLogic.GetId789OrNull();
            if (producto != null)
            {
                Console.WriteLine($"{producto.ProductID}  -  {producto.ProductName}");
            }
            else
            {
                Console.Write("null");
            }
            Console.ReadKey(); ;
        }


        static void Ej6()
        {

            Console.Clear();
            Console.WriteLine("Ejercicio 6");
            Console.WriteLine("Nombres de clientes");
            var customerLogic = new CustomerLogic();
            var nombres = customerLogic.GetNames();
            foreach (var n in nombres)
            {
                Console.WriteLine($"{n.ToLower()} - {n.ToUpper()}");
            }
            Console.ReadKey(); ;
        }

        static void Ej7()
        {
            Console.Clear();
            Console.WriteLine("Ejercicio 7");
            Console.WriteLine("Join de Clientes de la region 'WA' y Ordenes posteriores al 1/1/97");
            var customerLogic = new CustomerLogic();
            var tuplas = customerLogic.GetFromWARegionAndNewerThan19970101();
            foreach (var t in tuplas)
            {
                Console.WriteLine($"{t.Item1.CompanyName} - {t.Item2.OrderID} - {t.Item2.OrderDate}");
            }
            Console.ReadKey(); ;

        }

        static void Ej8()
        {

            Console.Clear();
            Console.WriteLine("Ejercicio 8");
            Console.WriteLine("3 primeros clientes de la region WA");
            var customerLogic = new CustomerLogic();
            var clientes = customerLogic.GetFirst3FromWARegion();
            foreach (var c in clientes)
            {
                Console.WriteLine($"{c.CustomerID}  -  {c.CompanyName}");
            }
            Console.ReadKey(); ;
        }

        static void Ej9()
        {
            Console.Clear();
            Console.WriteLine("Ejercicio 9");
            Console.WriteLine("Productos ordenados por nombre");
            var productsLogic = new ProductsLogic();
            var productos = productsLogic.GetAllOrderByName();
            foreach (var p in productos)
            {
                Console.WriteLine($"{p.ProductID}  -  {p.ProductName}");
            }
            Console.ReadKey(); ;
        }
        static void Ej10()
        {

            Console.Clear();
            Console.WriteLine("Ejercicio 10");
            Console.WriteLine("Productos ordenados por UnitInStock descendente");
            var productsLogic = new ProductsLogic();
            var productos = productsLogic.GetAllOrderByUnitsInStockDescending();
            foreach (var p in productos)
            {
                Console.WriteLine($"{p.ProductID}  -  {p.ProductName}  -  {p.UnitsInStock}");
            }
            Console.ReadKey(); ;
        }

        static void Ej11()
        {
            Console.Clear();
            Console.WriteLine("Ejercicio 11");
            Console.WriteLine("Categorias asociadas con productos");
            var categoriesLogic = new CategoriesLogic();
            var categorias = categoriesLogic.GetAllAssociated();
            foreach (var c in categorias)
            {
                Console.WriteLine($"{c.CategoryID}  -  {c.CategoryName}");
            }
            Console.WriteLine("--------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Todas las categorias");
            var categorias2 = categoriesLogic.GetAll();
            foreach (var c in categorias2)
            {
                Console.WriteLine($"{c.CategoryID}  -  {c.CategoryName}");
            }
            Console.ReadKey(); ;
        }

        static void Ej12()
        {
            Console.Clear();
            Console.WriteLine("Ejercicio 12");
            Console.WriteLine("Primer Producto de una lista");
            var productsLogic = new ProductsLogic();
            var p = productsLogic.GetFirstProduct();
            Console.WriteLine($"{p.ProductID}  -  {p.ProductName}  -  {p.UnitsInStock}");
            Console.ReadKey(); ;
        }

        static void Ej13()
        {

            Console.Clear();
            Console.WriteLine("Ejercicio 13");
            Console.WriteLine("Clientes con la cantidad de ordenes asociadas");
            var customerLogic = new CustomerLogic();
            var tuplas = customerLogic.GetCustomersAndAssociatedOrdersQuantity();
            foreach (var t in tuplas)
            {
                Console.WriteLine($"{t.Item1.CustomerID} - {t.Item1.CompanyName} - Ordenes asociadas: {t.Item2}");
            }
            Console.ReadKey(); ;
        }
    }
}
