namespace DataLayer.Entities
{
    using System.ComponentModel.DataAnnotations;

    using System.ComponentModel.DataAnnotations.Schema;

    using Enums;

    public class UserEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public UserRole UserRole { get; set; }
    }
}
