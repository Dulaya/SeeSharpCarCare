
using Microsoft.EntityFrameworkCore;
using SeeSharpCarCare.Core.Models;

namespace SeeSharpCarCare.Core.Data;

public class SeeSharpCarCareDbContext : DbContext
{
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Repair> Repairs { get; set; }
    public DbSet<Technician> Technicians { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<WorkOrder> WorkOrders { get; set; }
    public DbSet<RepairCode> RepairCodes { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseSqlite("Data Source = SeeSharpCarCare.db");
        optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=SeeSharpCarCare;Trusted_Connection=true;TrustServerCertificate=true;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(customer => customer.CustomerName)
            .ValueGeneratedOnAdd()
            .IsRequired();

            entity
            .HasMany(customer => customer.Invoices)
            .WithOne(invoice => invoice.Customer);

            entity
            .HasMany(customer => customer.WordkOrders)
            .WithOne(workOrder => workOrder.Customer);
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity
            .HasOne(invoice => invoice.Customer)
            .WithMany(customer => customer.Invoices)
            .HasForeignKey(invoice => invoice.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

            entity
            .HasOne(invoice => invoice.Vehicle)
            .WithMany(vehicle => vehicle.Invoices)
            .HasForeignKey(invoice => invoice.VIN)
            .OnDelete(DeleteBehavior.Restrict);

            // entity
            // .HasMany(invoice => invoice.Technicians)
            // .WithMany(technician => technician.Invoices);

            entity
            .HasOne(invoice => invoice.WorkOrder)
            .WithOne(workOrder => workOrder.Invoice);

            entity
            .HasOne(invoice => invoice.WorkOrder)
            .WithOne(workOrder => workOrder.Invoice)
            .HasForeignKey<Invoice>(invoice => invoice.WorkOrderId);
        });

        modelBuilder.Entity<Repair>(entity =>
        {
            entity
            .HasOne(repair => repair.WorkOrder)
            .WithMany(workOrder => workOrder.Repairs);
        });

        modelBuilder.Entity<Technician>(entity =>
        {
            // entity
            // .HasMany(technician => technician.Invoices)
            // .WithMany(invoice => invoice.Technicians);

            entity
            .HasMany(technician => technician.WorkOrders)
            .WithMany(workOrder => workOrder.Technicians);
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity
            .HasMany(vehicle => vehicle.Invoices)
            .WithOne(invoice => invoice.Vehicle);

            entity
            .HasMany(vehicle => vehicle.WorkOrders)
            .WithOne(workOrder => workOrder.Vehicle);
        });

        modelBuilder.Entity<WorkOrder>(entity =>
        {
            entity
            .HasOne(workOrder => workOrder.Customer)
            .WithMany(customer => customer.WordkOrders)
            .HasForeignKey(workOrder => workOrder.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

            entity
            .HasOne(workOrder => workOrder.Vehicle)
            .WithMany(vehicle => vehicle.WorkOrders)
            .HasForeignKey(invoice => invoice.VIN)
            .OnDelete(DeleteBehavior.Restrict);

            entity
            .HasMany(workOrder => workOrder.Technicians)
            .WithMany(technician => technician.WorkOrders);

            entity
            .HasMany(workOrder => workOrder.Repairs)
            .WithOne(repair => repair.WorkOrder);

            entity
            .HasOne(workOrder => workOrder.Invoice)
            .WithOne(invoice => invoice.WorkOrder)
            .HasForeignKey<WorkOrder>(workOrder => workOrder.InvoiceId);
        });

        /*Invoice invoice = new Invoice
        {
            InvoiceId = 1,
            CustomerId = 1,
            VIN = "ABCDE123456789012",
          //  RepairDate = DateTime.Now
        };
        List<Invoice> invoices = new();
        invoices.Add(invoice);
        
        modelBuilder.Entity<Customer>()
        .HasData(
            new Customer
            {
                CustomerId = 1,
                CustomerName = "John Smith",
                Phone = "123-456-7890",
                Address = "123 Main St. Los Angeles, 12345",
                Email = "john.smith@example.com",
                //Invoices = invoices
            }
        );

        modelBuilder.Entity<Invoice>()
        .HasData(invoice);

        modelBuilder.Entity<Technician>()
        .HasData(
            new Technician
            {
                TechnicianId = 1,
                Name = "Jimmy the Tech",
               // Invoices = invoices
            }
        );


        modelBuilder.Entity<Vehicle>()
        .HasData(
            new Vehicle
            {
                VIN = "ABCDE123456789012",
                Make = "Honda",
                Model = "Civic",
                Body =  "Sedan",
                Color = "Red",
                Year = 2021,
                Mileage = 51520,
                Invoices = []
            }
        );*/
    }
}