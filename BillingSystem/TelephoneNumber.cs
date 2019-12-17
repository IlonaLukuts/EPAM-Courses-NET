namespace BillingSystem
{
    public class TelephoneNumber
    {
        public int Id { get; }

        public string Code { get; }

        public string Number { get; }

        public Agreement Agreement { get; set; }

        public TelephoneNumber(string number, string code)
        {
            this.Number = number;
            this.Code = code;
        }

        public string GetFullNumber()
        {
            return this.Code + this.Number;
        }
    }
}