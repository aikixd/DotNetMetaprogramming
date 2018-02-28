using System;
using System.Collections.Generic;
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

            foreach (var model in Definition.Models)
            {
                File.WriteAllText(
                    $"{targetDir}{model.Name}.model.cs",
                    new ModelTemplate(model).TransformText());

                File.WriteAllText(
                    $"{targetDir}{model.Name}.dto.cs",
                    new DtoTemplate(model).TransformText());
            }
        }

        
        
    }
}
 