using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public static class CalculadoraExtensions
    {
        public static void ImprimirDivision(this Calculadora calc)
        {
            var dividendo = LeerEntero("Inserte un dividendo entero");
            var divisor = LeerEntero("Inserte un divisor entero");
            var resultado = calc.dividir(dividendo, divisor);
            Console.WriteLine($"El resultado de la división entera es: {resultado}");
        }




        private static int LeerEntero(string msg)
        {
            Console.WriteLine(msg);
            string input = Console.ReadLine();
            int number;
            while (!int.TryParse(input, out number))
            {
                Console.WriteLine($"No era un numero entero, pruebe de nuevo");
                Console.WriteLine(msg);
                input = Console.ReadLine();
            }
            return int.Parse(input);
        }


    }
}
