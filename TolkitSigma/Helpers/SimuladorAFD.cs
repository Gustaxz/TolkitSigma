using System;
using System.Collections.Generic;

namespace TolkitSigma.Helpers
{
    public static class Tarefa10
    {
        public static void Executar()
        {
            Console.WriteLine("=== Tarefa 10 — Simulador de AFD ===");
            Console.WriteLine("Este AFD reconhece palavras sobre Σ = {a, b} que terminam em 'b'.");

            string estadoInicial = "q0";
            string[] estadosFinais = { "q1" };

            var transicoes = new Dictionary<(string, char), string>
            {
                { ("q0", 'a'), "q0" },
                { ("q0", 'b'), "q1" },
                { ("q1", 'a'), "q0" },
                { ("q1", 'b'), "q1" }
            };

            Console.Write("Digite a palavra (composta por 'a' e 'b'): ");
            string palavra = Console.ReadLine()?.Trim() ?? "";

            string estadoAtual = estadoInicial;

            foreach (char simbolo in palavra)
            {
                if (simbolo != 'a' && simbolo != 'b')
                {
                    Console.WriteLine($"Símbolo inválido: {simbolo}. Apenas 'a' e 'b' são permitidos.");
                    return;
                }

                Console.WriteLine($"Consumindo '{simbolo}' em {estadoAtual}...");
                estadoAtual = transicoes[(estadoAtual, simbolo)];
                Console.WriteLine($" -> Novo estado: {estadoAtual}");
            }

            bool aceita = Array.Exists(estadosFinais, s => s == estadoAtual);

            Console.WriteLine($"\nPalavra final: '{palavra}'");
            Console.WriteLine($"Estado final: {estadoAtual}");
            Console.WriteLine($"Resultado: {(aceita ? "ACEITA" : "REJEITADA")}");
        }
    }
}
