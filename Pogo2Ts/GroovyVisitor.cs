using static GroovyParser;

namespace Pogo2Ts{

    public class GroovyVisitor : GroovyParserBaseVisitor<object>{

        public GroovyDescriptor groovyDescriptor = new GroovyDescriptor();


        public override object VisitPackageDeclaration(PackageDeclarationContext context){
            PackageDescriptor descriptor = new PackageDescriptor();
            
            foreach(var modifier in context.packageModifier()){
                descriptor.Modifiers.Add(modifier.GetText());
            }
            descriptor.Path = context.packageName().GetText();
            groovyDescriptor.Package = descriptor;

            return base.VisitPackageDeclaration(context);
        }

        public override object VisitImportDeclaration(ImportDeclarationContext context){
            ImportDescriptor descriptor = new ImportDescriptor();
            descriptor.Import = context.GetText().Substring(6);  // skip over 'import'
            groovyDescriptor.Imports.Add(descriptor);

            return base.VisitImportDeclaration(context);
        }

        public override object VisitNormalClassDeclaration(NormalClassDeclarationContext context){
            TypeDescriptor descriptor = new TypeDescriptor();

            foreach(var modifier in context.classModifier()){
                if(modifier.annotation() == null){
                    descriptor.Modifiers.Add(modifier.GetText()); // skip over annotations
                }
            }
            descriptor.Type = "class";
            descriptor.Identifier = context.Identifier().GetText();
            descriptor.SuperClasses.Add(context.superclass().classType().GetText());

            SuperinterfacesContext implements = context.superinterfaces();
            if(implements != null){
                foreach(var interfaceContext in implements.interfaceTypeList().interfaceType()){
                    descriptor.SuperInterfaces.Add(interfaceContext.classType().GetText());
                }
            }
            groovyDescriptor.Types.Add(descriptor);

            return base.VisitNormalClassDeclaration(context);
        }

        public override object VisitNormalInterfaceDeclaration(NormalInterfaceDeclarationContext context){
            TypeDescriptor descriptor = new TypeDescriptor();

            foreach(var modifier in context.interfaceModifier()){
                if(modifier.annotation() == null){
                    descriptor.Modifiers.Add(modifier.GetText()); // skip over annotations
                }
            }
            descriptor.Type = "interface";
            descriptor.Identifier = context.Identifier().GetText();

            foreach(var superClass in context.extendsInterfaces().interfaceTypeList().interfaceType()){
                descriptor.SuperClasses.Add(superClass.classType().GetText());
            }
            groovyDescriptor.Types.Add(descriptor);

            return base.VisitNormalInterfaceDeclaration(context);
        }

        public override object VisitEnumDeclaration(EnumDeclarationContext context){
            TypeDescriptor descriptor = new TypeDescriptor();

            foreach(var modifier in context.classModifier()){
                if(modifier.annotation() == null){
                    descriptor.Modifiers.Add(modifier.GetText()); // skip over annotations
                }
            }
            descriptor.Type = "enum";
            descriptor.Identifier = context.Identifier().GetText();

            SuperinterfacesContext implements = context.superinterfaces();
            if(implements != null){
                foreach(var interfaceContext in implements.interfaceTypeList().interfaceType()){
                    descriptor.SuperInterfaces.Add(interfaceContext.classType().GetText());
                }
            }
            groovyDescriptor.Types.Add(descriptor);

            return base.VisitEnumDeclaration(context);
        }

    }
}