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

            //Console.WriteLine(groovyFile);
        }

        static GroovyDescriptor ParseGroovyFile(string srcPath){
            GroovyDescriptor descriptor = new GroovyDescriptor();
            descriptor.FileName = Path.GetFullPath(srcPath);

            ICharStream src = CharStreams.fromPath(srcPath);
            GroovyLexer lexer = new GroovyLexer(src);
            CommonTokenStream stream = new CommonTokenStream(lexer);

            GroovyParser parser = new GroovyParser(stream);
            var tree = parser.compilationUnit();

            GroovyVisitor visitor = new GroovyVisitor();
            visitor.VisitCompilationUnit(tree);
            
            Console.WriteLine(visitor.groovyDescriptor);

            return descriptor;
        }
    }
}
