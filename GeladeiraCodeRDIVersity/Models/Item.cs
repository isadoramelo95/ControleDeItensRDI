using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Alimento é obrigatório")]
        public string? Alimento { get; set; }

        public string Unidade { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Quantidade deve ser maior que zero")]
        public int Quantidade { get; set; }

        public string? Classificacao { get; set; }

        [Required(ErrorMessage = "Posição dentro do container é obrigatória")]
        public int? Posicao { get; set; }

        [Required(ErrorMessage = "Número do Andar é obrigatório")]
        public int? NumeroAndar { get; set; }

        [Required(ErrorMessage = "Número do Container é obrigatório")]
        public int? NumeroContainer { get; set; }
    }
}
