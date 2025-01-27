﻿using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace MTG_Librarian
{
    public class MagicCardBase : MTGJSONCard
    {
        [NotMapped]
        public string   DisplayName { get; set; }
        public string   SetCode { get; set; }
        public string   Edition { get; set; }
        public double?  tcgplayerMarketPrice { get; set; }
        public double?  tcgplayerLowPrice { get; set; }
        public double?  tcgplayerMidPrice { get; set; }
        public double?  tcgplayerHighPrice { get; set; }
        [NotMapped]
        public MagicCard PartB { get; set; }
    }

    public class CardCollectionItem
    {
        [Key]
        public int      clID { get; set; }
        public string   CollectionName { get; set; }
        public int?     CardInstanceId { get; set; }
        public int      MVid { get; set; }
        public int      Count { get; set; }
        public double?  Cost { get; set; }
        public string   Tags { get; set; }
        public string   Type { get; set; }
        public bool     Virtual { get; set; }
    }

    public class CardsDbContext : DbContext
    {
        #region DbSet
        public DbSet<MagicCard> Catalog { get; set; }
        public DbSet<InventoryCard> Library { get; set; }
        public DbSet<FullInventoryCard> LibraryView { get; set; }
        public DbSet<CardSet> Sets { get; set; }
        public DbSet<CardCollection> Collections { get; set; }
        public DbSet<CollectionGroup> CollectionGroups { get; set; }
        public DbSet<CardCollectionItem> CollectionsView { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<MagicCardBase>();
            modelBuilder.Entity<InventoryCard>().Property(b => b.TimeAdded).HasDefaultValueSql("datetime('now','localtime')");
            modelBuilder.Entity<MagicCard>().HasKey(x => x.uuid);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var sqliteConn = new SqliteConnection("Data Source=cards.db;");
            optionsBuilder.UseSqlite(sqliteConn);
        }
    }

    public class CardImagesDbContext : DbContext
    {
        #region DbSet
        public DbSet<DbCardImage> CardImages { get; set; }
        #endregion
        private readonly string Edition;

        public CardImagesDbContext(string Edition)
        {
            this.Edition = Edition.SanitizeFilename();
            var dir = new DirectoryInfo($"Card Images/");
            if (!dir.Exists) dir.Create();
            string fileName = $"Card Images/{this.Edition}.db";
            var file = new FileInfo(fileName);
            if (!file.Exists)
            {
                using (SqliteConnection conn = new SqliteConnection($"Data Source={fileName}"))
                using (SqliteCommand createDB = new SqliteCommand("CREATE TABLE CardImages (uuid TEXT PRIMARY KEY, MVid INTEGER, CardImageBytes BLOB); ", conn))
                {
                    conn.Open();
                    createDB.ExecuteNonQuery();
                }
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var sqliteConn = new SqliteConnection($"Data Source=Card Images/{Edition}.db;");
            optionsBuilder.UseSqlite(sqliteConn);
        }
    }
}
