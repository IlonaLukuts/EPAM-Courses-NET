namespace DataLayer.Entities
{
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using System.ComponentModel.DataAnnotations.Schema;

    public class ManagerEntity
    {
        public ManagerEntity()
        {
            this.Files = new List<FileEntity>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Surname { get; set; }

        public virtual ICollection<FileEntity> Files { get; set; }
    }
}
