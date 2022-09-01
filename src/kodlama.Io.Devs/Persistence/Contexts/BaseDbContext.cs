using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDbContext:DbContext
    {
       IConfiguration Configuration { get; set; }
        public BaseDbContext(IConfiguration configuration, DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            Configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(entity =>
            {
                entity.ToTable("ProgrammingLanguages").HasKey(programmingLanguage => programmingLanguage.Id);
                entity.Property(programmingLanguage => programmingLanguage.Id).HasColumnName("Id");
                entity.Property(programmingLanguage => programmingLanguage.Name).HasColumnName("Name");

                ProgrammingLanguage[] programmingLanguagesSeed = { new(1, "C#"), new(2, "Java") };
                modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguagesSeed);
            });
        }
    }
}
