using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TolkitSigma.Helpers
{
    internal class Tarefa5
    {
        /// <summary>
        /// Reconhecedor de linguagens formais que verifica se palavras pertencem a:
        /// 1) L_par_a: linguagem com número par de 'a's
        /// 2) L = {w | w = a b*}: linguagem que começa com 'a' seguido de zero ou mais 'b's
        /// </summary>
        public static void Executar()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== VERIFICADOR DE LINGUAGENS ===");
                Console.WriteLine("1 - Linguagem L_par_a");
                Console.WriteLine("2 - Linguagem L = { w | w = a b* }");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                if (opcao == "0")
                    break;

                Console.Write("Digite a palavra: ");
                string palavra = Console.ReadLine();

                if (!Regex.IsMatch(palavra, "^[ab]*$"))
                {
                    Console.WriteLine("REJEITA (Símbolos fora do alfabeto {a, b})");
                }
                else
                {
                    bool aceita = false;

                    switch (opcao)
                    {
                        case "1":
                            // Conta quantidade de 'a's na palavra
                            int qtdA = 0;
                            foreach (char c in palavra)
                                if (c == 'a') qtdA++;

                            aceita = (qtdA % 2 == 0);
                            break;

                        case "2":
                            // Verifica se a palavra segue o padrão: a seguido de zero ou mais b's
                            aceita = Regex.IsMatch(palavra, @"^ab*$");
                            break;

                        default:
                            Console.WriteLine("Opção inválida.");
                            continue;
                    }

                    Console.WriteLine(aceita ? "ACEITA" : "REJEITA");
                }

                Console.WriteLine("\nPressione ENTER para continuar...");
                Console.ReadLine();
            }
        }
    }
}
