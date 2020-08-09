using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace taxiModel
{
    public partial class Users
    {
        public Users()
        {
            OrdersIdclientNavigation = new HashSet<Orders>();
            OrdersIdoperatorNavigation = new HashSet<Orders>();
            Ur = new HashSet<Ur>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 
        public string Lastname { get; set; }
        public string Midname { get; set; }
        public char? Sex { get; set; }
        public string Email { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
        public string Firstname { get; set; }
        public DateTime? Datebirth { get; set; }
        public char? Photo { get; set; }

        public string Number { get; set; }
        public virtual ICollection<Orders> OrdersIdclientNavigation { get; set; }
        public virtual ICollection<Orders> OrdersIdoperatorNavigation { get; set; }
        public virtual ICollection<Ur> Ur { get; set; }
    }
}
