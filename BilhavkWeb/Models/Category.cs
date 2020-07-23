using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilhavkWeb.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public string Pic { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}