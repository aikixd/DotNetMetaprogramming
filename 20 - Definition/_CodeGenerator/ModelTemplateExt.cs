using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CodeGenerator
{
    partial class ModelTemplate
    {
        internal Model Model { get; }

        internal ModelTemplate(Model model)
        {
            this.Model = model;
        }
    }
}
