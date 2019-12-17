namespace BillingSystem
{
    using System;

    public class CallRecord
    {
        public CallRecord(
            int id,
            TelephoneNumber outgoingNumber,
            TelephoneNumber incomingNumber,
            DateTime date,
            TimeSpan duration,
            decimal costPerMinute)
        {
            this.Id = id;
            this.OutgoingNumber = outgoingNumber;
            this.IncomingNumber = incomingNumber;
            this.Date = date;
            this.Duration = duration;
            this.Sum = decimal.Parse((Math.Ceiling(duration.TotalSeconds / 60.0)).ToString()) * costPerMinute;
        }

        public int Id { get; }

        public TelephoneNumber OutgoingNumber { get; }

        public TelephoneNumber IncomingNumber { get; }

        public DateTime Date { get; }

        public TimeSpan Duration { get; }

        public decimal Sum { get; }
    }
}