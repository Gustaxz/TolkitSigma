using System;

namespace TolkitSigma.Helpers
{
    public delegate bool FuncaoDecisor(string cadeia);

    public static class LinguagensDecidiveis
    {
        public static void Executar()
        {
            Console.WriteLine("Decisores sobre Sigma = {a,b}");
            string cadeia = LerCadeia();

            if (!PertenceAoAlfabeto(cadeia))
            {
                Console.WriteLine("Entrada inválida: use apenas 'a' ou 'b'.");
                return;
            }

            Console.WriteLine("Escolha a linguagem base:");
            Console.WriteLine("1) L_fim_b");
            Console.WriteLine("2) L_mult3_b");

            int opcaoBase = LerOpcao(1, 2);
            FuncaoDecisor decisorBase = ObterDecisor(opcaoBase);

            bool respostaBase = decisorBase(cadeia);
            Console.WriteLine(respostaBase ? "SIM" : "NAO");
            Console.WriteLine();
        }

        private static string LerCadeia()
        {
            Console.WriteLine("Digite a cadeia (Enter = vazia):");
            string? lida = Console.ReadLine();
            return lida ?? string.Empty;
        }

        private static bool PertenceAoAlfabeto(string cadeia)
        {
            foreach (char simbolo in cadeia)
            {
                if (simbolo != 'a' && simbolo != 'b')
                {
                    return false;
                }
            }
            return true;
        }

        private static int LerOpcao(int minimo, int maximo)
        {
            while (true)
            {
                string? texto = Console.ReadLine();
                if (int.TryParse(texto, out int valor) && valor >= minimo && valor <= maximo)
                {
                    return valor;
                }
                Console.WriteLine("Opção inválida. Tente novamente:");
            }
        }

        private static bool LerSimNao()
        {
            while (true)
            {
                string? texto = Console.ReadLine();
                if (texto is null) continue;

                texto = texto.Trim().ToLowerInvariant();
                if (texto == "s") return true;
                if (texto == "n") return false;

                Console.WriteLine("Digite s ou n:");
            }
        }

        private static FuncaoDecisor ObterDecisor(int opcao)
        {
            return opcao switch
            {
                1 => PertenceLFimB,
                _ => PertenceLMult3B
            };
        }

        private static bool PertenceLFimB(string cadeia)
        {
            if (cadeia.Length == 0) return false;
            char ultimo = cadeia[cadeia.Length - 1];
            return ultimo == 'b';
        }

        private static bool PertenceLMult3B(string cadeia)
        {
            int contadorB = 0;
            foreach (char c in cadeia)
            {
                if (c == 'b') contadorB++;
            }
            return (contadorB % 3) == 0;
        }
    }
}
