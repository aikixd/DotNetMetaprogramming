using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Extension
{
    public class BuilderInfo
    {
        public string ClassName { get; }
        public string SourceCode { get; }

        public BuilderInfo(string className, string sourceCode)
        {
            this.ClassName = className;
            this.SourceCode = sourceCode;
        }
    }
}
