using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Extension
{
    public partial class BuilderTemplate
    {
        public ClassDeclarationSyntax ClassDeclaration { get; }

        public string ClassName => this.ClassDeclaration.Identifier.ToString();

        public string Namespace => this.ClassDeclaration.FirstAncestorOrSelf<NamespaceDeclarationSyntax>().Name.ToFullString();

        public IEnumerable<(string Name, string Type)> Members =>
            this
            .ClassDeclaration
            .Members
            .OfType<PropertyDeclarationSyntax>()
            .Select(x => (x.Identifier.ToString(), x.Type.ToString()))
            .Union(
                this
                .ClassDeclaration
                .Members
                .OfType<FieldDeclarationSyntax>()
                .Select(x => x.ChildNodes().OfType<VariableDeclarationSyntax>().First())
                .Select(x => (x.ChildNodes().First().ToString(), x.ChildNodes().Skip(1).First().ToString())));

        public BuilderTemplate(ClassDeclarationSyntax classDeclaration)
        {
            this.ClassDeclaration = classDeclaration;
        }
    }
}
