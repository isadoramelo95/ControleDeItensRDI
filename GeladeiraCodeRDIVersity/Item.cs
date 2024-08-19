using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeladeiraCodeRDIVersity
{
    public class Item
    {
        public int? Id { get; set; }
        public string Alimento { get; set; } = string.Empty;
        public string Unidade { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public string Classificacao { get; set; } = string.Empty;
    }
}


//propriedades
//teste inserindo novamente no git