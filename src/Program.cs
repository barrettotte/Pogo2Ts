using System;
using System.IO;
using Antlr4.Runtime;

namespace Pogo2Ts{

    class Program{

        static void Main(string[] args){
            if(args.Length < 3){
                throw new ArgumentException("Not enough arguments passed. <POGO-DIR> <TS-DIR> <BASE-PACKAGE>");
            }
            // example: ```dotnet run ../model/groovy ../model/ts com.github.barrettotte.model```

            string[] fileNames = Directory.GetFiles(args[0], "*.groovy", SearchOption.AllDirectories);
            foreach(string f in fileNames){
                TypeScriptGenerator generator = new TypeScriptGenerator(args[1]);
                generator.Generate(ParseGroovyFile(f), args[2]);
            }
        }

        static GroovyDescriptor ParseGroovyFile(string srcPath){
            ICharStream src = CharStreams.fromPath(srcPath);
            GroovyLexer lexer = new GroovyLexer(src);
            CommonTokenStream stream = new CommonTokenStream(lexer);

            GroovyParser parser = new GroovyParser(stream);
            var tree = parser.compilationUnit();

            GroovyVisitor visitor = new GroovyVisitor();
            visitor.VisitCompilationUnit(tree);

            GroovyDescriptor descriptor = visitor.groovyDescriptor;
            descriptor.FileName = Path.GetFullPath(srcPath);

            return descriptor;
        }
    }
}
