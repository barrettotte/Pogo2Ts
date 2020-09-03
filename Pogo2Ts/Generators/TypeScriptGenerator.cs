using System;
using System.Text.RegularExpressions;
using System.IO;

namespace Pogo2Ts{

    public class TypeScriptGenerator{

        public string OutputPath { get; set; }


        public TypeScriptGenerator(string outputPath){
            OutputPath = (outputPath.EndsWith(Path.DirectorySeparatorChar)) ? outputPath : outputPath + Path.DirectorySeparatorChar;
        }

        public void Generate(GroovyDescriptor descriptor, string basePackage){
            string basePath = OutputPath + String.Join(Path.DirectorySeparatorChar, descriptor.Package.Path.Split(".")) + Path.DirectorySeparatorChar;
            
            if(!Directory.Exists(basePath)){
                Directory.CreateDirectory(basePath);
            }
            foreach(var type in descriptor.Types){
                string filePath = basePath + type.Identifier + ".ts";
                Console.WriteLine($"Generating '{filePath}' ...");

                string imports = "";
                foreach(var i in descriptor.Imports){
                   if(i.Import.StartsWith(basePackage)){
                       string importPath = i.Import.Replace(basePackage + ".", "").Replace('.', '/');
                       var split = importPath.Split('/');
                       string importType = split[split.Length-1];

                       imports += "import { " + importType + " } from './" + importPath + "'\n";
                   }
                }

                string extends = " ";
                if(type.SuperClasses.Count > 0){
                    extends = "extends ";
                    foreach(var parent in type.SuperClasses){
                        string parentType = ConvertGroovyType(parent);
                        extends += parentType + ",";

                        if(!IsPrimitive(parentType) && (descriptor.Imports.FindAll(x => x.Import.EndsWith(parentType)).Count == 0)){
                            imports += "import { " + parentType + " } from './" + parentType + "'\n";
                        }
                    }
                    extends = extends.Substring(0, extends.Length - 1);
                }

                string fields = "";
                foreach(var field in type.Fields){
                    string fieldType = ConvertGroovyType(field.Type);
                    fields += "  " + field.Identifier + "?: " + fieldType + ";\n";

                    fieldType = Regex.Replace(fieldType, @"[\[\]]", "");
                    if(!IsPrimitive(fieldType) && (descriptor.Imports.FindAll(x => x.Import.EndsWith(fieldType)).Count == 0)){
                        imports += "import { " + fieldType + " } from './" + fieldType + "'\n";
                    }
                }
                string src = $"{imports}\nexport class {type.Identifier} " + extends + "{\n" + fields + "}\n";
                File.WriteAllText(filePath, src);
            }
        }

        // convert Groovy type to TypeScript type
        private string ConvertGroovyType(string groovy){
            string[] strings  = {"String", "Char", "char"};
            string[] numerics = {"byte", "Byte", "Short", "short", "Integer", "int", "Long", "long", "Float", "float", "Double", "double", "BigDecimal"};

            if(groovy.StartsWith("List<")){
                return ConvertGroovyType(groovy.Substring(groovy.IndexOf('<') + 1, (groovy.IndexOf('>') - groovy.IndexOf('<')) - 1)) + "[]";
            } else if(groovy.Contains("[")){
                return ConvertGroovyType(groovy.Substring(0, groovy.IndexOf('[')));
            } else if(groovy == "Boolean"){
                return "boolean";
            } else if(Array.Exists(strings, x => x == groovy)){
                return "string";
            } else if(Array.Exists(numerics, x => x == groovy)){
                return "number";
            }
            return groovy;
        }

        // check if type is a TypeScript primitive
        private bool IsPrimitive(string type){
            return type == "number" || type == "boolean" || type == "string";
        }
    }
}