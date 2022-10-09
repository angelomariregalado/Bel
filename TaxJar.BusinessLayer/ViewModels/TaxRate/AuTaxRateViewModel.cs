using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxJar.BusinessLayer
{
    public class AuTaxRateViewModel
    {
        public string zip { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public float combined_rate { get; set; }
        public bool freight_taxable { get; set; }
    }
}
