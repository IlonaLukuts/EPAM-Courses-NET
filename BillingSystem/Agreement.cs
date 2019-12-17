namespace BillingSystem
{
    public class Agreement
    {
        public int Id { get; }
        
        public int AgreementNumber { get; }

        public decimal Balance { get; private set; }

        public Client Client { get; }
        
        public TelephoneNumber TelephoneNumber { get; }

        public Terminal Terminal { get; }

        public TelephoneCompany TelephoneCompany { get; }

        public TelephoneTariff TelephoneTariff { get; }

        public Agreement(
            int agreementNumber,
            decimal balance,
            Client client,
            TelephoneNumber telephoneNumber,
            Terminal terminal,
            TelephoneCompany telephoneCompany,
            TelephoneTariff telephoneTariff)
        {
            this.AgreementNumber = agreementNumber;
            this.Balance = balance;
            this.Client = client;
            this.TelephoneNumber = telephoneNumber;
            this.Terminal = terminal;
            this.TelephoneCompany = telephoneCompany;
            this.TelephoneTariff = telephoneTariff;
        }

        public bool isBalanceNegative()
        {
            return this.Balance <= 0.0M;
        }

        public void ChangeBalance(decimal sum)
        {
            this.Balance += sum;
        }
    }
}