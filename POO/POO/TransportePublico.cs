using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    public abstract class TransportePublico {
        public int Pasajeros { get; set; }
        public string Nombre { get; set; }
        public TransportePublico(int pasajeros, string nombre)
        {
            Pasajeros = pasajeros;
            Nombre = nombre;
        }
      
        public string Avanzar()
        {
            return "Avanzando";
        }

        public string Detenerse()
        {
            return "Deteniendo";
        }

    }
}
