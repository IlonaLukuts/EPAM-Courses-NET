namespace TelephoneExchangeSystem
{
    using TelephoneExchangeSystem.PortEnums;

    public interface IPort
    {
        (bool isAllowed, PortErrorReason errorReason) CanStartCall();
        
        (bool isAllowed, PortErrorReason errorReason) CanAnswer();
        
        void StartCall();
        
        void FinishCall();
        
        void Connect();
        
        void Disconnect();
        
        void Unblock();
        
        void PartialBlock();
        
        void Block();
    }
}