using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class OMAContext : DbContext
    {
        public OMAContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    FirstName = "James",
                    LastName = "Bond",
                    CotactNumber = "03453534543",
                    IsDeleted = false,
                    Email = "James.Bond@HerMajesty.com"
                },
                 new Customer
                 {
                     Id = 2,
                     FirstName = "Jai",
                     LastName = "Sinna",
                     CotactNumber = "3333333",
                     IsDeleted = false,
                     Email = "Jai.Sinna@Gmail.com"
                 }
            );
            modelBuilder.Entity<Address>().HasData(
           new Address
           {
               Id = 1,
               CustomerId = 1,
               AddressLine1 = "Some Place",
               AddressLine2 = "London",
               City = "London",
               State = "LHR",
               Country = "Uk"

           },
            new Address
            {
                Id = 2,
                CustomerId = 2,
                AddressLine1 = "Some Place",
                AddressLine2 = "London",
                City = "London2",
                State = "LHR2",
                Country = "Uk2"
            }
       );
            modelBuilder.Entity<Order>().HasData(
               new Order
               {
                   Id = 1,
                   CustomerId = 1,
                   OrderDate = new DateTime(2022, 10, 20),
                   Description = "",
                   TotalAmount = 500,
                   DepositAmount = 10,
                   IsDelivery = true,
                   Status = Core.Enum.Status.Pending,
                   OrderNotes = "Somehing else",
                   IsDeleted = false

               },
               new Order
               {
                   Id = 2,
                   CustomerId = 2,
                   OrderDate = new DateTime(2022, 11, 10),
                   Description = "",
                   TotalAmount = 5000,
                   DepositAmount = 200,
                   IsDelivery = false,
                   Status = Core.Enum.Status.Draft,
                   OrderNotes = "Somehing else",
                   IsDeleted = false

               }
           );
            base.OnModelCreating(modelBuilder);


        }

    }
}