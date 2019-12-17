namespace TelephoneExchangeSystem
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Xml.Serialization;

    using TelephoneExchangeSystem.Impl;
    using TelephoneExchangeSystem.PortEnums;

    public class TelephoneExchangeSystemController
    {
        private Dictionary<ITerminal, IPort> terminalAndPortsDictionary;

        private static string wrongNumberMessage = "Wrong number.";

        private static string terminalIsBusyMessage = "The terminal is busy.";

        private static string terminalIsDisconnectMessage = "The terminal is disconnect.";

        private static string terminalIsBlockedMessage = "The terminal is block. Check your balance.";

        private static string incomingTerminalIsBlockedMessage = "The incoming terminal is block.";

        private ICollection<TerminalCallArgs> currentCallsArgs;

        public TelephoneExchangeSystemController()
        {
            this.terminalAndPortsDictionary = new Dictionary<ITerminal, IPort>();
            this.currentCallsArgs = new Collection<TerminalCallArgs>();
        }
        
        public delegate void CallRecordHandler(object sender, string incomingNumber, string outgoingNumber, DateTime date, TimeSpan durationTimeSpan);

        public event CallRecordHandler MadeCall;

        public bool AddTerminalAndPort(int terminalId, string telephoneNumber, int portId)
        {
            ITerminal terminal = new Terminal(terminalId, telephoneNumber);
            IPort port = new Port(portId);
            if (this.terminalAndPortsDictionary.Keys.FirstOrDefault(x => x.FullNumber == telephoneNumber) != null)
            {
                return false;
            }

            this.terminalAndPortsDictionary.Add(terminal, port);
            return true;
        }

        public void TurnOnTerminal(ITerminal terminal)
        {
            terminal.TurnOn();
        }

        public void TurnOffTerminal(ITerminal terminal)
        {
            terminal.TurnOff();
        }

        public void TurnOnHandler(object sender, string message)
        {
            ITerminal terminal = sender as ITerminal;
            terminal.TurnedOffEvent += this.TurnOffHandler;
            terminal.IncomingCallEvent += this.IncomingCallHandler;
            terminal.OutgoingCallEvent += this.OutgoingCallHandler;
            terminal.TurnedOnEvent -= this.TurnOnHandler;
            this.terminalAndPortsDictionary[terminal].Connect();
        }

        public void TurnOffHandler(object sender, string message)
        {
            ITerminal terminal = sender as ITerminal;
            terminal.TurnedOffEvent -= this.TurnOffHandler;
            terminal.PickedUpThePhoneEvent -= this.PickedUpThePhoneHandler;
            terminal.IncomingCallEvent -= this.IncomingCallHandler;
            terminal.OutgoingCallEvent -= this.OutgoingCallHandler;
            terminal.TurnedOnEvent += this.TurnOnHandler;
            terminal.PutThePhoneDownEvent -= this.PutThePhoneDownHandler;
            this.terminalAndPortsDictionary[terminal].Disconnect();
        }

        public void PickedUpThePhoneHandler(object sender, string message)
        {
            ITerminal incomingTerminal = sender as ITerminal;
            TerminalCallArgs callArgs = this.FindCallByIncoming(incomingTerminal.FullNumber);
            if (callArgs != null)
            {
                ITerminal outgoingTerminal = FindTerminal(callArgs.OutgoingTerminalNumber);
                this.DuringFinishCall(outgoingTerminal, incomingTerminal, callArgs);
            }
        }

        private void DuringFinishCall(ITerminal outgoingTerminal, ITerminal incomingTerminal, TerminalCallArgs args)
        {
            this.terminalAndPortsDictionary[outgoingTerminal].FinishCall();
            this.OnMadeCall(this, args.IncomingTerminalNumber, args.OutgoingTerminalNumber, args.Date, args.DurationTimeSpan);
            outgoingTerminal.OutgoingCallEvent += this.OutgoingCallHandler;
        }

        public void PutThePhoneDownHandler(object sender, string message)
        {
            ITerminal incomingTerminal = sender as ITerminal;
            TerminalCallArgs callArgs = this.FindCallByIncoming(incomingTerminal.FullNumber);
            if (callArgs != null)
            {
                callArgs.DurationTimeSpan = TimeSpan.Zero;
                ITerminal outgoingTerminal = FindTerminal(callArgs.OutgoingTerminalNumber);
                this.DuringFinishCall(outgoingTerminal, incomingTerminal, callArgs);
            }
        }

        public string OutgoingCallHandler(object sender, TerminalCallArgs args)
        {
            ITerminal outgoingTerminal = sender as ITerminal;
            IPort outgoingPort = this.terminalAndPortsDictionary[outgoingTerminal];
            var canStartingCallArgs = outgoingPort.CanStartCall();
            if (!canStartingCallArgs.isAllowed)
            {
                switch (canStartingCallArgs.errorReason)
                {
                    case PortErrorReason.PortIsBlocked: return terminalIsBlockedMessage;
                    case PortErrorReason.PortIsBusy: return terminalIsBusyMessage;
                }
            }

            ITerminal incomingTerminal = this.FindTerminal(args.IncomingTerminalNumber);
            if (incomingTerminal == null)
            {
                return wrongNumberMessage;
            }

            outgoingPort.StartCall();
            outgoingTerminal.OutgoingCallEvent -= this.OutgoingCallHandler;
            return incomingTerminal.IncomingCall(args);
        }

        public string IncomingCallHandler(object sender, TerminalCallArgs args)
        {
            ITerminal incomingTerminal = sender as ITerminal;
            IPort incomingPort = this.terminalAndPortsDictionary[incomingTerminal];
            var canAnswer = incomingPort.CanAnswer();
            if (!canAnswer.isAllowed)
            {
                args.DurationTimeSpan = TimeSpan.Zero;
                ITerminal outgoingTerminal = this.FindTerminal(args.OutgoingTerminalNumber);
                this.DuringFinishCall(outgoingTerminal, incomingTerminal, args);
                switch (canAnswer.errorReason)
                {
                    case PortErrorReason.PortIsBlocked: return terminalIsBlockedMessage;
                    case PortErrorReason.PortIsBusy: return incomingTerminalIsBlockedMessage;
                    case PortErrorReason.PortIsDisconnected: return terminalIsDisconnectMessage;
                }
            }

            incomingTerminal.PickedUpThePhoneEvent += this.PickedUpThePhoneHandler;
            incomingTerminal.PutThePhoneDownEvent += this.PutThePhoneDownHandler;
            this.currentCallsArgs.Add(args);
            return "Calling.";
        }

        public void OnMadeCall(object sender, string incomingNumber, string outgoingNumber, DateTime date, TimeSpan durationTimeSpan)
        {
            this.MadeCall?.Invoke(this, incomingNumber, outgoingNumber, date, durationTimeSpan);
        }

        public void BlockPort(string number)
        {
            ITerminal terminal = this.FindTerminal(number);
            if (terminal != null)
            {
                this.terminalAndPortsDictionary[terminal].PartialBlock();
            }
        }

        private ITerminal FindTerminal(string number)
        {
            return this.terminalAndPortsDictionary.Keys.FirstOrDefault(x => x.FullNumber == number);
        }

        private TerminalCallArgs FindCall(string number)
        {
            return this.currentCallsArgs.FirstOrDefault(
                x => x.IncomingTerminalNumber == number || x.OutgoingTerminalNumber == number);
        }

        private TerminalCallArgs FindCallByIncoming(string number)
        {
            return this.currentCallsArgs.FirstOrDefault(x => x.IncomingTerminalNumber == number);
        }
    }
}