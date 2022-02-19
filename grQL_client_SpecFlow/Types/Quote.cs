using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gfQL_specFlow.Types
{
    public class Quote
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public Category Category { get; set; }
    }
}
