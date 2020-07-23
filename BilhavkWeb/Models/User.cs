using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BilhavkWeb.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string NickName { get; set; }
        [Required]
        public string  Name{ get; set; }
        [Required]
        public string Surname { get; set; }
        public string Info { get; set; }
        [Required]
        public string Password { get; set; }
        public int Penalty { get; set; }
        public string Pic { get; set; }
        public bool Ge250 { get; set; }
        public string StudentID { get; set; }
        public string MailAdress { get; set; }
        public string PhoneNumber { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public DateTime BirthDate { get; set; }


        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}