using System;
using System.Collections.Generic;
using static GroovyParser;

namespace Pogo2Ts{

    public class GroovyVisitor : GroovyParserBaseVisitor<object>{

        public GroovyDescriptor groovyDescriptor = new GroovyDescriptor();

        public override object VisitPackageDeclaration(PackageDeclarationContext context){
            PackageDescriptor descriptor = new PackageDescriptor();
            
            foreach(var modifier in context.packageModifier()){
                descriptor.PackageModifiers.Add(modifier.GetText());
            }
            descriptor.PackageName = context.packageName().GetText();
            groovyDescriptor.Package = descriptor;

            return base.VisitPackageDeclaration(context);
        }

        public override object VisitImportDeclaration(ImportDeclarationContext context){
            ImportDescriptor descriptor = new ImportDescriptor();

            return base.VisitImportDeclaration(context);
        }

        public override object VisitTypeDeclaration(TypeDeclarationContext context){
            TypeDescriptor descriptor = new TypeDescriptor();

            return base.VisitTypeDeclaration(context);
        }
    }
}