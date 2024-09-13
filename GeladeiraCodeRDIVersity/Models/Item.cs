using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class Item
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        [Required]
        public string? Alimento { get; set; }
        public string Unidade { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        [Required]
        public string? Classificacao { get; set; }
        [Required]
        public int Posicao { get; set; }

        [Required]
        public int NumeroAndar { get; set; }
        [Required]
        public int NumeroContainer { get; set; }
    }
}
