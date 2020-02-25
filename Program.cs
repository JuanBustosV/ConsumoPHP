using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoPHP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "* Consumo de WS de PHP - http://serviciostests.000webhostapp.com/servicios.php?wsdl *";
            // CURSO: 76. Consumo del método HelloWorld
            ServiceReferencePHP.serviciosPortTypeClient client = new ServiceReferencePHP.serviciosPortTypeClient();

            string result = client.HelloWorld();

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
