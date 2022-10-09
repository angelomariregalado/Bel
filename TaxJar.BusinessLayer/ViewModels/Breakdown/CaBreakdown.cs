using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxJar.BusinessLayer
{
    public class CaBreakdown
    {
        public float gst_taxable_amount { get; set; }
        public float gst_tax_rate { get; set; }
        public float gst { get; set; }
        public float pst_taxable_amount { get; set; }
        public float pst_tax_rate { get; set; }
        public float pst { get; set; }
        public float qst_taxable_amount { get; set; }
        public float qst_tax_rate { get; set; }
        public float qst { get; set; }
        public object shipping { get; set; }
        public List<LineItemViewModel> line_items { get; set; }
    }
}
