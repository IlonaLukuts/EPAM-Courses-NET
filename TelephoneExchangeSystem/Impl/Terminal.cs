namespace TelephoneExchangeSystem.Impl
{
    using System;

    public delegate void TerminalStateHandler(object sender, string message);

    public class Terminal : ITerminal
    {
        private static string pickedUpThePhoneMessage = "The phone was picked up.";

        private static string putThePhoneDownMessage = "The phone was put down.";
        
        private static string turnedOnMessage = "The terminal was turned on.";
        
        private static string turnedOffMessage = "The terminal was turned off.";

        private static string initializedCallMessage = "The terminal initialized call.";

        public Terminal(int id, string fullNumber)
        {
            this.Id = id;
            this.FullNumber = fullNumber;
            this.IsTurnOn = false;
        }

        public event TerminalStateHandler PickedUpThePhoneEvent;

        public event TerminalStateHandler PutThePhoneDownEvent;

        public event TerminalStateHandler TurnedOnEvent;

        public event TerminalStateHandler TurnedOffEvent;

        public event TerminalCallHandler OutgoingCallEvent;

        public event TerminalCallHandler IncomingCallEvent;

        public int Id { get; }

        public string FullNumber { get; }
        
        public bool IsTurnOn { get; private set; }

        public string IncomingCall(TerminalCallArgs args)
        {
            return this.IncomingCallEvent?.Invoke(this, args);
        }

        public void PickUpThePhone()
        {
            this.OnPickedUpThePhone();
        }

        public void PutThePhoneDown()
        {
            this.OnPutThePhoneDown();
        }

        public bool TurnOn()
        {
            if (this.IsTurnOn)
            {
                return false;
            }

            this.OnTurnedOn();
            this.IsTurnOn = true;
            return true;
        }

        public bool TurnOff()
        {
            if (!this.IsTurnOn)
            {
                return false;
            }

            this.OnTurnedOff();
            this.IsTurnOn = false;
            return true;
        }

        public string Call(string number, TimeSpan durationTimeSpan)
        {
            return this.OutgoingCallEvent?.Invoke(
                this,
                new TerminalCallArgs(this.FullNumber, number, DateTime.Now, durationTimeSpan));
        }

        protected virtual void OnPickedUpThePhone()
        {
            this.CallEvent(this.PickedUpThePhoneEvent, pickedUpThePhoneMessage);
        }

        protected virtual void OnPutThePhoneDown()
        {
            this.CallEvent(this.PutThePhoneDownEvent, putThePhoneDownMessage);
        }

        protected virtual void OnTurnedOn()
        {
            this.CallEvent(this.TurnedOnEvent, turnedOnMessage);
        }

        protected virtual void OnTurnedOff()
        {
            this.CallEvent(this.TurnedOffEvent, turnedOffMessage);
        }

        private void CallEvent(TerminalStateHandler handler, string message)
        {
            handler?.Invoke(this, message);
        }
    }
}