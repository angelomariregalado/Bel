using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxJar.BusinessLayer
{
    public class EuTaxRateViewModel
    {
        public string country { get; set; }
        public string name { get; set; }
        public float standard_rate { get; set; }
        public float reduced_rate { get; set; }
        public float super_reduced_rate { get; set; }
        public float parking_rate { get; set; }
        public float distance_sale_threshold { get; set; }
        public bool freight_taxable { get; set; }
    }
}
