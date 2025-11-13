using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TolkitSigma;
using TolkitSigma.Helpers;

namespace TolkitSigma
{
    class Program
    {
        /// <summary>
        /// Lê e valida uma opção do menu dentro de um intervalo específico
        /// </summary>
        /// <param name="valorMinimo">Valor mínimo aceito</param>
        /// <param name="valorMaximo">Valor máximo aceito</param>
        /// <returns>Valor válido escolhido pelo usuário</returns>
        private static int LerOpcaoDoMenu(int valorMinimo, int valorMaximo)
        {
            while (true)
            {
                Console.Write("Opcao: ");
                string? textoDigitado = Console.ReadLine();
                if (int.TryParse(textoDigitado, out int valorLido))
                {
                    if (valorLido >= valorMinimo && valorLido <= valorMaximo)
                    {
                        return valorLido;
                    }
                }

                Console.WriteLine("Opção invalida. Tente novamente ");
            }
        }
                /// <summary>
                /// Função principal que exibe o menu e executa as tarefas selecionadas
                /// </summary>
                static void Main()
        {
            string alphabet = "";
            while (true)
            {
                Console.WriteLine("Projeto Toolkit (versao simples)");
                Console.WriteLine("---- AV1 ----");
                Console.WriteLine("1) Verificar alfabeto e cadeia (Sigma={ a,b})");
                Console.WriteLine("2) Classificador T/I/N por JSON");
                Console.WriteLine("3) Decisor: termina com 'b'?");
                Console.WriteLine("4) Avaliador proposicional (P,Q,R)");
                Console.WriteLine("5) Reconhecedor: L_par_a e a b*");
                Console.WriteLine("---- AV2 ----");
                Console.WriteLine("6) Problema x instancia por JSON");
                Console.WriteLine("7) Decisores: L_fim_b e L_mult3_b");
                Console.WriteLine("8) Reconhecedor que pode nao terminar (a^ib ^ i)");
                Console.WriteLine("9) Detector ingenuo de loop");
                Console.WriteLine("10) Simulador AFD simples (termina com 'b')");
                Console.WriteLine("0) Sair");
                int opcaoEscolhida = LerOpcaoDoMenu(0, 10);
                Console.WriteLine();
                if (opcaoEscolhida == 0) return;
                if (opcaoEscolhida == 1)
                {
                 alphabet = Tarefa1.CriarAlfabeto();
                 Tarefa1.VerificarAlfabeto(alphabet);
                }
                if (opcaoEscolhida == 2)
                {
                    Tarefa2 t = new Tarefa2();
                    t.Exec();
                };
               if (opcaoEscolhida == 3)
                {
                    Tarefa3.Executar();
                };
               if (opcaoEscolhida == 4)
                {
                    Tarefa4.Executar();
                }
               if (opcaoEscolhida == 5)
                {
                    Tarefa5.Executar();
                }
                if (opcaoEscolhida == 6)
                {
                    ProblemaInstancia.Executar();
                }
                if (opcaoEscolhida == 7)
                {
                    LinguagensDecidiveis.Executar();
                }
                if (opcaoEscolhida == 8)
                {
                    LinguagensReconheciveis.Executar();
                }
                Console.WriteLine();
                if (opcaoEscolhida == 9)
                {
                    Tarefa9.Executar();
                }
                if (opcaoEscolhida == 10)
                {
                    Tarefa10.Executar();
                }

            }

        }

    }
}


