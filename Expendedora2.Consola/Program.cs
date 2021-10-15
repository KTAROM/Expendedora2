using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expendedora2.Biblioteca;
using Expendedora2.Biblioteca.Entidades;
using Expendedora2.Excepciones;

namespace Expendedora2.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Expendedora LaMaquina = new Expendedora();
            bool encendida;
            do
            {
                Console.Clear();
                encendida = true;
                DesplegarMenu();
                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        LaMaquina.EncenderMaquina();
                        if (LaMaquina.Encendida)
                        { Console.WriteLine("La máquina se encuentra encendida");
                            Console.ReadKey();
                        }
                        break;
                    case "2":
                        ListarLatas(LaMaquina);
                        break;
                    case "3":
                        AgregarLata(LaMaquina);
                        break;
                    case "4":
                        ExtraerLata(LaMaquina);
                        break;
                    case "5":
                        ObtenerBalance(LaMaquina);
                        break;
                    case "6":
                        MostrarStock(LaMaquina);
                        break;
                    case "7":
                        encendida = false;
                        break;
                    default:
                        Utils.MsjErr();
                        break;
                }
            } while (encendida);
        }

        public static void DesplegarMenu()
        {
            Console.WriteLine("BIENVENIDO A LA MAQUINA!!!\n" +
                "Ingrese la opción desea:\n" +
                "1- Encender la máquina\n" +
                "2- Listar latas disponibles\n" +
                "3- Ingresar nueva lata\n" +
                "4- Extraer una lata del stock\n" +
                "5- Mostrar Balance\n" +
                "6- Mostrar Stock completo\n" +
                "7- Salir");
                
        }


        public static void AgregarLata(Expendedora expendedora)
        {
            if (expendedora.Encendida)
            {
                try
                {
                    try
                    {
                        string codigo = Utils.PedirNombre("Ingrese el código de la lata");
                        string nombre = Utils.PedirNombre("Ingrese el nombre de la lata");
                        string sabor = Utils.PedirNombre("Indique el sabor de la bebida");
                        double precio = Utils.PedirDouble("Ingrese el valor de la lata");
                        double volumen = Utils.PedirDouble("Indique la capacidad de la lata en cc");
                        int cantidad = Utils.PedirInt("Ingrese la cantidad de latas");
                        Lata lata1 = new Lata(codigo, nombre, sabor, precio, volumen, cantidad);
                        expendedora.AgregarLata(lata1);
                        Console.WriteLine("La lata " + nombre + " se ingreso correctamente");
                        Console.ReadKey();
                    }
                    catch (CodigoInvalidoException ex)
                    {
                        Console.ReadKey();
                    }
                }
                catch (DineroInsuficienteException ex)
                {
                    Console.ReadKey();
                }
                
                catch (CapacidadInsuficienteException ex)
                {
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Debe enceder la máquina previamente");
                Console.ReadKey();
            }
        }

        public static void ExtraerLata(Expendedora expendedora)
        {
            if (expendedora.Encendida)
            {
                if (!expendedora.EstaVacia())
                { try
                    {
                        ListarLatas(expendedora);
                        string codigo = Utils.PedirNombre("Ingrese el codigo de la lata que desea extraer");
                        double dinero = Utils.PedirDouble("Indique el dinero que ingresará");
                        Lata lata1= expendedora.ExtraerLata(codigo, dinero);
                        double vuelto = 0;
                        if(lata1.Precio<dinero)
                        {
                            vuelto = dinero - lata1.Precio;
                        }
                        Console.WriteLine("La lata " + lata1.Nombre + " se ha extraído\nSu vuelto es $ "+vuelto);
                        Console.ReadKey();
                    }
                catch (CodigoInvalidoException ex)
                    {
                        Console.ReadKey();
                    }
                 catch (DineroInsuficienteException ex)
                    {
                        Console.ReadKey();
                    }
                    catch (SinStockException ex)
                    {
                        Console.ReadKey();
                    }
                }
                else 
                {
                    Console.WriteLine("Aun no hay Stock en la expendedora");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Debe enceder la máquina previamente");
            }
        }

        public static void ObtenerBalance(Expendedora expendedora)
        {
            if (expendedora.Encendida)
            { Console.WriteLine(expendedora.GetBalance());
                Console.ReadKey();
            }
            
            else
            {
                Console.WriteLine("Debe enceder la máquina previamente");
                Console.ReadKey();
            }
        }

        public static void MostrarStock(Expendedora expendedora)
        {
            if (expendedora.Encendida)
            {
                if (!expendedora.EstaVacia())
                {
                    try
                    {
                        foreach (Lata lata1 in expendedora.ListadoLatas)
                        {
                            Console.WriteLine("Nombre: " + lata1.Nombre + "- Sabor: " + lata1.Sabor + " Precio: $" + lata1.Precio + " / $/L " + lata1.GetPrecioPorLitro() + " - Cantidad: " + lata1.Cantidad);
                        }
                        Console.ReadKey();
                    }
                    catch (SinStockException ex)

                    {
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Aun no hay Stock en la expendedora");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Debe enceder la máquina previamente");
            }

        }
        public static void ListarLatas(Expendedora expendedora)
        {
            if(expendedora.EstaVacia())
            {
                Console.WriteLine("Aún no se han ingresado latas");
            }
            else 
            { 
                Console.WriteLine("LISTADO DE LATAS DISPONIBLES\n");
                foreach (Lata lata1 in expendedora.ListadoLatas)
                {
                    Console.WriteLine(lata1.ToString());
                }
            }
            Console.ReadKey();
                      
        }
    }
    }

