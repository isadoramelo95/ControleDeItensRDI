﻿using System.ComponentModel.DataAnnotations;

namespace GeladeiraCodeRDIVersity
{
    public class Item
    {
        [Required]
        public int? Id { get; set; }
        [Required]
        public string Alimento { get; set; }
        public string Unidade { get; set; } = string.Empty;
        public int Quantidade { get; set; } 
        [Required]
        public string Classificacao { get; set; }
        [Required]
        public int Posicao { get; set; }

        [Required]
        public int NumeroAndar { get; set; }
        [Required]
        public int NumeroContainer { get; set; }
    }
}
