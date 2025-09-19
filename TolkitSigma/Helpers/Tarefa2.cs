using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TolkitSigma.Helpers
{
    class Items
    {
        public string Identificador { get; set; } = "";
        public string Enunciado { get; set; } = "";
        public string CategoriaCorreta { get; set; } = "";
    }
    internal class Tarefa2
    {
        int pontos = 0;
        /// <summary>
        /// Executa o quiz de classificação de problemas computacionais (Tratável/Intratável/Não-computável)
        /// </summary>
        public void Exec()
        {
            List<Items> itens = JsonSerializer.Deserialize<List<Items>>(obterJson());

            for (int i = 0; i < itens.Count; i++)
            {
                Console.WriteLine("____________________");
                Console.WriteLine("Problema: " + itens[i].Enunciado);
                Console.WriteLine("--------------------");
                Console.Write("Sua resposta (T/I/N): ");
                string? respostaUsuario = Console.ReadLine();
                if (respostaUsuario != null) ConverterRespostaTIN(respostaUsuario, itens[i]);
            }


            Console.WriteLine("Você acertou: " + pontos);

        }

        /// <summary>
        /// Converte e valida a resposta do usuário (T/I/N) comparando com a categoria correta
        /// </summary>
        /// <param name="resposta">Resposta do usuário (T=Tratável, I=Intratável, N=Não-computável)</param>
        /// <param name="item">Item contendo o problema e sua categoria correta</param>
        public void ConverterRespostaTIN(string resposta, Items item)
        {
            switch (resposta)
            {
                case "T":
                    if (item.CategoriaCorreta == "tratavel")
                    {
                        pontos++;
                        Console.WriteLine("Acertou!");
                    }
                    else
                    {
                        Console.WriteLine("Errou");
                    }
                    break;
                case "N":
                    if (item.CategoriaCorreta == "nao_computavel")
                    {
                        pontos++;
                        Console.WriteLine("Acertou!");
                    }
                    else
                    {
                        Console.WriteLine("Errou");
                    }
                    break;
                case "I":
                    if (item.CategoriaCorreta == "intratavel")
                    {
                        pontos++;
                        Console.WriteLine("Acertou!");
                    }
                    else
                    {
                        Console.WriteLine("Errou");
                    }
                    break;

            }
        }

        /// <summary>
        /// Retorna os dados em formato JSON com os problemas computacionais e suas categorias
        /// </summary>
        /// <returns>String JSON contendo os problemas para o quiz</returns>
        private static string obterJson()
        {
            string json = @"
            [
                {""Identificador"": ""P1"", ""Enunciado"": ""Ordenar n numeros"", ""CategoriaCorreta"": ""tratavel""},
                {""Identificador"": ""P2"",""Enunciado"": ""Verificar se cadeia contem 'a'"",""CategoriaCorreta"": ""tratavel""},
                {""Identificador"": ""P3"",""Enunciado"": ""Satisfatibilidade booleana (SAT)"", ""CategoriaCorreta"": ""intratavel""},
                {""Identificador"": ""P4"",""Enunciado"": ""Caixeiro viajante exato"", ""CategoriaCorreta"": ""intratavel""},
                {""Identificador"": ""P5"",""Enunciado"": ""Problema da parada"",""CategoriaCorreta"": ""nao_computavel""},
                {""Identificador"": ""P6"",""Enunciado"": ""Testar se numero eh primo"",""CategoriaCorreta"": ""tratavel""},
                {""Identificador"": ""P7"",""Enunciado"": ""Cobertura por vertices minima"",""CategoriaCorreta"": ""intratavel""},
                {""Identificador"": ""P8"",""Enunciado"": ""Decidir se dois programas sempreproduzem a mesma saida"",""CategoriaCorreta"": ""nao_computavel""}
            ]
            ";
            return json;
        }
    }
}
