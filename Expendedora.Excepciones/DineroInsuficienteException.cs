using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expendedora2.Excepciones
{
    public class DineroInsuficienteException:Exception
    {
        public DineroInsuficienteException(string mensaje): base(mensaje)
        {
            Console.WriteLine(mensaje);
        }
    }
}
