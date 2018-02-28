using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Definition
{
    public partial class ModelTemplate
    {
        internal Model Model { get; }

        public ModelTemplate(Model model)
        {
            this.Model = model;
        }
    }
}
