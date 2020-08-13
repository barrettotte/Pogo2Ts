using System;
using System.IO;
using System.Collections.Generic;
using Antlr4.Runtime;

namespace Pogo2Ts{

    class Program{
        static void Main(string[] args){
            if(args.Length == 0){
                throw new ArgumentException("No arguments passed. <POGO-DIR>");
            }
            var groovyFile = ParseGroovyFile(args[0]);

            Console.WriteLine(groovyFile);

            // Groovy File => [package, import(s), classe(s)]
            // TODO: interfaces? enums?
        }

        static GroovyFileDescriptor ParseGroovyFile(string srcPath){
            GroovyFileDescriptor groovyFile = new GroovyFileDescriptor();
            groovyFile.FileName = Path.GetFullPath(srcPath);

            ICharStream src = CharStreams.fromPath(srcPath);
            GroovyLexer lexer = new GroovyLexer(src);
            CommonTokenStream stream = new CommonTokenStream(lexer);
            GroovyParser parser = new GroovyParser(stream);

            var tree = parser.compilationUnit();
            CompilationUnitVisitor visitor = new CompilationUnitVisitor();
            
            groovyFile.Package = visitor.VisitPackageDeclaration(tree.packageDeclaration());
            groovyFile.Imports = visitor.VisitImportDeclarations(tree.importDeclaration());

            return groovyFile;
        }
    }
}
