using System;
using System.IO;
using Antlr4.Runtime;

namespace Pogo2Ts{

    class Program{


        static void Main(string[] args){
            if(args.Length == 0){
                throw new ArgumentException("No arguments passed. <POGO-DIR>");
            }
            var groovyFile = ParseGroovyFile(args[0]);

            //Console.WriteLine(groovyFile);
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

            Console.WriteLine(descriptor);

            return descriptor;
        }
    }
}
