namespace TelephoneExchangeSystem
{
    using System;

    using TelephoneExchangeSystem.Impl;

    public interface ITerminal
    {
        event TerminalStateHandler PickedUpThePhoneEvent;

        event TerminalStateHandler PutThePhoneDownEvent;

        event TerminalStateHandler TurnedOnEvent;

        event TerminalStateHandler TurnedOffEvent;

        event TerminalCallHandler OutgoingCallEvent;

        event TerminalCallHandler IncomingCallEvent;

        int Id { get; }

        string FullNumber { get; }
        
        void PickUpThePhone();

        void PutThePhoneDown();

        bool TurnOn();

        bool TurnOff();

        string Call(string number, TimeSpan durationTimeSpan);

        string IncomingCall(TerminalCallArgs args);
    }
}