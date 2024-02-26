namespace BankingAPIs.ModelClass
{
    public class AccountNumber
    {
        readonly Random rand = new Random();
        public AccountNumber()
        {
            var a = "029";

            var b = Convert.ToString((long)Math.Floor(rand.NextDouble()
                * 9_000_000L + 1_000_000L));

            this.AccountGenerated = Convert.ToString(a + b);
        }

        public string AccountGenerated { get; set; }
    }
}
