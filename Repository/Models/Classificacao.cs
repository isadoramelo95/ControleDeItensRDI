using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Classificacao
    {
        public Classificacao()
        {
            Items = new HashSet<Item>();
        }

        public string Classificacao1 { get; set; } = null!;

        public virtual ICollection<Item> Items { get; set; }
    }
}
