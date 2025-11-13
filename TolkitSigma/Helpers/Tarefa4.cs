using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TolkitSigma.Helpers
{
    internal class Tarefa4
    {
        /// <summary>
        /// Avaliador proposicional para fórmulas lógicas com variáveis P, Q e R
        /// </summary>
        static public void Executar()
        {
            bool P, Q, R;
            int opcao = 0;
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("Escolha a fórmula para avaliar:");
                Console.WriteLine("1 - P ^ Q (Conjunção)");
                Console.WriteLine("2 - P -> R (Implicação)");
                Console.WriteLine("3 - Mostrar tabela-verdade da fórmula escolhida");
                Console.WriteLine("4 - Sair");
                Console.Write("Digite a opção: ");
                int.TryParse(Console.ReadLine(), out opcao);

                if (opcao == 4)
                {
                    continuar = false;
                    continue;
                }

                P = LerValorBooleano("P");
                Q = LerValorBooleano("Q");
                R = LerValorBooleano("R");

                switch (opcao)
                {
                    case 1:
                        bool resultado1 = Conjuncao(P, Q);
                        Console.WriteLine($"Resultado da fórmula P -> Q: {resultado1}");
                        break;
                    case 2:
                        bool resultado2 = Implicacao(P, R);
                        Console.WriteLine($"Resultado da fórmula P -> R: {resultado2}");
                        break;
                    case 3:
                        Console.WriteLine("Digite 1 para tabela da fórmula P ^ Q");
                        Console.WriteLine("Digite 2 para tabela da fórmula P → R");
                        Console.Write("Opção: ");
                        int escolhaTabela;
                        int.TryParse(Console.ReadLine(), out escolhaTabela);
                        if (escolhaTabela == 1)
                            TabelaVerdadeConjuncao();
                        else if (escolhaTabela == 2)
                            TabelaVerdadeImplicacao();
                        else
                            Console.WriteLine("Opção inválida.");
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                Console.WriteLine();
            }
        }
        /// <summary>
        /// Lê um valor booleano do usuário para uma variável específica
        /// </summary>
        /// <param name="variavel">Nome da variável (P, Q ou R)</param>
        /// <returns>Valor booleano informado pelo usuário</returns>
        static bool LerValorBooleano(string variavel)
        {
            while (true)
            {
                Console.Write($"Informe o valor de {variavel} (true/false): ");
                string entrada = Console.ReadLine().ToLower();

                if (entrada == "true")
                    return true;
                else if (entrada == "false")
                    return false;
                else
                    Console.WriteLine("Valor inválido, digite 'true' ou 'false'.");
            }
        }

        /// <summary>
        /// Realiza a operação lógica de conjunção (AND) entre duas proposições
        /// </summary>
        /// <param name="p">Primeira proposição</param>
        /// <param name="q">Segunda proposição</param>
        /// <returns>Resultado da conjunção P ∧ Q</returns>
        static bool Conjuncao(bool p, bool q)
        {
            return p && q;
        }

        /// <summary>
        /// Realiza a operação lógica de implicação entre duas proposições
        /// </summary>
        /// <param name="p">Proposição antecedente</param>
        /// <param name="r">Proposição consequente</param>
        /// <returns>Resultado da implicação P → R</returns>
        static bool Implicacao(bool p, bool r)
        {
            return !p || r;
        }

        /// <summary>
        /// Exibe a tabela-verdade completa para a fórmula de conjunção P ∧ Q
        /// </summary>
        static void TabelaVerdadeConjuncao()
        {
            Console.WriteLine("Tabela-Verdade para P ∧ Q");
            Console.WriteLine("P\tQ\tR\tP ∧ Q");
            for (int i = 0; i < 8; i++)
            {
                bool P = (i & 4) != 0;
                bool Q = (i & 2) != 0;
                bool R = (i & 1) != 0;
                bool resultado = Conjuncao(P, Q);
                Console.WriteLine($"{P}\t{Q}\t{R}\t{resultado}");
            }
        }

        /// <summary>
        /// Exibe a tabela-verdade completa para a fórmula de implicação P → R
        /// </summary>
        static void TabelaVerdadeImplicacao()
        {
            Console.WriteLine("Tabela-Verdade para P → R");
            Console.WriteLine("P\tQ\tR\tP → R");
            for (int i = 0; i < 8; i++)
            {
                bool P = (i & 4) != 0;
                bool Q = (i & 2) != 0;
                bool R = (i & 1) != 0;
                bool resultado = Implicacao(P, R);
                Console.WriteLine($"{P}\t{Q}\t{R}\t{resultado}");
            }
        }
    }
}
