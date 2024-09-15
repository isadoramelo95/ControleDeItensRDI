using System.ComponentModel.DataAnnotations;

namespace GeladeiraCodeRDIVersity
{
    public class Item
    {
        public int? Id { get; set; }
        [Required]
        public string Alimento { get; set; }
        public string Unidade { get; set; }
        public int Quantidade { get; set; }
        [Required]
        public string ClassificacaoDoAndar { get; set; }
        public int NumeroContainer { get; set; }
        public int NumeroAndar { get; set; }
        public int Posicao { get; set; }
    }
}
