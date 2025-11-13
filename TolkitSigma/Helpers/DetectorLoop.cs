using System;
using System.Collections.Generic;

namespace TolkitSigma.Helpers
{
    public static class Tarefa9
    {
        public static void Executar()
        {
            Console.WriteLine("=== Tarefa 9 — Detector Ingênuo de Loop + Reflexão ===");
            Console.WriteLine("Executando processo padrão: contagem até N");

            Console.Write("Limite máximo de passos: ");
            int limitePassos = LerInteiroPositivo(10, 100000, 1000);

            EstadoSimulado simulador = ObterSimuladorPadrao();
            string estadoInicial = "0";

            var resultado = DetectarLoop(simulador, estadoInicial, limitePassos);

            Console.WriteLine($"\nResultado final: {resultado}");
            Console.WriteLine("\n--- Reflexão ---");
            Console.WriteLine("Falsos positivos: podem ocorrer se o programa repete estados mas ainda terminaria mais adiante.");
            Console.WriteLine("Falsos negativos: ocorrem se o loop é longo demais e não repete dentro do limite de passos.");
            Console.WriteLine("Este detector é heurístico — não garante precisão total.");
            Console.WriteLine("----------------");
        }

        private delegate string EstadoSimulado(string estadoAtual);

        private static string DetectarLoop(EstadoSimulado simulador, string estadoInicial, int limite)
        {
            var vistos = new Dictionary<string, int>();
            string estado = estadoInicial;

            for (int passo = 1; passo <= limite; passo++)
            {
                if (estado == "fim")
                {
                    Console.WriteLine($"[Passo {passo}] Processo terminou naturalmente (estado = fim).");
                    return "Finalizado";
                }

                if (vistos.ContainsKey(estado))
                {
                    Console.WriteLine($"[Passo {passo}] Estado repetido: {estado} (já visto no passo {vistos[estado]})");
                    return "LoopDetectado";
                }

                vistos[estado] = passo; 
                Console.WriteLine($"[Passo {passo}] Estado atual = {estado}");
                estado = simulador(estado);
            }

            Console.WriteLine($"Nenhuma repetição detectada após {limite} passos.");
            return "Indeterminado";
        }

        private static EstadoSimulado ObterSimuladorPadrao()
        {
            int limite = 20;

            return estado =>
            {
                int i = int.Parse(estado);
                return i >= limite ? "fim" : (i + 1).ToString();
            };
        }

        private static int LerInteiroPositivo(int min, int max, int def)
        {
            while (true)
            {
                string? texto = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(texto))
                    return def;
                if (int.TryParse(texto, out int valor) && valor >= min && valor <= max)
                    return valor;
                Console.WriteLine($"Digite um valor entre {min} e {max}.");
            }
        }
    }
}
