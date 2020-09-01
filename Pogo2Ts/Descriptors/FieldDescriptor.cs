using System;
using System.Collections.Generic;

namespace Pogo2Ts{

    public class FieldDescriptor{
        
        public List<string> Modifiers { get; set; }
        public string Type            { get; set; }
        public string Identifier      { get; set; }
        public string Assignment      { get; set; }


        public FieldDescriptor(){
            Modifiers = new List<string>();
        }

        public override string ToString(){
            string mods = String.Join(" ", Modifiers);
            return $"{mods} {Type} {Identifier} {Assignment}";
        }
    }
}