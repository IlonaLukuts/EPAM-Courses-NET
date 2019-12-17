namespace BillingSystem
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class Client
    {
        private ICollection<Agreement> agreements;
        
        public Client(string surname, string name, string patronymic)
        {
            this.ClientFullName = new FullName(surname, name, patronymic);
            this.agreements = new Collection<Agreement>();
        }

        public int Id { get; }

        public FullName ClientFullName { get; }

        public IEnumerable<Agreement> GetAgreements()
        {
            return (IEnumerable<Agreement>)this.agreements;
        }

        public void AddNewAgreements(Agreement agreement)
        {
            this.agreements.Add(agreement);
        }

        public class FullName
        {
            public FullName(string surname, string name, string patronymic)
            {
                this.Surname = surname;
                this.Name = name;
                this.PatronymicName = patronymic;
            }
            
            public string Surname { get; }

            public string Name { get; }

            public string PatronymicName { get; }
        }
    }
}