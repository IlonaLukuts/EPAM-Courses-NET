namespace BillingSystem
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class TelephoneCompany
    {
        private static Random rand = new Random();
        
        private ICollection<TelephoneTariff> telephoneTariffs;

        private ICollection<Agreement> agreements;
        
        public TelephoneCompany(string name, string country, string telephoneCode)
        {
            this.Name = name;
            this.Country = country;
            this.TelephoneCode = telephoneCode;
            this.telephoneTariffs = new Collection<TelephoneTariff>();
            this.agreements = new Collection<Agreement>();
        }
        
        public int Id { get; }

        public string Name { get; }

        public string Country { get; }

        public string TelephoneCode { get; }
        
        public IEnumerable<TelephoneTariff> GetTelephoneTariffs()
        {
            return (IEnumerable<TelephoneTariff>)this.telephoneTariffs;
        }

        public IEnumerable<Agreement> GetAgreements()
        {
            return (IEnumerable<Agreement>)this.agreements;
        }

        public Agreement AddNewAgreement(
            decimal balance,
            Client client,
            TelephoneTariff telephoneTariff,
            BillingSystemController billingSystemController)
        {
            int agreementNumber;
            do
            {
                agreementNumber = rand.Next();
            }
            while ((from agreement in this.agreements select agreement.AgreementNumber).Contains(agreementNumber));

            string telephoneNumberString;
            do
            {
                telephoneNumberString = rand.Next().ToString();
            }
            while (billingSystemController.FindNumber(telephoneNumberString) != null);

            TelephoneNumber telephoneNumber = new TelephoneNumber(telephoneNumberString, this.TelephoneCode);
            Terminal terminal = new Terminal();
            Agreement newAgreement = new Agreement(
                agreementNumber,
                balance,
                client,
                telephoneNumber,
                terminal,
                this,
                telephoneTariff);
            this.agreements.Add(newAgreement);
            terminal.Agreement = newAgreement;
            telephoneNumber.Agreement = newAgreement;
            return newAgreement;
        }
    }
}