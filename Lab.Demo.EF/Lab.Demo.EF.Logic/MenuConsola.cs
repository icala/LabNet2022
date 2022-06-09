using Lab.Demo.EF.Common;
using Lab.Demo.EF.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Demo.EF.Logic
{
    public class MenuConsola
    {

        public void Menu()
        {
            while (true) {
                int opcion = LeerOpcion();
                switch (opcion) {
                    case 1:
                        ListarEmpleados();
                        break;
                    case 2:
                        ListarClientes();
                        break;
                    case 3:
                        ListarCategorias();
                        break;
                    case 4:
                        CrearCategoria();
                        break;
                    case 5:
                        BorrarCategoria();
                        break;
                    case 6:
                        ActualizarCategoria();
                        break;
                    default:
                        System.Environment.Exit(0);
                        break;
                }
            }

        }

        private void ImprimirOpciones()
        {
            Console.WriteLine("------------------");
            Console.WriteLine("Opciones:\n");
            Console.WriteLine("1 Mostrar lista de empleados");
            Console.WriteLine("2 Mostrar lista de clientes");
            Console.WriteLine("3 Mostrar lista de categorias");
            Console.WriteLine("4 Crear una categoria");
            Console.WriteLine("5 Borrar una categoria");
            Console.WriteLine("6 Actualizar una categoria");
            Console.WriteLine("0 Salir");
            
        }

        private int LeerOpcion()
        {
            ImprimirOpciones();
            string input = Console.ReadLine();
            int number;
            int[] opciones = { 0, 1, 2, 3, 4, 5 ,6};
            while (!int.TryParse(input, out number) || !opciones.Contains (int.Parse(input)) )
            {
                Console.WriteLine($"La opcion no existe, pruebe nuevamente");
                ImprimirOpciones();
                input = Console.ReadLine();
            }
            return number;
        }


        private void ListarEmpleados()
        {
            Console.WriteLine("Lista de Empleados");
            EmployeesLogic employeesLogic = new EmployeesLogic();
            
            foreach(var e in employeesLogic.GetAll())
            {
                Console.WriteLine($"{e.LastName}, {e.FirstName}");
            }
        }

        private void ListarClientes()
        {
            Console.WriteLine("Lista de Clientes");
            CustomersLogic customersLogic = new CustomersLogic();

            foreach (var c in customersLogic.GetAll())
            {
                Console.WriteLine($"{c.CustomerID}, {c.CompanyName}");
            }
        }

        private void ListarCategorias()
        {
            Console.WriteLine("Lista de Categorias");
            CategoriesLogic categoriesLogic = new CategoriesLogic();

            foreach (var c in categoriesLogic.GetAll())
            {
                Console.WriteLine($"{String.Format("{0,6}", c.CategoryID)}, {c.CategoryName.PadRight(15, ' ')}, {c.Description}");
            }
        }


        private void CrearCategoria()
        {
            Console.WriteLine("Crear Categoria");
            Console.WriteLine("Introduzca el nombre(15 Caracteres max.):");
            var nombreNuevo = Console.ReadLine();
            while (nombreNuevo.Length == 0 || nombreNuevo.Length > 15)
            {
                Console.WriteLine("Campo obligatorio");
                Console.WriteLine("Introduzca el nombre(15 Caracteres max.):");
                nombreNuevo = Console.ReadLine();
            }
            Console.WriteLine("Introduzca descripcion:");
            var descripcionNueva = Console.ReadLine();
            CategoriesLogic categoriesLogic = new CategoriesLogic();
            var idNuevo = categoriesLogic.GetNextId();
            categoriesLogic.Add(new Categories() { CategoryID= idNuevo, CategoryName=nombreNuevo,Description=descripcionNueva,});
        }

        private void BorrarCategoria()
        {
            Console.WriteLine("Borrar Categoria");
            Console.WriteLine("Introduzca el id de la categoria:(int)");
            var input = Console.ReadLine();
            int id;
            while (!int.TryParse(input,out id))
            {
                Console.WriteLine("No es entero");
                Console.WriteLine("Borrar Categoria");
                Console.WriteLine("Introduzca el id de la categoria:(int)");
                input = Console.ReadLine();
            }
            CategoriesLogic categoriesLogic = new CategoriesLogic();
            try
            {

            categoriesLogic.Delete(id);
            }catch(IdCategoryNotFoundException e1)
            {
                Console.WriteLine(e1.Message);
            }
            catch (DbUpdateException e)
            {
                //Console.WriteLine(e.InnerException);
                // Pongo este msj porque no se como validar que la InnerException es por la integridad referencial
                // y dijeron que no mostraramos errores técnicos como seria e.InnerException
                Console.WriteLine("Error al actualizar la base de datos, probablemente hay productos que tienen esta categoria, por lo tanto no puede ser borrada");
                
            }
        }

        private void ActualizarCategoria()
        {
            Console.WriteLine("Actualizar Categoria");
            Console.WriteLine("Introduzca el id de la categoria:(int)");
            var input = Console.ReadLine();
            int id;
            while (!int.TryParse(input, out id))
            {
                Console.WriteLine("No es entero");
                Console.WriteLine("Actualizar Categoria");
                Console.WriteLine("Introduzca el id de la categoria:(int)");
                input = Console.ReadLine();
            }
            Console.WriteLine("Introduzca el nuevo nombre:(15 Caracteres max.):");
            var nombreNuevo = Console.ReadLine();
            while (nombreNuevo.Length == 0 || nombreNuevo.Length > 15)
            {
                Console.WriteLine("Campo obligatorio");
                Console.WriteLine("Introduzca el nuevo nombre:(15 Caracteres max.):");
                nombreNuevo = Console.ReadLine();
            }
            Console.WriteLine("Introduzca la nueva descripcion:");
            var descripcionNueva = Console.ReadLine();

        CategoriesLogic categoriesLogic = new CategoriesLogic();
            var categoriaModificada = new Categories()
            {
                CategoryID = id,
                CategoryName = nombreNuevo,
                Description = descripcionNueva
            };
            try
            {
                categoriesLogic.Update(categoriaModificada);
            }catch (IdCategoryNotFoundException e1)
            {
                Console.WriteLine(e1.Message);
            }
            catch (DbUpdateException e2)
            {
                
                Console.WriteLine("Error al actualizar la base de datos");
            }
            catch (Exception){
                Console.WriteLine("Error al actualizar la base de datos");
            }
        }
    }
}
