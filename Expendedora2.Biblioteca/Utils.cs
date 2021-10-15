using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expendedora2.Biblioteca
{
    public static class Utils
    {

        public static int PedirInt(string nombre)
        {
            int valor = 0;
            bool validar;
            do
            {
                validar = true;
                Console.WriteLine(nombre);
                try
                { valor = int.Parse(Console.ReadLine()); }
                catch (Exception)
                {
                    validar = false;
                    MsjErr();
                }

                if (!esValido(valor))
                {
                    MsjErr();
                    validar = false;
                }

            } while (!validar);

            return valor;
        }
        public static double PedirDouble(string nombre)
        {
            double valor = 0;
            bool validar;
            do
            {
                validar = true;
                Console.WriteLine(nombre);
                try
                { valor = double.Parse(Console.ReadLine()); }
                catch (Exception)
                {
                    validar = false;
                    MsjErr();
                }

                if (!esValido(valor))
                {
                    MsjErr();
                    validar = false;
                }

            } while (!validar);

            return valor;
        }
        public static string PedirNombre(string nombre)

        {
            string valor;
            bool validar;
            do
            {
                validar = true;
                Console.WriteLine(nombre);
                valor = Console.ReadLine();

                if (!esValido(valor))
                {
                    MsjErr();
                    validar = false;
                }

            } while (!validar);

            return valor;
        }
        public static DateTime PedirFecha(string nombre)
        {
            string valor;
            bool validar;
            DateTime fecha = DateTime.Today;
            do
            {
                validar = true;
                Console.WriteLine(nombre);
                valor = Console.ReadLine();
                if (esValidofecha(valor))
                {
                    fecha = DateTime.Parse(valor);
                }

                else
                {
                    validar = false;
                    MsjErr();
                }


            } while (!validar);

            return fecha;
        }
        public static bool esValido(string valor)
        {
            if (valor == " ")
            {
                return false;
            }

            if (valor == null)
            {
                return false;
            }
            if (valor.Length < 1)
            {
                return false;
            }
            if (int.TryParse(valor, out int i))
            {
                return false;
            }

            return true;
        }
        // Sobrecarga de metodo esValido
        public static bool esValido(int valor)
        {

            if (valor < 0)
            {
                return false;
            }

            return true;
        }
        public static bool esValido(double valor)
        {

            if (valor < 0)
            {
                return false;
            }

            return true;
        }
        public static bool esValidofecha(string valor)
        {
            if (!DateTime.TryParse(valor, out DateTime fecha))
            {
                return false;
            }


            if (fecha.Year < 1910)
            {
                return false;
            }
            if (fecha.Year > 2021)
            {
                return false;
            }

            return true;
        }

        public static void MsjErr()
        {
            Console.Clear();
            Console.WriteLine("El valor ingresado es incorrecto. Intentelo nuevamente");
        }
        public static void MsjErr(string mensaje)
        {
            Console.Clear();
            Console.WriteLine(mensaje);
        }
        public static string ConvertirFecha(DateTime fecha)
        {
            string fecha2 = fecha.ToString("yyyy-mm-dd");
            return fecha2;
        }
        public static bool PedirSoN(string nombre)
        {
            bool estado;
            string SoN;
            do
            {
                estado = true;
                Console.WriteLine(nombre);
                SoN = Console.ReadLine();
                if (SoN.ToUpper() != "S" && SoN.ToUpper() != "N")
                {
                    estado = false;
                    MsjErr();
                }
            } while (!estado);

            if (SoN.ToUpper() == "S") { return true; }
            return false;

        }
        public static bool SoN(string mensaje)
        {
            bool Valido = false;
            if (mensaje.ToUpper() == "S" || mensaje.ToUpper() == "N")
            {
                Valido = true;
            }
            return Valido;
        }

    }
}
      

