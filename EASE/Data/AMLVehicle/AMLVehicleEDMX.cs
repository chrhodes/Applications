namespace AMLVehicle
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AMLVehicleEDMX : DbContext
    {
        public AMLVehicleEDMX()
            : base("name=AMLVehicleEDMX")
        {
        }

        public virtual DbSet<AML_VehicleOptions> AML_VehicleOptions { get; set; }
        public virtual DbSet<AML_VehicleOrders> AML_VehicleOrders { get; set; }
        public virtual DbSet<AML_VehicleTrim> AML_VehicleTrim { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AML_VehicleOptions>()
                .Property(e => e.OrderNumber)
                .IsUnicode(false);

            modelBuilder.Entity<AML_VehicleOptions>()
                .Property(e => e.BuildNumber)
                .HasPrecision(6, 0);

            modelBuilder.Entity<AML_VehicleOptions>()
                .Property(e => e.OptionCode1)
                .IsUnicode(false);

            modelBuilder.Entity<AML_VehicleOptions>()
                .Property(e => e.OptionDescription)
                .IsUnicode(false);

            modelBuilder.Entity<AML_VehicleOrders>()
                .Property(e => e.OrderNumber)
                .IsUnicode(false);

            modelBuilder.Entity<AML_VehicleOrders>()
                .Property(e => e.BuildNumber)
                .HasPrecision(6, 0);

            modelBuilder.Entity<AML_VehicleOrders>()
                .Property(e => e.VinNumber)
                .IsUnicode(false);

            modelBuilder.Entity<AML_VehicleOrders>()
                .Property(e => e.YearX)
                .HasPrecision(4, 0);

            modelBuilder.Entity<AML_VehicleOrders>()
                .Property(e => e.Model)
                .IsUnicode(false);

            modelBuilder.Entity<AML_VehicleOrders>()
                .Property(e => e.DescriptionX)
                .IsUnicode(false);

            modelBuilder.Entity<AML_VehicleOrders>()
                .Property(e => e.Model1)
                .HasPrecision(3, 0);

            modelBuilder.Entity<AML_VehicleOrders>()
                .Property(e => e.Drive1)
                .IsUnicode(false);

            modelBuilder.Entity<AML_VehicleOrders>()
                .Property(e => e.Territory1)
                .IsUnicode(false);

            modelBuilder.Entity<AML_VehicleOrders>()
                .Property(e => e.Body)
                .IsUnicode(false);

            modelBuilder.Entity<AML_VehicleOrders>()
                .Property(e => e.GearBox1)
                .IsUnicode(false);

            modelBuilder.Entity<AML_VehicleOrders>()
                .Property(e => e.Performance1)
                .IsUnicode(false);

            modelBuilder.Entity<AML_VehicleOrders>()
                .Property(e => e.Plant)
                .IsUnicode(false);

            modelBuilder.Entity<AML_VehicleOrders>()
                .Property(e => e.TubNumber)
                .HasPrecision(5, 0);

            modelBuilder.Entity<AML_VehicleOrders>()
                .Property(e => e.CurrentStation)
                .HasPrecision(3, 0);

            modelBuilder.Entity<AML_VehicleOrders>()
                .Property(e => e.ModelYear)
                .IsUnicode(false);

            modelBuilder.Entity<AML_VehicleTrim>()
                .Property(e => e.OrderNumber)
                .IsUnicode(false);

            modelBuilder.Entity<AML_VehicleTrim>()
                .Property(e => e.BuildNumber)
                .HasPrecision(6, 0);

            modelBuilder.Entity<AML_VehicleTrim>()
                .Property(e => e.Environment)
                .IsUnicode(false);

            modelBuilder.Entity<AML_VehicleTrim>()
                .Property(e => e.DescriptionX)
                .IsUnicode(false);

            modelBuilder.Entity<AML_VehicleTrim>()
                .Property(e => e.OptionCode1)
                .IsUnicode(false);

            modelBuilder.Entity<AML_VehicleTrim>()
                .Property(e => e.OptionDescription)
                .IsUnicode(false);
        }
    }
}
