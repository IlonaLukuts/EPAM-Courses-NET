namespace DataLayer.Entities
{
    using System;
   
    using System.ComponentModel.DataAnnotations;

    using System.ComponentModel.DataAnnotations.Schema;

    public class FileEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public ManagerEntity Manager { get; set; }

        public DateTime DateTime { get; set; }
    }
}
