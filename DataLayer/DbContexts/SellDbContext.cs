namespace DataLayer.DbContexts
{
    using System.Data.Entity;

    using Entities;

    public class SellDbContext : DbContext
    {
        public SellDbContext()
            : base("DBSellProcessing")
        {

        }

        public DbSet<FileEntity> Files { get; set; }

        public DbSet<FileHashEntity> FileHashes { get; set; }

        public DbSet<ManagerEntity> Managers { get; set; }

        public DbSet<SellingEntity> Sellings { get; set; }

        public DbSet<SellingHashEntity> SellingHashes { get; set; }


    }
}
