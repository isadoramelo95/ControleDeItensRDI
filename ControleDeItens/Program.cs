using GeladeiraCodeRDIVersity;
using System;

Geladeira objGeladeira = new Geladeira();

// andar 0 - Hortifruti
var objItemMorango = new Item() { Alimento = "Morango", Quantidade = 1, Unidade = "Unidade", ClassificacaoDoAndar = "Hortifruti", Id = 1 };
var objItemUva = new Item() { Alimento = "Uva", Quantidade = 1, Unidade = "Cacho", ClassificacaoDoAndar = "Hortifruti", Id = 2 };
var objItemTomate = new Item() { Alimento = "Tomate", Quantidade = 1, Unidade = "", ClassificacaoDoAndar = "Hortifruti", Id = 3 };
var objItemBanana = new Item() { Alimento = "Banana", Quantidade = 1, Unidade = "Penca", ClassificacaoDoAndar = "Hortifruti", Id = 4 };

// andar 1 - Laticínios e Enlatados
var objItemTomatePelado = new Item() { Alimento = "Tomate Pelado", Quantidade = 1, Unidade = "Lata", ClassificacaoDoAndar = "Laticínios e Enlatados", Id = 5 };
var objItemCremeLeite = new Item() { Alimento = "Creme de Leite", Quantidade = 1, Unidade = "Caixa", ClassificacaoDoAndar = "Laticínios e Enlatados", Id = 6 };
var objItemLeite = new Item() { Alimento = "Leite", Quantidade = 1, Unidade = "Litro", ClassificacaoDoAndar = "Laticínios e Enlatados", Id = 7 };

// andar 2 - Charcutaria, Carnes e Ovos
var objItemBacon = new Item() { Alimento = "Bacon", Quantidade = 1, Unidade = "Kilos", ClassificacaoDoAndar = "Charcutaria, Carnes e Ovos", Id = 8 };
var objItemCarne = new Item() { Alimento = "Carne", Quantidade = 1, Unidade = "kilos", ClassificacaoDoAndar = "Charcutaria, Carnes e Ovos", Id = 9 };
var objItemOvos = new Item() { Alimento = "Ovos", Quantidade = 1, Unidade = "duzia", ClassificacaoDoAndar = "Charcutaria, Carnes e Ovos", Id = 10 };

//Adicionar os itens na geladeira
//Hortifruti
objGeladeira.AdicionarItemNaGeladeira(0, 0, 0, objItemMorango);
objGeladeira.AdicionarItemNaGeladeira(0, 0, 1, objItemUva);
objGeladeira.AdicionarItemNaGeladeira(0, 1, 2, objItemTomate);

Console.WriteLine();
// Laticínios e Enlatados
objGeladeira.AdicionarItemNaGeladeira(1, 0, 0, objItemTomatePelado);
objGeladeira.AdicionarItemNaGeladeira(1, 1, 1, objItemCremeLeite);
objGeladeira.AdicionarItemNaGeladeira(1, 1, 2, objItemLeite);

Console.WriteLine();
// Charcutaria, Carnes e Ovos
objGeladeira.AdicionarItemNaGeladeira(2, 0, 0, objItemBacon);
objGeladeira.AdicionarItemNaGeladeira(2, 0, 1, objItemCarne);
objGeladeira.AdicionarItemNaGeladeira(2, 1, 3, objItemOvos);

Console.WriteLine();

Console.WriteLine("Alimentos na geladeira:");
objGeladeira.ExibirItensNaGeladeira();

objGeladeira.RemoverItem(1, 0, 0);

var objItemIogurte = new Item() { Alimento = "Iogurte", Quantidade = 50, Unidade = "ml", ClassificacaoDoAndar = "Laticínios e Enlatados", Id = 11 };
objGeladeira.AdicionarItemNaGeladeira(1, 0, 0, objItemIogurte);

Console.WriteLine();

Console.WriteLine("Atualização da geladeira:");
objGeladeira.ExibirItensNaGeladeira();



// Aluna: Isadora Melo
