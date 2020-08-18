using System;
using System.Collections.Generic;

namespace Pogo2Ts{

    public class GroovyDescriptor{

        public string FileName {get; set;}
        public PackageDescriptor Package {get; set;}
        public List<ImportDescriptor> Imports {get; set;}
        public List<TypeDescriptor> Types {get; set;}

        public GroovyDescriptor(){
            Imports = new List<ImportDescriptor>();
            Types = new List<TypeDescriptor>();
        }

        public override string ToString(){
            string importNames = String.Join("\n  - ", Imports);
            string typeNames = String.Join("\n  - ", Types);
            return $"File      => {FileName}\nPackage   => {Package}\nImport(s) => {importNames}\nType(s) => {typeNames}";
        } 

    }

}
