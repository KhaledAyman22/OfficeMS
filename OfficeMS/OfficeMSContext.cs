using OfficeMS.MVVM.Model;
using System.Data.Entity;


namespace OfficeMS
{
    class OfficeMSContext : DbContext
    {
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Lawsuit> Lawsuit { get; set; }
        public virtual DbSet<LawsuitRecord> LawsuitRecord { get; set; }
        public virtual DbSet<Expense> Expense { get; set; }
        public virtual DbSet<Income> Income { get; set; }
        public virtual DbSet<Authorization> Authorization { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Lawsuit>()
                .ToTable("Lawsuit");

            modelBuilder.Entity<Expense>()
                .ToTable("Expense")
                .Property(ex => ex.Date).HasColumnType("Date");

            modelBuilder.Entity<Income>()
                .ToTable("Income")
                .Property(inc => inc.Date).HasColumnType("Date");

            modelBuilder.Entity<Client>()
                .ToTable("Client");

            modelBuilder.Entity<LawsuitRecord>()
                .ToTable("LawsuitRecord")
                .Property(lsr => lsr.Date).HasColumnType("Date");

            modelBuilder.Entity<Authorization>()
                .ToTable("Authorization")
                .Property(t => t.Character).HasMaxLength(1);
        }
    }
}
