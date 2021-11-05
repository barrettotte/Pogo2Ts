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
            descriptor.Import = context.GetText().Substring(6);  // skip import declarations
            groovyDescriptor.Imports.Add(descriptor);

            return base.VisitImportDeclaration(context);
        }

        public override object VisitNormalClassDeclaration(NormalClassDeclarationContext context){
            TypeDescriptor descriptor = new TypeDescriptor();

            foreach(var modifier in context.classModifier()){
                if(modifier.annotation() == null){
                    descriptor.Modifiers.Add(modifier.GetText()); // skip class-level annotations
                }
            }
            descriptor.Type = "class";
            descriptor.Identifier = context.Identifier().GetText();

            if(context.superclass() != null){
                descriptor.SuperClasses.Add(context.superclass().classType().GetText());
            }
            if(context.superinterfaces() != null){
                foreach(var interfaceContext in context.superinterfaces().interfaceTypeList().interfaceType()){
                    descriptor.SuperInterfaces.Add(interfaceContext.classType().GetText());
                }
            }

            foreach(var classBody in context.classBody().classBodyDeclaration()){
                var member = classBody.classMemberDeclaration();
                var fieldDeclare = member.fieldDeclaration();

                if(fieldDeclare != null){
                    var field = new FieldDescriptor();

                    foreach(var modifier in fieldDeclare.fieldModifier()){
                        if(modifier.annotation() == null){
                            field.Modifiers.Add(modifier.GetText()); // skip field-level annotations
                        }
                    }
                    field.Type = fieldDeclare.unannType().GetText();

                    var identifiers = fieldDeclare.variableDeclaratorList().variableDeclarator();
                    field.Identifier = identifiers[0].variableDeclaratorId().GetText();
                    if(identifiers[0].variableInitializer() != null){
                        field.Assignment = identifiers[0].variableInitializer().GetText();   
                    }
                    descriptor.Fields.Add(field);
                }

                // Not dealing with these right now ...
                var methodDeclare = member.methodDeclaration();
                var classDeclare = member.classDeclaration();
                var interfaceDeclare = member.interfaceDeclaration();
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
