namespace DataLayer.Entities
{
    using System.ComponentModel.DataAnnotations;

    using System.ComponentModel.DataAnnotations.Schema;

    using Enums;

    public class FileHashEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public FileEntity File { get; set; }

        public int Hash { get; set; }

        public FileProcessingState ProcessingState { get; set; }
    }
}
