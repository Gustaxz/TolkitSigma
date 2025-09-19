using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TolkitSigma.Helpers
{
    internal class Tarefa3
    {
        /// <summary>
        /// Decisor que verifica se uma cadeia termina com o caractere 'b'
        /// </summary>
        static public void  Executar()
        {
            Console.WriteLine("Forneça uma cadeia:");

            string cadeia = Console.ReadLine();
            
            if (string.IsNullOrEmpty(cadeia))
            {
                Console.WriteLine("NÃO");

            }else if (cadeia.EndsWith("b")){

                Console.WriteLine("SIM");

            } else  {

                Console.WriteLine("NÃO");

            }

        }

    }
}
