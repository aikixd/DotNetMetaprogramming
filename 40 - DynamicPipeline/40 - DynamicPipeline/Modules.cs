using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicPipeline
{
    public interface IModule { }

    public interface ITransitiveModule<T, U> : IModule
    {
        U Process(T argument);
    }

    public interface ILastModule<T> : IModule
    {
        void Process(T argument);
    }

    public class IntParseModule : ITransitiveModule<string, int>
    {
        public int Process(string argument)
        {
            return int.Parse(argument);
        }
    }

    public class IntLoggerModule : ILastModule<int>
    {
        public void Process(int argument)
        {
            Console.WriteLine(argument);
        }
    }
}
