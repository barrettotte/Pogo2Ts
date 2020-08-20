namespace Pogo2Ts{

    public class ImportDescriptor{

        public string Import  { get; set; }

        // TODO: separate path and identifier ?

        public override string ToString(){
            return Import;
        }
    }
}