using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Item
    {
        public int Id { get; set; }
        public string? Alimento { get; set; }
        public string? Unidade { get; set; }
        public int? Quantidade { get; set; }
        public string? Classificacao { get; set; }
        public int? NumeroContainer { get; set; }
        public int? NumeroAndar { get; set; }

        public virtual Classificacao? ClassificacaoNavigation { get; set; }
        public virtual Andar? NumeroAndarNavigation { get; set; }
        public virtual Container? NumeroContainerNavigation { get; set; }
    }
}
