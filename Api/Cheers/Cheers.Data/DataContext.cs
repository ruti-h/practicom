

using Cheers.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cheers.Data
{
  public  class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Male> Males { get; set; }
        public DbSet<Woman> Womens { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<FamilyDetail> FamilyDetails { get; set; }
        public DbSet<MatchMaker> MatchMakers { get; set; }
        public DbSet<MatchMaking> MatchMakings { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<User> Users { get; set; }
        
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=DB-Of-MatchMakings");
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-SSNMLFD;Initial Catalog=ImageDesign;Integrated Security=false;  Trusted_Connection = SSPI; MultipleActiveResultSets = true; TrustServerCertificate = true");
        }
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=DB-Of-MatchMakings");
        //}
    }
}
