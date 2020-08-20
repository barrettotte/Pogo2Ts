using System;
using System.Collections.Generic;

namespace Pogo2Ts{

    public class TypeDescriptor{
        
        public string Type                   { get; set; }  // class/enum/interface 
        public List<string> Modifiers        { get; set; }
        public string Identifier             { get; set; }
        public List<string> SuperClasses     { get; set; }
        public List<string> SuperInterfaces  { get; set; }


        public TypeDescriptor(){
            Modifiers = new List<string>();
            SuperClasses = new List<string>();
            SuperInterfaces = new List<string>();
        }

        public override string ToString(){
            string mods = String.Join(" ", Modifiers);
            string extends = (SuperClasses.Count > 0) ? "extends " + String.Join(",", SuperClasses) : "";
            string implements = (SuperInterfaces.Count > 0) ? "implements " + String.Join(",", SuperInterfaces) : "";

            return $"{mods} {Type} {Identifier} {extends} {implements}";
        }
    }
}