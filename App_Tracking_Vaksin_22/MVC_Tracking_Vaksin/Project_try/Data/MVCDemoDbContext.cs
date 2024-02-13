using Microsoft.EntityFrameworkCore;
using Project_try.Models;

namespace Project_try.Data
{
    public class MVCDemoDbContext:DbContext
    {
        public MVCDemoDbContext(DbContextOptions options): base(options) 
        { }

        public DbSet<Vaksin> Vaksins { get; set; }
        public DbSet<Penduduk> Penduduk { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<ReportInnVaksin> ReportInnVaksin { get;set; }
        public DbSet<ReportUseVaksin > ReportUseVaksin { get;set; }


    }


}
