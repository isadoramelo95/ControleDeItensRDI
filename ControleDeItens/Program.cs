using GeladeiraCodeRDIVersity;
using System;

Geladeira objGeladeira = new Geladeira();

// andar 0 - Hortifruti
var objItemMorango = new Item() { Alimento = "Morango", Quantidade = 1, Unidade = "Unidade", Classificacao = "Hortifruti", Id = 1 };
var objItemUva = new Item() { Alimento = "Uva", Quantidade = 1, Unidade = "Cacho", Classificacao = "Hortifruti", Id = 2 };
var objItemTomate = new Item() { Alimento = "Tomate", Quantidade = 1, Unidade = "", Classificacao = "Hortifruti", Id = 3 };
var objItemBanana = new Item() { Alimento = "Banana", Quantidade = 1, Unidade = "Penca", Classificacao = "Hortifruti", Id = 4 };

// andar 1 - Laticínios e Enlatados
var objItemTomatePelado = new Item() { Alimento = "Tomate Pelado", Quantidade = 1, Unidade = "Lata", Classificacao = "Laticínios e Enlatados", Id = 5 };
var objItemCremeLeite = new Item() { Alimento = "Creme de Leite", Quantidade = 1, Unidade = "Caixa", Classificacao = "Laticínios e Enlatados", Id = 6 };
var objItemLeite = new Item() { Alimento = "Leite", Quantidade = 1, Unidade = "Litro", Classificacao = "Laticínios e Enlatados", Id = 7 };

// andar 2 - Charcutaria, Carnes e Ovos
var objItemBacon = new Item() { Alimento = "Bacon", Quantidade = 1, Unidade = "Kilos", Classificacao = "Charcutaria, Carnes e Ovos", Id = 8 };
var objItemCarne = new Item() { Alimento = "Carne", Quantidade = 1, Unidade = "kilos", Classificacao = "Charcutaria, Carnes e Ovos", Id = 9 };
var objItemOvos = new Item() { Alimento = "Ovos", Quantidade = 1, Unidade = "duzia", Classificacao = "Charcutaria, Carnes e Ovos", Id = 10 };

//Adicionar os itens na geladeira
//Hortifruti
objGeladeira.AdicionarItemNaGeladeira(0, 0, 0, objItemMorango);
objGeladeira.AdicionarItemNaGeladeira(0, 0, 1, objItemUva);
objGeladeira.AdicionarItemNaGeladeira(0, 1, 2, objItemTomate);

// Laticínios e Enlatados
objGeladeira.AdicionarItemNaGeladeira(1, 0, 0, objItemTomatePelado);
objGeladeira.AdicionarItemNaGeladeira(1, 1, 1, objItemCremeLeite);
objGeladeira.AdicionarItemNaGeladeira(1, 1, 2, objItemLeite);

// Charcutaria, Carnes e Ovos
objGeladeira.AdicionarItemNaGeladeira(2, 0, 0, objItemBacon);
objGeladeira.AdicionarItemNaGeladeira(2, 0, 1, objItemCarne);
objGeladeira.AdicionarItemNaGeladeira(2, 1, 3, objItemOvos);

Console.WriteLine("Alimentos na geladeira:");

objGeladeira.AdicionarItemGeladeira(0, 0, 0, objItemMorango);
objGeladeira.AdicionarItemGeladeira(0, 0, 1, objItemUva);
objGeladeira.AdicionarItemGeladeira(0, 1, 2, objItemTomate);

// Laticínios e Enlatados
objGeladeira.AdicionarItemGeladeira(1, 0, 0, objItemTomatePelado);
objGeladeira.AdicionarItemGeladeira(1, 1, 1, objItemCremeLeite);
objGeladeira.AdicionarItemGeladeira(1, 1, 2, objItemLeite);

// Charcutaria, Carnes e Ovos
objGeladeira.AdicionarItemGeladeira(2, 0, 0, objItemBacon);
objGeladeira.AdicionarItemGeladeira(2, 0, 1, objItemCarne);
objGeladeira.AdicionarItemGeladeira(2, 1, 3, objItemOvos);

Console.WriteLine("Alimentos na geladeira:");
objGeladeira.ExibirItens();

objGeladeira.RemoverItem(1, 0, 0);

var objItemIogurte = new Item() { Alimento = "Iogurte", Quantidade = 50, Unidade = "ml", Classificacao = "Laticínios e Enlatados", Id = 11 };
objGeladeira.AdicionarItemGeladeira(1, 0, 0, objItemIogurte);

Console.WriteLine();

Console.WriteLine("Atualização da geladeira:");

// Aluna: Isadora Melo

