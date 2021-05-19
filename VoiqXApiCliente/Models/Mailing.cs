using System;
using System.Collections.Generic;
using System.Text;

namespace VoiqXApiCliente.Models {
    public class Mailing {
        public string name { get; set; }
        public List<MailingCustomer> customers { get; set; }
    }
}
