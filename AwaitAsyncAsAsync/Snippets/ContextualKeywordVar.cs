namespace SnippetsButAgainABitDifferentToAvoidNameClashing
{
    class ContextualKeywordVar
    {
        int var() => 0;
        int var(int var) => 0;

        void VarIdentifierAndContextualKeyword()
        {
            int a = this.var();
            var b = 0;
            int var = 0;
            var = this.var(var);
            int.TryParse("123", out var result);
        }
    }
}