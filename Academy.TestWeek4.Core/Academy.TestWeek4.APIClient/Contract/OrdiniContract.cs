using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.TestWeek4.APIClient.Contract
{
    public class OrdiniContract
    {
        public int ID { get; set; }

        
        public DateTime DataOrdine { get; set; }

        
        public string CodiceOrdine { get; set; }

        
        public string CodiceProdotto { get; set; }

        
        public decimal Importo { get; set; }

    }
}
