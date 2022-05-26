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
            transportes.Add(new Omnibus(100, "1"));
            transportes.Add(new Omnibus(30, "2"));
            transportes.Add(new Omnibus(10, "3"));
            transportes.Add(new Omnibus(5, "4"));
            transportes.Add(new Omnibus(33, "5"));
            transportes.Add(new Taxi(4, "1"));
            transportes.Add(new Taxi(2, "2"));
            transportes.Add(new Taxi(1, "3"));
            transportes.Add(new Taxi(2, "4"));
            transportes.Add(new Taxi(3, "5"));

            foreach (var t in transportes)
            {
                Console.WriteLine(t);
            }
            Console.ReadLine();
        }
    }
}
