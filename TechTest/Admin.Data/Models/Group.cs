using System;
using System.Collections.Generic;

namespace Admin.Data.Models
{
    public partial class Group
    {
        public Group()
        {
            Person = new HashSet<Person>();
        }

        public string Name { get; set; }
        public Guid Id { get; set; }

        public virtual ICollection<Person> Person { get; set; }
    }
}
