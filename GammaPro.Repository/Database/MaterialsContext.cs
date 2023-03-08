using GammaPro.Controller.Database.Entries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GammaPro.Repository.Database
{
    public class MaterialsContext: DbContext
    {
        private readonly string connectionString;
        private static MaterialsContext instance;
        private const string DEFAULT_CONNECTION_STRING = "Data Source=Materials.db";
        public DbSet<MaterialEntry> Materials { get; set; } = null!;
        
        public MaterialsContext(string connection_string)
        {
            if (string.IsNullOrEmpty(connection_string))
                throw new ArgumentException("The connection string is empty!");
            connectionString = connection_string;
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public MaterialsContext GetInstance() => instance == null ? new MaterialsContext(DEFAULT_CONNECTION_STRING) : instance;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite(connectionString);
#if DEBUG
            //Необязательная опция для контроля создания объектов по-умолчанию
            optionsBuilder.EnableSensitiveDataLogging();
#endif
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
