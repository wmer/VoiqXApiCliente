using System;
using System.Collections.Generic;
using System.Text;

namespace VoiqXApiCliente.Models {
    public class MailingCostumerStatus {
        public string reference_code { get; set; }
        public string contact_name { get; set; }
        public string phone { get; set; }
        public int phone_status_code { get; set; }
        public string phone_status_name { get; set; }
        public string call_date { get; set; }
        public string call_id { get; set; }
        public int call_talk_time { get; set; }
        public int call_total_time { get; set; }
        public int call_status_code { get; set; }
        public string call_status_name { get; set; }
        public object call_hold_time { get; set; }
        public object call_closed_by { get; set; }
    }
}
