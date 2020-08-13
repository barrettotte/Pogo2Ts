using System;
using System.Collections.Generic;
using static GroovyParser;

namespace Pogo2Ts{

    /*
        importDeclaration
            :	singleTypeImportDeclaration
            |	typeImportOnDemandDeclaration
            |	singleStaticImportDeclaration
            |	staticImportOnDemandDeclaration
            ;
    */
    public class ImportDeclarationVisitor{

        /*
            singleTypeImportDeclaration
                :	'import' typeName ';'?
                ;
        */
        public ImportDescriptor SingleTypeImportDeclaration(SingleTypeImportDeclarationContext context){
            ImportDescriptor descriptor = new ImportDescriptor();
            TypeNameContext import = context.typeName();

            if(import != null){
                descriptor.Import = import?.GetText();
                return descriptor;
            }
            throw new Exception("Error visiting singleTypeImportDeclaration node");
        }

        /*
            typeImportOnDemandDeclaration
	            :	'import' packageOrTypeName '.' '*' ';'?
	            ;
        */
        public ImportDescriptor TypeImportOnDemandDeclaration(TypeImportOnDemandDeclarationContext context){
            ImportDescriptor descriptor = new ImportDescriptor();
            PackageOrTypeNameContext import = context.packageOrTypeName();

            if(import != null){
                descriptor.Import = import.GetText();
                return descriptor;
            }
            throw new Exception("Error visiting typeImportOnDemandDeclaration node");
        }

        /*
            singleStaticImportDeclaration
	            :	'import' 'static' typeName '.' Identifier ';'?
	            ;
        */
        public ImportDescriptor SingleStaticImportDeclaration(SingleStaticImportDeclarationContext context){
            ImportDescriptor descriptor = new ImportDescriptor();
            TypeNameContext import = context.typeName();

            if(import != null){
                descriptor.Import = import.GetText();
                return descriptor;
            }
            throw new Exception("Error visiting singleStaticImportDeclaration node");
        }


        /*
            staticImportOnDemandDeclaration
                :	'import' 'static' typeName '.' '*' ';'?
                ;
        */
        public ImportDescriptor StaticImportOnDemandDeclarationContext(StaticImportOnDemandDeclarationContext context){
            ImportDescriptor descriptor = new ImportDescriptor();
            var import = context.typeName();

            if(import != null){
                descriptor.Import = import.GetText();
                return descriptor;
            }
            throw new Exception("Error visiting staticImportOnDemandDeclaration node");
        }
    }
}