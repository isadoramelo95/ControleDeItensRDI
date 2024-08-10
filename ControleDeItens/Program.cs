using System;
using System.Collections.Generic;

namespace ControleDeItens.Geladeira
{
    internal class Geladeira
    {
        class Program
        {
            static void Main(string[] args)
            {
                ControleDeGeladeira geladeira = new ControleDeGeladeira();
                geladeira.ExibirItens();
            }
        }
    }
}