using System;
using System.Collections.Generic;
using System.Text;

namespace VoiqXApiCliente.Models {
    public class Phone {
        public string reference_code { get; set; }
        public string phone { get; set; }
        public object call_status_code { get; set; }
        public object call_status { get; set; }
        public int module_status_code { get; set; }
        public string module_status { get; set; }
        public object date_last_try { get; set; }
    }
}
