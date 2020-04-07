using System;
using System.Collections.Generic;

namespace Admin.Data.Models
{
    public partial class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid Id { get; set; }
        public Guid GroupId { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual Group Group { get; set; }
    }
}
