using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeItens.Geladeira
{
    internal class ControleDeGeladeira
    {
        private string[] categorias = new string[]
        {
            "hortifruti",
            "laticínios e enlatados",
            "charcutaria, carnes e ovos"
        };

        private List<string>[][] geladeira;

        internal ControleDeGeladeira()
        {
            geladeira = new List<string>[3][];

            for (int i = 0; i < geladeira.Length; i++)
            {
                geladeira[i] = new List<string>[2];
                for (int j = 0; j < geladeira[i].Length; j++)
                {
                    geladeira[i][j] = new List<string>();
                }
            }

            //hortifruti
            geladeira[0][0].AddRange(new List<string> { "Morango", "Banana" });
            geladeira[0][1].AddRange(new List<string> { "Alface", "Tomate" });

            //laticínios e enlatados
            geladeira[1][0].AddRange(new List<string> { "Creme de leite", "Leite" });
            geladeira[1][1].AddRange(new List<string> { "Requeijão", "Queijo" });

            // charcutaria, carnes e ovos
            geladeira[2][0].AddRange(new List<string> { "Carne Bovina", "Bacon" });
            geladeira[2][1].AddRange(new List<string> { "Frango", "Ovos" });
        }

        internal void ExibirItens()
        {
            for (int andar = 0; andar < geladeira.Length; andar++)
            {
                Console.WriteLine($"Andar {andar + 1} ({categorias[andar]}):");

                for (int container = 0; container < geladeira[andar].Length; container++)
                {
                    Console.Write($"  Container {container + 1}: ");

                    for (int i = 0; i < geladeira[andar][container].Count; i++)
                    {
                        Console.Write(geladeira[andar][container][i]);

                        if (i < geladeira[andar][container].Count - 1)
                        {
                            Console.Write(", ");
                        }
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
