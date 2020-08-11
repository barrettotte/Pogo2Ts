using System.Collections.Generic;

namespace GroovyToTS{

    public interface ICodeGenerator{
        string ToSourceCode(string idNamespace, List<ClassDescriptor> classes);
    }

}