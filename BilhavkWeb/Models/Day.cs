using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilhavkWeb.Models
{
    public class Day
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<Participant> Participants { get; set; }
    }
}