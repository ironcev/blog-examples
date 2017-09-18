namespace SnippetsButABitDifferentToAvoidNameClashing
{
    public class var
    {
        public static implicit operator var (string text)
        {
            return null;
        }
    }

    public class Var
    {
        void IAmJustADummyMethod()
        {
            var text = "var";
        }
    }
}