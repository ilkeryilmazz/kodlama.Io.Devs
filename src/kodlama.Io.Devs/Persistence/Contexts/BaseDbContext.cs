using Core.Security.Entities;
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
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<ProgrammingTechnology> ProgrammingTechnologies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<UserGithub> UserGithubs { get; set; }
        public BaseDbContext(IConfiguration configuration, DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            Configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguage>(a =>
            {
                a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");

                a.HasMany(c => c.ProgrammingTechnologies);
            });
            modelBuilder.Entity<OperationClaim>(a =>
            {
                a.ToTable("OperationClaims").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");

               
            });
            modelBuilder.Entity<UserGithub>(a =>
            {
                a.ToTable("UserGithubs").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.UserId).HasColumnName("UserId");
                a.Property(p => p.GithubAddress).HasColumnName("GithubAddress");


            });
            modelBuilder.Entity<UserOperationClaim>(a =>
            {
                a.ToTable("UserOperationClaims").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.UserId).HasColumnName("UserId");
                a.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
                a.HasOne(c => c.User);
                a.HasOne(c => c.OperationClaim);
            });
            modelBuilder.Entity<User>(a =>
            {
                a.ToTable("Users").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.FirstName).HasColumnName("FirstName");
                a.Property(p => p.LastName).HasColumnName("LastName");
                a.Property(p => p.Email).HasColumnName("Email");
                a.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
                a.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
                a.Property(p => p.Status).HasColumnName("Status");
                a.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");

                a.HasMany(c => c.UserOperationClaims);
                a.HasMany(c => c.RefreshTokens);
                a.HasOne(c => c.UserGithub);

            });
            modelBuilder.Entity<ProgrammingTechnology>(a =>
            {
                a.ToTable("ProgrammingTechnologies").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.Description).HasColumnName("Description");
                a.Property(p => p.ImageUrl).HasColumnName("ImageUrl");

                a.HasOne(c => c.ProgrammingLanguage);

            });


            ProgrammingLanguage[] programmingLanguagesSeed = { new(1, "C#"), new(2, "Java") };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguagesSeed);


            OperationClaim[] operationClaimsSeed = { new(1, "Admin"), new(2, "Moderator") };
            modelBuilder.Entity<OperationClaim>().HasData(operationClaimsSeed);


            ProgrammingTechnology[] programmingTechnologiesSeed = { new(1,"ASP.NET","",1,""), new(2, "WPF", "", 1, ""), new(3, "Spring", "", 2, ""), };
            modelBuilder.Entity<ProgrammingTechnology>().HasData(programmingTechnologiesSeed);
        }
    }
}
