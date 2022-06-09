using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Demo.EF.Common
{
    public class IdCategoryNotFoundException : Exception
    {
        public IdCategoryNotFoundException() : base("No existe categoria con ese id")
        { }
    }
}
