using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ConsumoPHP
{
    class Program
    {
        public static bool BadOption = false;

        static void Main(string[] args)
        {
            Console.Title = "* Consumo de WS de PHP - http://serviciostests.000webhostapp.com/servicios.php?wsdl *";

            ConsoleKeyInfo input;

            string result;// = string.Empty;

            string nombre;// = string.Empty;
            string mensaje;// = string.Empty;
            double precio;
            int stock;
            int idp;


            // Contador:
            Stopwatch tiempo;


            ServiceReferencePHP.serviciosPortTypeClient client = new ServiceReferencePHP.serviciosPortTypeClient();

            Console.CursorVisible = false;
            do
            {
                if (!BadOption)
                {
                    MostrarMenu();
                }

                //tecla = Console.ReadLine();
                input = Console.ReadKey(true);

                System.Diagnostics.Debug.WriteLine(" # Tecla pulsada menú: {0}, {1}", input.Key, input.Modifiers);

                BadOption = true;
                // Para ejecutar las opciones hay que pulsar tecla ALT + núm de opción
                if ((input.Modifiers & ConsoleModifiers.Alt) == ConsoleModifiers.Alt)
                {
                    BadOption = false;

                    switch (input.Key)
                    {
                        case ConsoleKey.D0: // CURSO: 76. Consumo del método HelloWorld
                            Console.Clear();
                            // Inicia el contador:
                            tiempo = Stopwatch.StartNew();

                            // Código del programa...
                            result = client.HelloWorld();

                            tiempo.Stop();
                            
                            // Para el contador e imprime el resultado:
                            Console.WriteLine(result+"\n\n\tTIEMPO: " + tiempo.Elapsed.Milliseconds.ToString() + " ms");                                                        
                            
                            Console.ReadKey(true);
                            break;
                        case ConsoleKey.D1: // CURSO: 77. Consumo del método Saludar
                            Console.Clear();
                            // Inicia el contador:
                            tiempo = Stopwatch.StartNew();

                            // Código del programa...
                            result = client.Saludar("Ana");
                            tiempo.Stop();

                            // Para el contador e imprime el resultado:
                            Console.WriteLine(result + "\n\n\tTIEMPO: " + tiempo.Elapsed.Milliseconds.ToString() + " ms");

                            Console.ReadKey(true);
                            break;
                        case ConsoleKey.D2: // CURSO: 78. Consumo del método GuardarLog
                            Console.Clear();
                            // Inicia el contador:
                            tiempo = Stopwatch.StartNew();

                            // Código del programa...                            

                            result = client.GuardarLog("Mensaje desde .Net");

                            // Para el contador e imprime el resultado:
                            Console.WriteLine(result + "\n\n\tTIEMPO: " + tiempo.Elapsed.Milliseconds.ToString() + " ms");
                            Console.ReadKey(true);
                            break;
                        case ConsoleKey.D3:
                            Console.Clear();
                            break;
                        case ConsoleKey.D4:
                            Console.Clear();
                           
                            break;
                        case ConsoleKey.D5:
                            Console.Clear();
                            break;
                        case ConsoleKey.D6:
                            Console.Clear();
                            
                            break;
                        case ConsoleKey.D7:
                            Console.Clear();
                            
                            break;
                        case ConsoleKey.D8:
                            Console.Clear();
                           
                            break;
                        case ConsoleKey.D9:
                            Console.Clear();
                            
                            break;
                        case ConsoleKey.A:
                            Console.Clear();
                            break;
                        case ConsoleKey.B:
                            Console.Clear();
                            break;
                        case ConsoleKey.C:
                            Console.Clear();
                            break;
                        case ConsoleKey.D:
                            Console.Clear();
                            break;
                        case ConsoleKey.E:
                            Console.Clear();
                            break;
                        case ConsoleKey.F:
                            Console.Clear();
                            break;
                        case ConsoleKey.G:
                            Console.Clear();
                            break;
                        case ConsoleKey.H: // cambiar a autenticación Básica en IIS
                            Console.Clear();
                            break;

                        default:
                            BadOption = true;
                            System.Diagnostics.Debug.WriteLine("Dentro swtich" + input.Key);
                            break;
                    }
                }
            } while (input.Key != ConsoleKey.Escape);
        }

        #region "Métodos estáticos"

        /// <summary>
        /// Muestra el menú por pantalla
        /// </summary>
        public static void MostrarMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(0, 1);
            Console.Write(" ".PadRight(80, ' '));
            Console.SetCursorPosition(19, Console.CursorTop);
            Console.WriteLine("Elija una opción: (Pulse tecla ALT + Opción)\n");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(5, Console.CursorTop);
            Console.WriteLine("0.- HelloWorld()".PadRight(30, ' ') + "*");
            Console.SetCursorPosition(5, Console.CursorTop);
            Console.WriteLine("1.- Saludar(*)".PadRight(30, ' '));
            Console.SetCursorPosition(5, Console.CursorTop);
            Console.WriteLine("2.- GuardarLog(*)".PadRight(30, ' ') + "*");
            Console.SetCursorPosition(5, Console.CursorTop);
            Console.WriteLine("3.- Sumar(*,*)");
            Console.SetCursorPosition(5, Console.CursorTop);
            Console.WriteLine("4.- ObtenerFrutas()");
            Console.SetCursorPosition(5, Console.CursorTop);
            Console.WriteLine("5.- GuardarFrutas(*)");
            Console.SetCursorPosition(5, Console.CursorTop);
            Console.WriteLine("6.- ObtenerEquipos()");
            Console.SetCursorPosition(5, Console.CursorTop);
            Console.WriteLine("7.- GuardarEquipos()".PadRight(30, ' ') + "*");
            Console.SetCursorPosition(5, Console.CursorTop);
            Console.WriteLine("8.- GuardarXML()");
            Console.SetCursorPosition(5, Console.CursorTop);
            Console.WriteLine("9.- RetornarJSON()");
            Console.SetCursorPosition(5, Console.CursorTop);
            Console.WriteLine("A.- GuardarJSON()");
            Console.SetCursorPosition(5, Console.CursorTop);
            Console.WriteLine("B.- ObtenerProductos()");
            Console.SetCursorPosition(5, Console.CursorTop);
            Console.WriteLine("C.- ObtenerProducto(*)");
            Console.SetCursorPosition(5, Console.CursorTop);
            Console.WriteLine("D.- ActualizarProducto(*)");
            Console.SetCursorPosition(5, Console.CursorTop);
            Console.WriteLine("E.- GuardarProducto(*)");
            Console.SetCursorPosition(5, Console.CursorTop);
            Console.WriteLine("F.- EliminarProducto(*)");
            Console.SetCursorPosition(5, Console.CursorTop);
            Console.WriteLine("G.- ObtenerFecha()");
            Console.SetCursorPosition(5, Console.CursorTop);
            Console.WriteLine("H.- ObtenerHora()");
            Console.SetCursorPosition(5, Console.CursorTop);
            Console.WriteLine("I.- ()");

            if (Console.CursorTop < 24)
                Console.CursorTop = 24;

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(" ".PadRight(80, ' '));
            Console.SetCursorPosition(10, Console.CursorTop);
            Console.Write("Pulse ESC para Salir     - Versión: 1.0.0   Juan Bustos © 2020");

            Console.ResetColor();
        }
        #endregion
    }
}
