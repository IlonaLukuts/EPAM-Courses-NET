namespace DataLayer.Entities
{
    using System;
    
    using System.ComponentModel.DataAnnotations;

    using System.ComponentModel.DataAnnotations.Schema;

    public class SellingEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string ClientSurname { get; set; }

        public string Product { get; set; }

        public decimal Sum { get; set; }

        public ManagerEntity Manager { get; set; }
    }
}
