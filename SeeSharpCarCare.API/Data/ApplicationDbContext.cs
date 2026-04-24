
using Microsoft.EntityFrameworkCore;
using SeeSharpCarCare.API.Models;

namespace SeeSharpCarCare.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() : base() { }
    public ApplicationDbContext(DbContextOptions options) : base(options) { }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Repair> Repairs { get; set; }
    public DbSet<Technician> Technicians { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<WorkOrder> WorkOrders { get; set; }
    public DbSet<RepairCode> RepairCodes { get; set; }
    public DbSet<TechnicianWorkOrder> TechnicianWorkOrders { get; set; }

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
            .WithMany(workOrder => workOrder.Repairs)
            .HasForeignKey(repair => repair.WorkOrderId);
        });

        modelBuilder.Entity<Technician>(entity =>
        {
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
            .WithMany(technician => technician.WorkOrders)
            .UsingEntity<TechnicianWorkOrder>();

            entity
            .HasMany(workOrder => workOrder.Repairs)
            .WithOne(repair => repair.WorkOrder);

            entity
            .HasOne(workOrder => workOrder.Invoice)
            .WithOne(invoice => invoice.WorkOrder)
            .HasForeignKey<WorkOrder>(workOrder => workOrder.InvoiceId);
        });

        modelBuilder.Entity<RepairCode>()
        .HasData(
            new RepairCode { Id = "AC", RepairName = "Air Conditioning" },
            new RepairCode { Id = "BB", RepairName = "Brake Bleeding" },
            new RepairCode { Id = "BP", RepairName = "Brake Pads" },
            new RepairCode { Id = "BT", RepairName = "Battery Testing" },
            new RepairCode { Id = "BR", RepairName = "Battery Replacement" },
            new RepairCode { Id = "CL", RepairName = "Clutch" },
            new RepairCode { Id = "CR", RepairName = "Coolant Flush" },
            new RepairCode { Id = "CS", RepairName = "Charging System" },
            new RepairCode { Id = "CW", RepairName = "Car Wash" },
            new RepairCode { Id = "ECM", RepairName = "Engine Control Module" },
            new RepairCode { Id = "ES", RepairName = "Engine Swap" },
            new RepairCode { Id = "EM", RepairName = "Electric Motor" },
            new RepairCode { Id = "FP", RepairName = "Fuel Pump" },
            new RepairCode { Id = "HB", RepairName = "Hybrid System" },
            new RepairCode { Id = "HR", RepairName = "Head Lights" },
            new RepairCode { Id = "OC", RepairName = "Oil Change" },
            new RepairCode { Id = "SP", RepairName = "Spark Plugs" },
            new RepairCode { Id = "SS", RepairName = "Suspension System" },
            new RepairCode { Id = "ST", RepairName = "Steering System" },
            new RepairCode { Id = "TF", RepairName = "Transmission Fluid" },
            new RepairCode { Id = "TR", RepairName = "Tire Rotation" },
            new RepairCode { Id = "TRN", RepairName = "Tire Replacement (New)" },
            new RepairCode { Id = "TRU", RepairName = "Tire Replacement (Used)" },
            new RepairCode { Id = "TS", RepairName = "Transmission Service" },
            new RepairCode { Id = "WA", RepairName = "Wheel Alignment" },
            new RepairCode { Id = "WB", RepairName = "Wheel Balancing" }
        );

    }
}