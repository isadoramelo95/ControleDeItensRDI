using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Andar
    {
        public Andar()
        {
            Containers = new HashSet<Container>();
            Items = new HashSet<Item>();
        }

        public int NumeroAndar { get; set; }

        public virtual ICollection<Container> Containers { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
