using System.Collections.Generic;

namespace Pogo2Ts{

    public class PackageDescriptor{
        
        public List<string> Modifiers  { get; set; }
        public string Path             { get; set; }

        public PackageDescriptor(){
            Modifiers = new List<string>();
        }

        public override string ToString(){
            // TODO: modifiers? 
            return Path;
        }
    }
}