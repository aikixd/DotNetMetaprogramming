using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _CodeGenerator
{
    class Model
    {
        public string Name { get; set; }
        public List<ModelMember> Members { get; set; }
    }

    class ModelMember
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Visibility Visibility { get; set; } = Visibility.Public;
        public bool Mutable { get; set; } = true;
    }

    public enum Visibility
    {
        Public,
        Internal,
        Private
    }
}
