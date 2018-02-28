using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Definition
{
    partial class DtoTemplate
    {
        internal Model Model { get; }

        public DtoTemplate(Model model)
        {
            this.Model = model;
        }
    }
}
