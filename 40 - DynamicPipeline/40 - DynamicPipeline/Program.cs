using System;

namespace DynamicPipeline
{
    class Program
    {
        static void Main(string[] args)
        {
            var pl = new Pipeline<string>(
                new[] {
                    (IModule)
                    new IntParseModule(),
                    new IntLoggerModule()
                }
            );

            pl.Activate("1234");

            Console.ReadKey();
        }
    }
}
