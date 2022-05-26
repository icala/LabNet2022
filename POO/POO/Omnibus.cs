using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Omnibus : TransportePublico
    {
        public Omnibus(int pasajeros, string nombre) : base(pasajeros, nombre)
        {
        }
        public override string ToString()
        {
            return $"Omnibus {Nombre}: {Pasajeros} pasajeros";
        }


    }
}
