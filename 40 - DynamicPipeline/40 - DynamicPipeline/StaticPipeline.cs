using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DynamicPipeline
{
    class StaticPipeline
    {
        public static Action<string> GetPipeline()
        {
            var module1 = new IntParseModule();
            var module2 = new IntLoggerModule();

            return
                input =>
                    module2.Process(
                        module1.Process(input));
        }
    }
}
