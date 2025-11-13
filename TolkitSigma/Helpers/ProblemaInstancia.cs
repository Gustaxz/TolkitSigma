using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TolkitSigma.Helpers
{ 
    public class Item
    {
        public string Texto { get; set; } = "";
        public string TipoCorreto { get; set; } = "";
    }

    public class Resultado
    {
        public Item Item { get; set; }
        public string RespostaUsuario { get; set; }
        public bool Correto { get; set; }

        public Resultado(Item item, string resposta, bool correto)
        {
            Item = item;
            RespostaUsuario = resposta;
            Correto = correto;
        }
    }

    public class ProblemaInstancia
    {
        public static void Executar()
        {
            Console.WriteLine("Problema ou Instância?");
            Console.WriteLine("Digite P para problema ou I para instância.");
            Console.WriteLine();

            List<Item>? itens = LerItens();
            if (itens is null)
            {
                Console.WriteLine("Falha ao carregar dados.");
                return;
            }

            int acertos = 0;
            int erros = 0;
            List<Resultado> resultados = new();

            foreach (Item item in itens)
            {
                Console.WriteLine(item.Texto);
                string resposta = LerPeI();
                bool correto = resposta.Equals(item.TipoCorreto, StringComparison.OrdinalIgnoreCase);

                resultados.Add(new Resultado(item, resposta, correto));

                if (correto)
                {
                    acertos++;
                    Console.WriteLine("Correto\n");
                }
                else
                {
                    erros++;
                    Console.WriteLine($"Incorreto. Gabarito: {item.TipoCorreto}\n");
                }
            }

            Console.WriteLine("\n===== RESULTADO FINAL =====");
            Console.WriteLine($"Acertos: {acertos}");
            Console.WriteLine($"Erros: {erros}");
            Console.WriteLine("============================\n");

            Console.WriteLine("ITENS ACERTADOS:");
            foreach (var r in resultados)
            {
                if (r.Correto)
                    Console.WriteLine($"-> {r.Item.Texto} (Resposta: {r.RespostaUsuario})");
            }

            Console.WriteLine("\nITENS ERRADOS:");
            foreach (var r in resultados)
            {
                if (!r.Correto)
                    Console.WriteLine($"X {r.Item.Texto} (Resposta: {r.RespostaUsuario}, Gabarito: {r.Item.TipoCorreto})");
            }

            Console.WriteLine("\nFim do programa.");
        }

        private static List<Item>? LerItens()
        {
            string json = @"
[
    { ""Texto"": ""Ordenar numeros"", ""TipoCorreto"": ""P"" },
    { ""Texto"": ""[3, 1, 4]"", ""TipoCorreto"": ""I"" },
    { ""Texto"": ""Verificar se um numero eh primo"", ""TipoCorreto"": ""P"" },
    { ""Texto"": ""29"", ""TipoCorreto"": ""I"" },
    { ""Texto"": ""Decidir se cadeia termina com 'b'"", ""TipoCorreto"": ""P"" },
    { ""Texto"": ""abb"", ""TipoCorreto"": ""I"" }
]";
            return JsonSerializer.Deserialize<List<Item>>(json);
        }

        private static string LerPeI()
        {
            while (true)
            {
                Console.Write("P/I: ");
                string? entrada = Console.ReadLine();

                if (entrada is null) continue;

                entrada = entrada.Trim().ToUpperInvariant();

                if (entrada == "P" || entrada == "I") return entrada;

                Console.WriteLine("Resposta inválida. Digite P ou I.");
            }
        }
    }
}

