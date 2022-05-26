using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var transportes = new List<TransportePublico>();
            for (int i = 0; i < 5; i++)
            {
                transportes.Add(new Omnibus(LeerCantidad("omnibus"), (i + 1).ToString()));
            }
            for (int i = 0; i < 5; i++)
            {
                transportes.Add(new Taxi(LeerCantidad("taxi"), (i + 1).ToString()));
            }


            foreach (var t in transportes)
            {
                Console.WriteLine(t);
            }
            Console.ReadLine();
        }

        public static int LeerCantidad(string nombre)
        {
            Console.WriteLine($"Inserte cantidad de pasajeros para este {nombre}:");
            string input = Console.ReadLine();
            int number;
            while (!Int32.TryParse(input, out number))
            {
                Console.WriteLine($"No era un numero entero");
                Console.WriteLine($"Inserte cantidad de pasajeros para este {nombre}:");
                input = Console.ReadLine();
            }
            return int.Parse(input);
        }
    }
}
