using System;
using System.Data.Entity;
using System.Linq;

namespace FPTApp.Models
{
    public class FPTDBContext : DbContext
    {
        // Your context has been configured to use a 'FPTDBContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'FPTApp.Models.FPTDBContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'FPTDBContext' 
        // connection string in the application configuration file.
        public FPTDBContext()
            : base("name=FPTDBContext")
        {
        }


        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        //public virtual DbSet<Customer> Customers { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}