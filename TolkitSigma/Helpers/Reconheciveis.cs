using System;

namespace TolkitSigma.Helpers
{
    public static class LinguagensReconheciveis
    {
        public static void Executar()
        {
            Console.WriteLine("L_ab: cadeias que contêm \"ab\"");
            Console.WriteLine("Alfabeto Sigma = {a, b}");
            Console.WriteLine("Digite a cadeia (Enter = vazia):");

            string? lida = Console.ReadLine();
            if (lida is null)
            {
                lida = string.Empty;
            }

            if (!PertenceAoAlfabeto(lida))
            {
                Console.WriteLine("Entrada inválida. Use apenas 'a' ou 'b'.");
                return;
            }

            Console.WriteLine("Escolha o modo:");
            Console.WriteLine("1) Decisor (sempre termina)");
            Console.WriteLine("2) Reconhecedor (pode não terminar)");

            int modo = LerOpcao(1, 2);

            if (modo == 1)
            {
                bool pertence = DecisorContemAB(lida);
                Console.WriteLine(pertence ? "SIM" : "NAO");
                return;
            }

            Console.WriteLine("Limite de passos para simular execução:");
            int limite = LerNumeroPositivo();

            string resultado = ReconhecedorContemABComLimite(lida, limite);
            Console.WriteLine(resultado);
        }


        private static bool PertenceAoAlfabeto(string cadeia)
        {
            foreach (char s in cadeia)
            {
                if (s != 'a' && s != 'b')
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

        private static int LerNumeroPositivo()
        {
            while (true)
            {
                string? texto = Console.ReadLine();
                if (int.TryParse(texto, out int valor) && valor > 0)
                {
                    return valor;
                }
                Console.WriteLine("Digite um inteiro positivo:");
            }
        }

        private static bool DecisorContemAB(string cadeia)
        {
            for (int i = 0; i < cadeia.Length - 1; i++)
            {
                char atual = cadeia[i];
                char proximo = cadeia[i + 1];

                if (atual == 'a' && proximo == 'b')
                {
                    return true;
                }
            }
            return false;
        }

        private static string ReconhecedorContemABComLimite(string cadeia, int limitePassos)
        {
            int i = 0;
            int passos = 0;

            while (true)
            {
                if (cadeia.Length >= 2)
                {
                    char atual = cadeia[i];
                    char proximo = cadeia[(i + 1) % cadeia.Length];

                    if (atual == 'a' && proximo == 'b')
                    {
                        return "ACEITA";
                    }

                    i = (i + 1) % cadeia.Length;
                }
                else
                {
                    i = 0;
                }

                passos++;

                if (passos >= limitePassos)
                {
                    return "INDETERMINADO (simulando não término)";
                }
            }
        }
    }
}
