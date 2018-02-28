using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CodeGenerator
{
    partial class SimpleTemplate
    {
        public int Limit { get; }

        public SimpleTemplate(int limit)
        {
            this.Limit = limit;
        }
    }
}
