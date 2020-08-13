using System;
using System.Collections.Generic;

namespace Pogo2Ts{

    public class GroovyFileDescriptor{

        public string FileName {get; set;}
        public PackageDescriptor Package {get; set;}
        public List<ImportDescriptor> Imports {get; set;}
        public List<ClassDescriptor> Classes {get; set;}

        public GroovyFileDescriptor(){
            Imports = new List<ImportDescriptor>();
            Classes = new List<ClassDescriptor>();
        }

        public override string ToString(){
            string importNames = String.Join("\n  - ", Imports);
            string classNames = String.Join("\n  - ", Classes);
            return $"File      => {FileName}\nPackage   => {Package}\nImport(s) => {importNames}\nClasse(s) => {classNames}";
        } 

    }

}
