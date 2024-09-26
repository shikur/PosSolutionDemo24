using Microsoft.EntityFrameworkCore;
using pos.domain.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace pos.data.access
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Reciept> Reciepts { get; set; }
        public DbSet<Store> Storess { get; set; }
        public DbSet<TemplateRecipt> TemplateRecipts { get; set; }
        public DbSet<ColumnsOfAMenu> ColumnsOfAMenu { get; set; }
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(c => c.Cust_ID);
            modelBuilder.Entity<Employee>().HasKey(c => c.Emp_ID);
            modelBuilder.Entity<Item>().HasKey(c => c.Items_ID);
            modelBuilder.Entity<Menu>().HasKey(c => c.Menu_Id);
            modelBuilder.Entity<Reciept>().HasKey(c => c.Rec_ID);
            modelBuilder.Entity<Store>().HasKey(c => c.Store_ID);
            modelBuilder.Entity<TemplateRecipt>().HasKey(c => c.TempRec_ID);
            modelBuilder.Entity<Employee>().HasKey(c => c.Emp_ID);
            modelBuilder.Entity<ColumnsOfAMenu>().HasKey(c => c.column_Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}