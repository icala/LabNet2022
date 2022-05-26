using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Taxi : TransportePublico
    {
        public Taxi(int pasajeros,string nombre) : base(pasajeros,nombre) { }

        public override string ToString()
        {
            return $"Taxi {Nombre}: {Pasajeros} pasajeros";
        }
    }
}
