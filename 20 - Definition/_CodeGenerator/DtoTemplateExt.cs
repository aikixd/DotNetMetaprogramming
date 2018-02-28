using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CodeGenerator
{
    partial class DtoTemplate
    {
        internal Model Model { get; }

        internal DtoTemplate(Model model)
        {
            this.Model = model;
        }
    }
}
