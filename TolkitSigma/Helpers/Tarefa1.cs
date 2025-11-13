using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TolkitSigma.Helpers
{
    internal class Tarefa1
    {
        /// <summary>
        /// Permite ao usuário criar um alfabeto personalizado
        /// </summary>
        /// <returns>String contendo as letras do alfabeto definido pelo usuário</returns>
        public static string CriarAlfabeto()
        {
            Console.WriteLine("Digite as letras do alfabeto personalizado (ex: abcdef): ");

            return Console.ReadLine();

        }

        /// <summary>
        /// Verifica se uma letra específica pertence ao alfabeto definido
        /// </summary>
        /// <param name="alpha">String contendo o alfabeto para verificação</param>
        public static void VerificarAlfabeto(string alpha)
        {
            Console.Write("Digite uma letra para verificar: ");
            string entrada = Console.ReadLine();

            if (entrada.Length != 1)
            {
                Console.WriteLine("Por favor, digite apenas uma única letra.");
                return;
            }

            char letra = entrada[0];

            if (alpha.Contains(letra))
            {
                Console.WriteLine($"A letra '{letra}' FAZ parte do alfabeto definido.");
            }
            else
            {
                Console.WriteLine($"A letra '{letra}' NÃO faz parte do alfabeto definido.");
            }
        }
    }
}
