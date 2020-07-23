using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BilhavkWeb.Models
{
    public class Participant
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public int DayId { get; set; }

        public virtual User User { get; set; }
        public virtual Day Day { get; set; }
    }
}