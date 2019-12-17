namespace TelephoneExchangeSystem.Impl
{
    using TelephoneExchangeSystem.PortEnums;

    public class Port : IPort
    {
        private PortState portState;

        private BalanceState balanceState; 
        
        public Port(int id)
        {
            this.Id = id;
            this.portState = PortState.Available;
            this.balanceState = BalanceState.Unblocked;
        }
        
        public int Id { get; }

        public (bool isAllowed, PortErrorReason errorReason) CanStartCall()
        {
            switch (this.portState)
            {
                case PortState.Busy: return (false, PortErrorReason.PortIsBusy);
                case PortState.Disconnected: return (false, PortErrorReason.PortIsDisconnected);
            }

            if (this.balanceState != BalanceState.Unblocked)
            {
                return (false, PortErrorReason.PortIsBlocked);
            }

            return (true, PortErrorReason.None);
        }

        public (bool isAllowed, PortErrorReason errorReason) CanAnswer()
        {
            switch (this.portState)
            {
                case PortState.Busy: return (false, PortErrorReason.PortIsBusy);
                case PortState.Disconnected: return (false, PortErrorReason.PortIsDisconnected);
            }

            if (this.balanceState == BalanceState.Blocked)
            {
                return (false, PortErrorReason.PortIsBlocked);
            }

            return (true, PortErrorReason.None);
        }

        public void StartCall()
        {
            this.portState = PortState.Busy;
        }

        public void FinishCall()
        {
            this.portState = PortState.Available;
        }
        
        public void Connect()
        {
            this.portState = PortState.Available;
        }

        public void Disconnect()
        {
            this.portState = PortState.Disconnected;
        }


        public void Unblock()
        {
            this.balanceState = BalanceState.Unblocked;
        }

        public void PartialBlock()
        {
            this.balanceState = BalanceState.InPartialLock;
        }
        
        public void Block()
        {
            this.balanceState = BalanceState.Blocked;
        }
    }
}