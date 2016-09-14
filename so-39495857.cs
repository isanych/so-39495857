using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Semantics;
using System;
using System.Linq;

internal static class so39495857
{
    private static void Main()
    {
        var tree = CSharpSyntaxTree.ParseText(@"
class c
{
    c Instance() => this;
    static void Main() {}
}
");
        var mscorlib = MetadataReference.CreateFromFile(typeof(object).Assembly.Location);
        var compilation = CSharpCompilation.Create(null, new[] { tree }, new[] { mscorlib });
        var model = compilation.GetSemanticModel(tree);
        var node = tree.GetRoot().DescendantNodes().OfType<ArrowExpressionClauseSyntax>().First();
        var operation = model.GetOperation(node);
        var block = (IBlockStatement)operation;
        var @return = (IReturnStatement)block.Statements.First();
        var @this = (IInstanceReferenceExpression)@return.ReturnedValue;
        Console.WriteLine(@this.InstanceReferenceKind);
    }
}
