using System;
using System.Collections.Generic;

namespace taxiModel
{
    public partial class Orders
    {
        public int Idclient { get; set; }
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string State { get; set; }
        public string Startaddress { get; set; }
        public string Endaddress { get; set; }
        public int? Idtransport { get; set; }
        public int? Idoperator { get; set; }
        public int? Price { get; set; }

        public virtual Users IdclientNavigation { get; set; }
        public virtual Users IdoperatorNavigation { get; set; }
        public virtual Transport IdtransportNavigation { get; set; }
    }
}
