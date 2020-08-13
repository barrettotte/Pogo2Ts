using System;
using System.Collections.Generic;
using static GroovyParser;

namespace Pogo2Ts{

    /*
        compilationUnit
 	        :	packageDeclaration? importDeclaration* typeDeclaration* EOF
	        ;
    */
    public class CompilationUnitVisitor{

        /*
            importDeclaration
                :	singleTypeImportDeclaration
                |	typeImportOnDemandDeclaration
                |	singleStaticImportDeclaration
                |	staticImportOnDemandDeclaration
                ;
        */
        public List<ImportDescriptor> VisitImportDeclarations(ImportDeclarationContext[] context){
            List<ImportDescriptor> imports = new List<ImportDescriptor>();
            ImportDeclarationVisitor visitor = new ImportDeclarationVisitor();
            
            foreach(var importContext in context){
                ImportDescriptor descriptor = new ImportDescriptor();

                // i want to vomit
                descriptor.Import = (
                    importContext.singleTypeImportDeclaration()?.typeName()?.GetText()
                    ??  importContext.typeImportOnDemandDeclaration()?.packageOrTypeName()?.GetText()
                        ??  importContext.singleStaticImportDeclaration()?.typeName()?.GetText()
                            ??  importContext.staticImportOnDemandDeclaration()?.typeName()?.GetText()
                );

                if(descriptor.Import != null){
                    throw new Exception("cringe");
                }
                imports.Add(descriptor);
            }
            return imports;
        }

        /*
            packageDeclaration
                :	packageModifier* 'package' packageName ';'?
                ;
        */
        public PackageDescriptor VisitPackageDeclaration(PackageDeclarationContext context){
            PackageDescriptor package = new PackageDescriptor();

            foreach(var modifier in context.packageModifier()){
                // TODO: not sure if needed...keeping as placeholder
            }
            package.PackageName = context.packageName()?.GetText();
            return package;
        }
    }
}