using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Ejercicio1();
            program.Ejercicio2();
            program.Ejercicio3();
            program.Ejercicio4();
            Console.ReadLine();
        }

        void Ejercicio1()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Ejercicio1 (División)");
            try
            {
                var calc = new Calculadora();
                calc.ImprimirDivision();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("La división ya terminó.");
            }
        }

        void Ejercicio2()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Ejercicio2 (División Chuck)");
            try
            {
                var calc = new Calculadora();
                Console.WriteLine("Escriba un dividendo");
                var dividendo = int.Parse(Console.ReadLine());
                Console.WriteLine("Escriba un divisor");
                var divisor = int.Parse(Console.ReadLine());
                var resultado = calc.dividir(dividendo, divisor);
                Console.WriteLine($"Resultado de la división chuck: {resultado}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Solo Chuck Norris divide por cero!");
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Seguro Ingreso una letra o no ingreso nada!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Otro error.");
            }
        }

        void Ejercicio3()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Ejercicio3 (Lanza excepción)");
            var logic = new Logic();
            try
            {
                logic.LanzaExcepcion();
            }
            catch (NotImplementedException ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType().Name);
            
            }
        }

        void Ejercicio4()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Ejercicio4 (Lanza excepción Personalizada)");
            var logic = new Logic();
            try
            {
                logic.LanzaExcepcion2();
            }
            catch (MiExcepcion ex)
            {

                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType().Name);

            }
        }
    }
}
