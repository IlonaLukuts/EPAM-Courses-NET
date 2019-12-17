namespace BillingSystem
{
    public class TelephoneTariff
    {
        public TelephoneTariff(
            string name,
            TelephoneCompany company,
            decimal callPerMinuteCostInCompany,
            decimal callPerMinuteCostOutCompany,
            decimal smsCostInCompany,
            decimal smsCostOutCompany)
        {
            this.Name = name;
            this.Company = company;
            this.CallPerMinuteCost = new Cost(callPerMinuteCostInCompany, callPerMinuteCostOutCompany);
            this.SMSCost = new Cost(smsCostInCompany, smsCostOutCompany);
        }

        public int Id { get; }

        public string Name { get; }

        public TelephoneCompany Company { get; }

        public Cost CallPerMinuteCost { get; }

        public Cost SMSCost { get; }

        public class Cost
        {
            public Cost(decimal insideCompany, decimal outsideCompany)
            {
                this.InsideCompany = insideCompany;
                this.OutsideCompany = outsideCompany;
            }

            public decimal InsideCompany { get; }
            
            public decimal OutsideCompany { get; }
        }
    }
}