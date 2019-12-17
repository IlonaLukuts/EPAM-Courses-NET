namespace BillingSystem
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using TelephoneExchangeSystem;

    public class BillingSystemController
    {
        private ICollection<TelephoneCompany> telephoneCompanies;

        private ICollection<CallRecord> callRecords;

        private TelephoneExchangeSystemController telephoneExchangeSystemController;


        public BillingSystemController(TelephoneExchangeSystemController telephoneExchangeSystemController)
        {
            this.telephoneCompanies = new Collection<TelephoneCompany>();
            this.callRecords = new Collection<CallRecord>();
            this.telephoneExchangeSystemController = telephoneExchangeSystemController;
            this.telephoneExchangeSystemController.MadeCall += this.NewCallRecord;
        }

        public void NewCallRecord(
            object sender,
            string incomingNumber,
            string outgoingNumber,
            DateTime date,
            TimeSpan durationTimeSpan)
        {
            int id = 1;
            if (this.callRecords.Count != 0)
            {
                id = (from record in this.callRecords select record.Id).Max() + 1;
            }

            TelephoneNumber outgoingTelephoneNumber = this.FindNumber(outgoingNumber);
            TelephoneNumber incomingTelephoneNumber = this.FindNumber(incomingNumber);
            if (outgoingTelephoneNumber != null && incomingTelephoneNumber != null)
            {
                CallRecord callRecord = new CallRecord(
                    id,
                    outgoingTelephoneNumber,
                    incomingTelephoneNumber,
                    date,
                    durationTimeSpan,
                    incomingTelephoneNumber.Agreement.TelephoneTariff.CallPerMinuteCost.InsideCompany);
                this.callRecords.Add(callRecord);
                incomingTelephoneNumber.Agreement.ChangeBalance(callRecord.Sum * (-1M));
                if (incomingTelephoneNumber.Agreement.isBalanceNegative())
                {
                    this.telephoneExchangeSystemController.BlockPort(incomingNumber);
                }
            }
        }

        public (int terminalId, string telephoneNumber, int portId) NewAgreement(
            decimal balance,
            Client client,
            TelephoneCompany telephoneCompany,
            TelephoneTariff telephoneTariff)
        {
            Agreement agreement = telephoneCompany.AddNewAgreement(balance, client, telephoneTariff, this);
            client.AddNewAgreements(agreement);
            return (agreement.Terminal.Id, agreement.TelephoneNumber.GetFullNumber(), agreement.Terminal.Port.Id);
        }

        public TelephoneNumber FindNumber(string number)
        {
            return (from telephoneCompany in this.telephoneCompanies
                    from agreement in telephoneCompany.GetAgreements()
                    where agreement.TelephoneNumber.GetFullNumber() == number
                    select agreement.TelephoneNumber).FirstOrDefault();
        }

        public IEnumerable<CallRecord> CallRecordsHistoryBySum(TelephoneNumber telephoneNumber)
        {
            return from callRecord in this.callRecords
                   where callRecord.IncomingNumber == telephoneNumber || callRecord.OutgoingNumber == telephoneNumber
                   orderby callRecord.Sum
                   select callRecord;
        }

        public IEnumerable<CallRecord> CallRecordsHistoryOrderedByDate(TelephoneNumber telephoneNumber)
        {
            return from callRecord in this.callRecords
                   where callRecord.IncomingNumber == telephoneNumber || callRecord.OutgoingNumber == telephoneNumber
                   orderby callRecord.Date
                   select callRecord;
        }
    }
}