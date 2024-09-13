using Domain.Models;

Geladeira objGeladeira = new Geladeira();

Console.WriteLine("Iniciando aplicação...");

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

var objItemIogurte = new Item() { Alimento = "Iogurte", Quantidade = 50, Unidade = "ml", Classificacao = "Laticínios e Enlatados", Id = 11 };
objGeladeira.AdicionarItemNaGeladeira(1, 0, 0, objItemIogurte);

Console.WriteLine();

Console.WriteLine("Atualização da geladeira:");
objGeladeira.ExibirItensNaGeladeira();


//var item1 = new Item
//{
//    Id = 1,
//    Alimento = "Maçã",
//    Quantidade = 6,
//    Unidade = "unidade",
//    Classificacao = "Hortifruti"
//};

//var item2 = new Item
//{
//    Id = 2,
//    Alimento = "Leite",
//    Quantidade = 2,
//    Unidade = "litro",
//    Classificacao = "Laticínios"
//};

//// Criando a geladeira
//var geladeira = new Geladeira();

//// Adicionando o primeiro item no primeiro andar (andar 0), no primeiro container (container 0) e na posição 0
//string resultadoAdicionarItem1 = geladeira.AdicionarItemNaGeladeira(0, 0, 0, item1);
//Console.WriteLine(resultadoAdicionarItem1); // Output: "Item adicionado com sucesso!"

//// Adicionando o segundo item no segundo andar (andar 1), no segundo container (container 1), sem posição especificada
//string resultadoAdicionarItem2 = geladeira.AdicionarItemNaGeladeira(1, 1, 1, item2);
//Console.WriteLine(resultadoAdicionarItem2);

//// Exibir os itens na geladeira
//geladeira.ExibirItensNaGeladeira();


//// Removendo o item da posição 0 do container 0 no andar 0
////geladeira.RemoverItem(0, 0, 0);
////Console.WriteLine("Item removido da geladeira!");

//// Exibir os itens na geladeira após remoção
//geladeira.ExibirItensNaGeladeira();

//// Limpando todos os itens do container 1 no andar 0
//geladeira.LimparGeladeira(0, 1);
//Console.WriteLine("Container limpo!");

//// Exibir os itens na geladeira após limpar o container
//geladeira.ExibirItensNaGeladeira();

//geladeira.ExibirItensNaGeladeira();



