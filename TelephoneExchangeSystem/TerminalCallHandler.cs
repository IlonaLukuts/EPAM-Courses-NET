namespace TelephoneExchangeSystem
{
    using System;

    public delegate string TerminalCallHandler(object sender, TerminalCallArgs args);

    public class TerminalCallArgs
    {
        public string OutgoingTerminalNumber;

        public string IncomingTerminalNumber;

        public DateTime Date;

        public TimeSpan DurationTimeSpan;

        public TerminalCallArgs(string outgoingTerminalNumber, string incomingTerminalNumber, DateTime date, TimeSpan durationTimeSpan)
        {
            this.IncomingTerminalNumber = incomingTerminalNumber;
            this.OutgoingTerminalNumber = outgoingTerminalNumber;
            this.Date = date;
            this.DurationTimeSpan = durationTimeSpan;
        }
    }
}