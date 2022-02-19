namespace gfQL_specFlow.Pages
{
    internal class RechnerPage
    {
        public int zahl1 { get; set; }
        public int zahl2 { get; set; }
        public int ergebnis { get; set; }

        public int addiere()
        {
            ergebnis = zahl1 + zahl2;
            return ergebnis;
        }

        public int multipiziere()
        {
            ergebnis = zahl1 * zahl2;
            return ergebnis;
        }
    }
}
