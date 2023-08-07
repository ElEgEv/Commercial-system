using BlacksmithWorkshopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopDatabaseImplement
{
    public class BlacksmithWorkshopDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-CFLH20EE\SQLEXPRESS;Initial Catalog=BlacksmithWorkshopDatabase;Integrated Security=True;MultipleActiveResultSets=True;;TrustServerCertificate=True");
            }

            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<WorkPiece> WorkPieces { set; get; }

        public virtual DbSet<Manufacture> Manufactures { set; get; }

        public virtual DbSet<ManufactureWorkPiece> ManufactureWorkPieces { set; get; }

        public virtual DbSet<Order> Orders { set; get; }

        public virtual DbSet<Shop> Shops { set; get; }

        public virtual DbSet<ShopManufacture> ShopManufactures { get; set; }

        public virtual DbSet<Client> Clients { get; set; }

		public virtual DbSet<Implementer> Implementers { set; get; }

		public virtual DbSet<MessageInfo> Messages { set; get; }
	}
}
