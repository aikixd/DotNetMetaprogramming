using System;
using System.IO;

namespace _CodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            File.WriteAllText(
                Directory.GetCurrentDirectory() + @"..\..\App\Program.cs",
                new SimpleTemplate(10).TransformText());
        }
    }
}
