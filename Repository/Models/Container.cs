using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Container
    {
        public Container()
        {
            Items = new HashSet<Item>();
        }

        public int NumeroContainer { get; set; }
        public int? NumeroAndar { get; set; }

        public virtual Andar? NumeroAndarNavigation { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
