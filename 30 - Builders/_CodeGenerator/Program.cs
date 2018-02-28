using System;
using System.IO;

namespace _CodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var targetDir = Directory.GetCurrentDirectory() + $@"..\..\App\Generated\";

            if (Directory.Exists(targetDir))
                Directory.Delete(targetDir, true);

            Directory.CreateDirectory(targetDir);

            foreach (var model in _Definition.Definition.Models)
            {
                File.WriteAllText(
                    $"{targetDir}{model.Name}.model.cs",
                    new _Definition.ModelTemplate(model).TransformText());

                File.WriteAllText(
                    $"{targetDir}{model.Name}.dto.cs",
                    new _Definition.DtoTemplate(model).TransformText());
            }

            var builders = _Extension.BuildersGenerator.GenerateBuilders(Directory.GetCurrentDirectory() + @"..\..\App\App.csproj");

            foreach (var b in builders)
                File.WriteAllText(
                    $@"{targetDir}{b.ClassName}.builder.cs",
                    b.SourceCode);

        }
    }
}
