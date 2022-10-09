using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxJar.BusinessLayer
{
    public class IntBreakdown
    {
        public float country_taxable_amount { get; set; }
        public float country_tax_rate { get; set; }
        public float country_tax_collectable { get; set; }
        public object shipping { get; set; }
        public List<LineItemViewModel> line_items { get; set; }
    }
}
