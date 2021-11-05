using System;
using System.Collections.Generic;

namespace Pogo2Ts{

    public class GroovyDescriptor{

        public string FileName                 { get; set; }
        public PackageDescriptor Package       { get; set; }
        public List<ImportDescriptor> Imports  { get; set; }
        public List<TypeDescriptor> Types      { get; set; }

        public GroovyDescriptor(){
            Imports = new List<ImportDescriptor>();
            Types = new List<TypeDescriptor>();
        }

        public override string ToString(){
            string typeNames = String.Join("\n  - ", Types);
            string importNames = "";

            foreach(var i in Imports){
                importNames += ("\n  - " + i.ToString());
            }
            return $"File      => {FileName}\nPackage   => {Package}\nImport(s) => {importNames}\nType(s) => {typeNames}";
        }
    }
}