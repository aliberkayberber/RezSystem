using Microsoft.EntityFrameworkCore;
using RezSystem.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezSystem.Data.Context
{
    public class RezSystemDbContext : DbContext
    {

        public RezSystemDbContext(DbContextOptions<RezSystemDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());


            base.OnModelCreating(modelBuilder);
        }


        public DbSet<UserEntity> Users => Set<UserEntity>();
        public DbSet<EventEntity> Events => Set<EventEntity>();
        public DbSet<ReservationEntity> Reservations => Set<ReservationEntity>();



    }
}
