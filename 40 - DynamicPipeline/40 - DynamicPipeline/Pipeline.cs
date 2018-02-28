using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DynamicPipeline
{
    class Pipeline<T>
    {
        public Action<T> Activate { get; }

        public Pipeline(IEnumerable<IModule> modules)
        {
            var firstModule = modules.First();

            var input = Expression.Parameter(
                firstModule
                .GetType()
                .GetMethod("Process")
                .GetParameters()
                .First()
                .ParameterType,
                "input");

            var lastCall = Expression.Call(
                Expression.Constant(firstModule),
                firstModule.GetType().GetMethod("Process"),
                input);

            foreach (var module in modules.Skip(1))
            {
                lastCall = Expression.Call(
                    Expression.Constant(module),
                    module.GetType().GetMethod("Process"),
                    lastCall);
            }

            var lambda = Expression.Lambda<Action<T>>(lastCall, input);

            this.Activate = lambda.Compile();
        }
    }
}
