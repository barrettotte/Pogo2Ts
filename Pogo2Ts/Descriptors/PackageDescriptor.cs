using System.Collections.Generic;

namespace Pogo2Ts{

    public class PackageDescriptor{
        
        public List<string> PackageModifiers { get; set; }
        public string PackageName { get; set; }

        public PackageDescriptor(){
            PackageModifiers = new List<string>();
        }

        public override string ToString(){
            // TODO: PackageModifiers? 
            return PackageName;
        }

    }
}