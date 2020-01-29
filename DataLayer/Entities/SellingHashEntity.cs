namespace DataLayer.Entities
{
    using System.ComponentModel.DataAnnotations;

    using System.ComponentModel.DataAnnotations.Schema;
    
    public class SellingHashEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public SellingEntity Selling { get; set; }

        public int Hash { get; set; }
    }
}
