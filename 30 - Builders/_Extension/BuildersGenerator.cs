using _Attributes;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _Extension
{
    public class BuildersGenerator
    {
        public static IEnumerable<BuilderInfo> GenerateBuilders(string projectPath)
        {
            var workspace = MSBuildWorkspace.Create();

            var project = workspace.OpenProjectAsync(projectPath).Result;

            return
                project.Documents

                .Select(document => document.GetSemanticModelAsync().Result)

                .SelectMany(semanticModel => GetTargetClasses(semanticModel))

                .Select(classDeclaration => new BuilderInfo(
                    classDeclaration.Identifier.ToString(),
                    new BuilderTemplate(classDeclaration).TransformText()));
        }

        private static IEnumerable<ClassDeclarationSyntax> GetTargetClasses(SemanticModel semanticModel)
        {
            return 
                semanticModel.SyntaxTree.GetRoot()
                .DescendantNodes().OfType<ClassDeclarationSyntax>()
                .Where(cls =>
                    cls.AttributeLists.Any(list =>
                        list.Attributes.Any(attr =>
                        {
                            var symbol = semanticModel.GetTypeInfo(attr).Type;

                            return typeof(GenerateBuilderAttribute).FullName == $"{symbol.ContainingNamespace}.{symbol.Name}";
                        })));
                
        }
    }
}
