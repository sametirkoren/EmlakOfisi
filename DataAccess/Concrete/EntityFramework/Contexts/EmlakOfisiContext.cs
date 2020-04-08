using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class EmlakOfisiContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;initial catalog=EmlakOfisi;integrated security=true;");
            
        }


        public DbSet<Advert> Adverts { get; set; }
        public DbSet<AdvertType> AdvertTypes { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Heating> Heatings { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advert>()
                .HasOne<Province>(a => a.Province)
                .WithMany(p => p.Adverts)
                .HasForeignKey(a => a.ProvinceId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Advert>()
                .HasOne<District>(a => a.District)
                .WithMany(d => d.Adverts)
                .HasForeignKey(a => a.DistrictId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Advert>()
                .HasOne<Neighborhood>(a => a.Neighborhood)
                .WithMany(n => n.Adverts)
                .HasForeignKey(a => a.NeighborhoodId)
                .OnDelete(DeleteBehavior.Restrict);


        }



    }
}
