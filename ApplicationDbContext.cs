using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParqueaderoApp
{
    class AppDbContext : DbContext
    {

        private const string conectionStringMysql = @"server=localhost; port=3306; database=parqueaderoapp;user=root;password=root;old guids=true ";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(conectionStringMysql);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }

        
        public DbSet<Servicio> Servicios { get; set; }


    }


}
