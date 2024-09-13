namespace ControleDeItens
{
    public class GeladeiraRDI
    {
        public List<string> Geladeira()
        { 
            var lista = new List<string>();

            lista.Add("hortifruti");
            lista.Add("laticínios e enlatados");
            lista.Add("charcutaria, carnes e ovos");

            Console.WriteLine("Turma da galinha pintadinha: ");
            foreach (var item in lista)
                Console.WriteLine(item);

            return lista;

        }

        public List<string> AddLista(string item, List<string> lista)
        {
            lista.Add(item);

            return lista;
        }


    }
}
