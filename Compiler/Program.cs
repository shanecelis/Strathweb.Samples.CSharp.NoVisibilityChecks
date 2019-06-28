using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace Compiler
{
    public class Program
    {
        public static void Main(string[] args)
        {

          var netstandardDllDirectory = "/Users/shane/Downloads/netstandard.library.2.0.3/build/netstandard2.0/ref";
          var netstandardReferences =
            Directory.GetFiles(netstandardDllDirectory, "*.dll")
            .Select(file => MetadataReference.CreateFromFile(file))
            .ToList();
            var metadataReferences = new[]
            {
                typeof(System.Reactive.Unit).GetTypeInfo().Assembly, // System.Private.CoreLib.dll
                // typeof(Enumerable).GetTypeInfo().Assembly, // System.Linq.dll
                // typeof(Console).GetTypeInfo().Assembly, // System.Console.dll
                // Assembly.Load(new AssemblyName("System.Runtime")), // System.Runtime.dll
                // Assembly.Load(new AssemblyName("Calculator")) // Calculator.dll
            }.Select(x => MetadataReference.CreateFromFile(x.Location))
                .Concat(netstandardReferences)
                .ToList();

          var compilationOptions = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary).
                WithMetadataImportOptions(MetadataImportOptions.All);

            var topLevelBinderFlagsProperty = typeof(CSharpCompilationOptions).GetProperty("TopLevelBinderFlags", BindingFlags.Instance | BindingFlags.NonPublic);
            topLevelBinderFlagsProperty.SetValue(compilationOptions, (uint)1 << 22);

            // var code = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "..", "CrazyProgram", "Program.cs"));
            var code = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "..", "BehindTheVeil", "Class1.cs"));
            // var compilation = CSharpCompilation.Create("DynamicCrazyProgram", new[] {
            var compilation = CSharpCompilation.Create("BehindTheVeil", new[] {
                CSharpSyntaxTree.ParseText(code) }, metadataReferences, compilationOptions);

            // using (var ms = new MemoryStream())
            // {
                var cr = compilation.Emit("behind-the-veil.dll");
                //If our compilation failed, we can discover exactly why.
                if(!cr.Success)
                {
                  foreach(var diagnostic in cr.Diagnostics)
                  {
                    Console.WriteLine(diagnostic.ToString());
                  }
                }
            //     ms.Seek(0, SeekOrigin.Begin);
            //     var assembly = Assembly.Load(ms.ToArray());
            //     assembly.EntryPoint.Invoke(null, new object[] { new string[0] });
            // }

            // Console.ReadKey();
        }
    }
}
