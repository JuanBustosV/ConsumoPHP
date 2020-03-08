using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
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
                            tiempo.Stop();

                            // Para el contador e imprime el resultado:
                            Console.WriteLine(result + "\n\n\tTIEMPO: " + tiempo.Elapsed.Milliseconds.ToString() + " ms");
                            Console.ReadKey(true);
                            break;
                        case ConsoleKey.D3: // CURSO: 79. Consumo del método Sumar
                            Console.Clear();

                            // Inicia el contador:
                            tiempo = Stopwatch.StartNew();

                            // Código del programa...                            

                            result = client.Sumar(4, 3).ToString();
                            tiempo.Stop();

                            // Para el contador e imprime el resultado:
                            Console.WriteLine(result + "\n\n\tTIEMPO: " + tiempo.Elapsed.Milliseconds.ToString() + " ms");
                            Console.ReadKey(true);

                            break;
                        case ConsoleKey.D4: // CURSO: 80. Consumo del método ObtenerFrutas
                            Console.Clear(); 

                            // Inicia el contador:
                            tiempo = Stopwatch.StartNew();

                            // Código del programa...                            
                            string[] frutas = client.ObtenerFrutas();
                            tiempo.Stop();

                            // Para el contador e imprime el resultado:
                            foreach (string fruta in frutas)
                            {
                                Console.WriteLine(fruta);
                            }
                            Console.WriteLine("\n\n\tTIEMPO: " + tiempo.Elapsed.Milliseconds.ToString() + " ms");
                            Console.ReadKey(true);

                            break;
                        case ConsoleKey.D5: // CURSO: 81. Consumo del método GuardarFrutas
                            Console.Clear();

                            string[] fruits = new string[] { "Mango", "Pera", "Plátano" };

                            // Inicia el contador:
                            tiempo = Stopwatch.StartNew();

                            // Código del programa...                            
                            result = client.GuardarFrutas(fruits);
                            tiempo.Stop();

                            // Para el contador e imprime el resultado:
                            Console.WriteLine(result + "\n\n\tTIEMPO: " + tiempo.Elapsed.Milliseconds.ToString() + " ms");
                            Console.ReadKey(true);

                            break;
                        case ConsoleKey.D6: // CURSO: 82. Consumo del método ObtenerEquipos
                            Console.Clear();

                            // Inicia el contador:
                            tiempo = Stopwatch.StartNew();

                            // Código del programa...                            
                            ServiceReferencePHP.Equipos[] equipos = client.ObtenerEquipos();
                            
                            tiempo.Stop();

                            foreach (ServiceReferencePHP.Equipos equipo in equipos)
                            {
                                Console.WriteLine(equipo.nombre + " - " + equipo.pais);
                            }

                            // Para el contador e imprime el resultado:
                            Console.WriteLine("\n\n\tTIEMPO: " + tiempo.Elapsed.Milliseconds.ToString() + " ms");
                            Console.ReadKey(true);
                          
                            break;
                        case ConsoleKey.D7: // CURSO: 83. Consumo del método GuardarEquipos
                            Console.Clear();

                            ServiceReferencePHP.Equipos[] teams = new ServiceReferencePHP.Equipos[]
                            {
                                new ServiceReferencePHP.Equipos() { nombre = "Sevilla", pais = "España"},
                                new ServiceReferencePHP.Equipos() { nombre = "Chealse", pais = "Inglaterra"},
                            };

                            // Inicia el contador:
                            tiempo = Stopwatch.StartNew();

                            // Código del programa...
                            result = client.GuardarEquipos(teams);
                            tiempo.Stop();

                            // Para el contador e imprime el resultado:
                            Console.WriteLine(result + "\n\n\tTIEMPO: " + tiempo.Elapsed.Milliseconds.ToString() + " ms");
                            Console.ReadKey(true);
                            break;
                        case ConsoleKey.D8: // CURSO: 84. Consumo del método GuardarXML
                            Console.Clear();
                            string XmlContent = "<?xml version='1.0' encoding='UTF-8'?><documento><deporte><![CDATA[Futbol]]></deporte><equipos><equipo><nombre><![CDATA[Ajax]]></nombre><pais><![CDATA[Holanda]]></pais></equipo><equipo><nombre><![CDATA[Valencia]]></nombre><pais><![CDATA[España]]></pais></equipo></equipos></documento>";
                            // Inicia el contador:
                            tiempo = Stopwatch.StartNew();

                            // Código del programa...                            
                            result = client.GuardarXML(XmlContent);
                            tiempo.Stop();

                            // Para el contador e imprime el resultado:
                            Console.WriteLine(result + "\n\n\tTIEMPO: " + tiempo.Elapsed.Milliseconds.ToString() + " ms");
                            Console.ReadKey(true);
                            break;
                        case ConsoleKey.D9: // CURSO: 85. Consumo del método RetornarJson
                            Console.Clear();

                            // Inicia el contador:
                            tiempo = Stopwatch.StartNew();

                            // Código del programa...                            

                            result = client.RetornarJson();
                            tiempo.Stop();

                            dynamic data_json = JsonConvert.DeserializeObject(result);
                            Console.WriteLine(data_json.deporte);

                            foreach (dynamic equipo in data_json.equipos)
                            {
                                Console.WriteLine(equipo.nombre + " - " + equipo.pais);
                            }

                            // Para el contador e imprime el resultado:
                            Console.WriteLine("\n\n\tTIEMPO: " + tiempo.Elapsed.Milliseconds.ToString() + " ms");
                            Console.ReadKey(true);

                            break; 
                        case ConsoleKey.A: // CURSO: 86. Consumo del método GuardarJson
                            Console.Clear();

                            // Inicia el contador:
                            tiempo = Stopwatch.StartNew();

                            // Código del programa...                            
                            result = client.GuardarJson("{\"deporte\":\"Fútbol\"," +
                                        "\"equipos\":[" +
                                            "{\"nombre\":\"Ajax\",\"pais\":\"Paises Bajos\"}," +
                                            "{\"nombre\":\"Motril CF\",\"pais\":\"España\"}]}");
                            tiempo.Stop();

                            // Para el contador e imprime el resultado:
                            Console.WriteLine(result + "\n\n\tTIEMPO: " + tiempo.Elapsed.Milliseconds.ToString() + " ms");
                            Console.ReadKey(true);

                            break;
                        case ConsoleKey.B: // CURSO: 88. Consumo del método ObtenerProductos
                            Console.Clear();

                            // Inicia el contador:
                            tiempo = Stopwatch.StartNew();

                            // Código del programa...                            
                            result = client.ObtenerProductos();
                            tiempo.Stop();

                            dynamic productos = JsonConvert.DeserializeObject(result);

                            foreach (dynamic producto in productos)
                            {
                                Console.WriteLine(producto);
                            }

                            // Para el contador e imprime el resultado:
                            Console.WriteLine("\n\n\tTIEMPO: " + tiempo.Elapsed.Milliseconds.ToString() + " ms");
                            Console.ReadKey(true);

                            break;
                        case ConsoleKey.C: // CURSO: 89. Consumo del método ObtenerProducto
                            Console.Clear();

                            // Inicia el contador:
                            tiempo = Stopwatch.StartNew();

                            // Código del programa...                            
                            ServiceReferencePHP.Producto resultado = client.ObtenerProducto(2);
                            tiempo.Stop();

                            Console.WriteLine(resultado.idproducto);
                            Console.WriteLine(resultado.nombre);
                            Console.WriteLine(resultado.precio);
                            Console.WriteLine(resultado.stock);

                            // Para el contador e imprime el resultado:
                            Console.WriteLine("\n\n\tTIEMPO: " + tiempo.Elapsed.Milliseconds.ToString() + " ms");
                            Console.ReadKey(true);

                            break;
                        case ConsoleKey.D: // CURSO: 90. Consumo del método ActualizarProducto
                            Console.Clear();

                            ServiceReferencePHP.Producto p = new ServiceReferencePHP.Producto()
                            {
                                idproducto = 2,
                                nombre = "PS4 PRO",
                                precio = 720,
                                stock = 15
                            };

                            // Inicia el contador:
                            tiempo = Stopwatch.StartNew();

                            // Código del programa...                                                                                        
                            result = client.ActualizarProducto(p);
                            tiempo.Stop();

                            // Para el contador e imprime el resultado:
                            Console.WriteLine(result + "\n\n\tTIEMPO: " + tiempo.Elapsed.Milliseconds.ToString() + " ms");
                            Console.ReadKey(true);
                            break;
                        case ConsoleKey.E: // CURSO: 91. Consumo del método GuardarProducto
                            Console.Clear();

                            ServiceReferencePHP.Producto product = new ServiceReferencePHP.Producto()
                            {                                
                                nombre = "Monitor Benq",
                                precio = 340,
                                stock = 7
                            };

                            // Inicia el contador:
                            tiempo = Stopwatch.StartNew();

                            // Código del programa...                            
                            idp = client.GuardarProducto(product);
                            tiempo.Stop();

                            // Para el contador e imprime el resultado:
                            Console.WriteLine(idp + "\n\n\tTIEMPO: " + tiempo.Elapsed.Milliseconds.ToString() + " ms");
                            Console.ReadKey(true);

                            break;
                        case ConsoleKey.F: // CURSO: 92. Consumo del método EliminarProducto
                            Console.Clear();
                            // Inicia el contador:
                            tiempo = Stopwatch.StartNew();

                            // Código del programa...                            
                            result = client.EliminarProducto(4);
                            tiempo.Stop();

                            // Para el contador e imprime el resultado:
                            Console.WriteLine(result + "\n\n\tTIEMPO: " + tiempo.Elapsed.Milliseconds.ToString() + " ms");
                            Console.ReadKey(true);
                            break;
                        case ConsoleKey.G: // CURSO: 93. Clase AuthUser
                            Console.Clear();

                            //// Inicia el contador:
                            //tiempo = Stopwatch.StartNew();

                            //// Código del programa...                            
                            //result = client.ObtenerFecha();
                            //tiempo.Stop();

                            //// Para el contador e imprime el resultado:
                            //Console.WriteLine(result + "\n\n\tTIEMPO: " + tiempo.Elapsed.Milliseconds.ToString() + " ms");

                            // CURSO: 94. Consumo del método con autenticación de cabecera - Header - P1
                            using (var scope = new OperationContextScope(client.InnerChannel))
                            {
                                AuthUser authUser = new AuthUser
                                {
                                    UserName = "admin",
                                    Password = "123"
                                };

                                MessageHeader messageHeader = MessageHeader.CreateHeader("AuthUser", "http://ejemplo.com/", authUser);
                                OperationContext.Current.OutgoingMessageHeaders.Add(messageHeader);

                                // Inicia el contador:
                                tiempo = Stopwatch.StartNew();
                                // Código del programa...                            
                                result = client.ObtenerFecha();
                                tiempo.Stop();
                                // Para el contador e imprime el resultado:
                                Console.WriteLine(result + "\n\n\tTIEMPO: " + tiempo.Elapsed.Milliseconds.ToString() + " ms");
                            }

                            Console.ReadKey(true);
                            break;
                        case ConsoleKey.H: // CURSO: 96. Consumo del método con autenticación básica - Basic
                            Console.Clear();

                            /* Descomentar si el ISS se ha cambiado de autenticación anónima a básica */
                            client.ClientCredentials.UserName.UserName = "admin"; // validate_user en servicios.php
                            client.ClientCredentials.UserName.Password = "321";

                            using (new OperationContextScope(client.InnerChannel))
                            {

                                // Descomentar si el ISS se ha cambiado de autenticación anónima a básica
                                SoapAuthHeader.Create(client.ClientCredentials.UserName.UserName, client.ClientCredentials.UserName.Password);

                                // Inicia el contador:
                                tiempo = Stopwatch.StartNew();
                                // Código del programa...                            
                                result = client.ObtenerHora();
                                tiempo.Stop();

                                // Para el contador e imprime el resultado:
                                Console.WriteLine(result + "\n\n\tTIEMPO: " + tiempo.Elapsed.Milliseconds.ToString() + " ms");
                                Console.ReadKey(true);
                            }                                                                                                                                         
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
            Console.WriteLine("7.- GuardarEquipos(*)".PadRight(30, ' ') + "*");
            Console.SetCursorPosition(5, Console.CursorTop);
            Console.WriteLine("8.- GuardarXML(*)");
            Console.SetCursorPosition(5, Console.CursorTop);
            Console.WriteLine("9.- RetornarJSON()");
            Console.SetCursorPosition(5, Console.CursorTop);
            Console.WriteLine("A.- GuardarJSON(*)");
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
