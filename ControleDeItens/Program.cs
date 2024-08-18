
using Domain;

Geladeira objGeladeira = new Geladeira();

// andar 0 - Hortifruti
var objItemMorango = new Item() { Alimento = "Morango", Quantidade = 1, Unidade = "Unidade", Classificacao = "Hotfruti", Id = 1 };
var objItemUva = new Item() { Alimento = "Uva", Quantidade = 1, Unidade = "Cacho", Classificacao = "Hotfruti", Id = 2 };
var objItemTomate = new Item() { Alimento = "Tomate", Quantidade = 1, Unidade = "", Classificacao = "Hotfruti", Id = 3 };
var objItemBanana = new Item() { Alimento = "Banana", Quantidade = 1, Unidade = "Penca", Classificacao = "Hotfruti", Id = 4 };

// andar 1 - Laticínios e Enlatados
var objItemTomatePelado = new Item() { Alimento = "Tomate Pelado", Quantidade = 1, Unidade = "Lata", Classificacao = "Laticínios e Enlatados", Id = 5 };
var objItemCremeLeite = new Item() { Alimento = "Creme de Leite", Quantidade = 1, Unidade = "Caixa", Classificacao = "Laticínios e Enlatados", Id = 6 };
var objItemLeite = new Item() { Alimento = "Leite", Quantidade = 1, Unidade = "Litro", Classificacao = "Laticínios e Enlatados", Id = 7 };

// andar 2 - Charcutaria, Carnes e Ovos
var objItemBacon = new Item() { Alimento = "Bacon", Quantidade = 1, Unidade = "Kilos", Classificacao = "Charcutaria, Carnes e Ovos", Id = 8 };
var objItemCarne = new Item() { Alimento = "Carne", Quantidade = 1, Unidade = "kilos", Classificacao = "Charcutaria, Carnes e Ovos", Id = 9 };
var objItemOvos = new Item() { Alimento = "Ovos", Quantidade = 1, Unidade = "duzia", Classificacao = "Charcutaria, Carnes e Ovos", Id = 10 };

//
objGeladeira.AdicionarItensAoContainer(0, 0, objItemBanana);
objGeladeira.AdicionarItensAoContainer(1, 0, objItemCremeLeite);
objGeladeira.AdicionarItensAoContainer(0, 3, objItemCarne);

//
objGeladeira.ExibirItens();



// Aluna: Isadora Melo