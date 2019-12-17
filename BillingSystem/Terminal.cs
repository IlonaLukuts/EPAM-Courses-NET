namespace BillingSystem
{
    public class Terminal
    {
        public Terminal()
        {
            this.Port = new Port();
        }
        
        public int Id { get; }

        public Agreement Agreement { get; set; }

        public Port Port { get; set; }
    }
}