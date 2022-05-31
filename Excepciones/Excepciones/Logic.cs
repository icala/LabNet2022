using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    internal class Logic
    {
        public void LanzaExcepcion()
        {
            throw new NotImplementedException();
        }

        public void LanzaExcepcion2()
        {
            throw new MiExcepcion("Mensaje de mi excepción");
        }
    }
}
