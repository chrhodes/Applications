namespace AMLLinesEDMXCodeFirst
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AMLLinesCF : DbContext
    {
        public AMLLinesCF()
            : base("name=AMLLinesCF")
        {
        }

        public virtual DbSet<AML_Andon> AML_Andon { get; set; }
        public virtual DbSet<AML_Andon_IndexLog> AML_Andon_IndexLog { get; set; }
        public virtual DbSet<AML_ANDON_Stations> AML_ANDON_Stations { get; set; }
        public virtual DbSet<AML_LineStatus> AML_LineStatus { get; set; }
        public virtual DbSet<AML_PLC_BuildList> AML_PLC_BuildList { get; set; }
        public virtual DbSet<AML_PLC_BuildList_LOG> AML_PLC_BuildList_LOG { get; set; }
        public virtual DbSet<AML_PLCStatus> AML_PLCStatus { get; set; }
        public virtual DbSet<LINE> LINES { get; set; }
        public virtual DbSet<STATION> STATIONS { get; set; }
        public virtual DbSet<AML_LINESTATUS_BODYSHOP> AML_LINESTATUS_BODYSHOP { get; set; }

        // These are database attributes that are different than EF CodeFirst conventions

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AML_Andon>()
                .Property(e => e.LineID)
                .HasPrecision(4, 0);

            modelBuilder.Entity<AML_Andon>()
                .Property(e => e.TimeSeconds)
                .HasPrecision(6, 0);

            modelBuilder.Entity<AML_Andon>()
                .Property(e => e.LineStatus)
                .HasPrecision(1, 0);

            modelBuilder.Entity<AML_Andon>()
                .Property(e => e.ReadStatus)
                .HasPrecision(1, 0);

            modelBuilder.Entity<AML_Andon_IndexLog>()
                .Property(e => e.Keyx)
                .HasPrecision(9, 0);

            modelBuilder.Entity<AML_Andon_IndexLog>()
                .Property(e => e.LineID)
                .HasPrecision(4, 0);

            modelBuilder.Entity<AML_Andon_IndexLog>()
                .Property(e => e.StationNO)
                .IsUnicode(false);

            modelBuilder.Entity<AML_Andon_IndexLog>()
                .Property(e => e.Spare1)
                .IsUnicode(false);

            modelBuilder.Entity<AML_Andon_IndexLog>()
                .Property(e => e.Spare2)
                .IsUnicode(false);

            modelBuilder.Entity<AML_Andon_IndexLog>()
                .Property(e => e.Spare3)
                .IsUnicode(false);

            modelBuilder.Entity<AML_ANDON_Stations>()
                .Property(e => e.LINEID)
                .HasPrecision(4, 0);

            modelBuilder.Entity<AML_ANDON_Stations>()
                .Property(e => e.STATIONNO)
                .IsUnicode(false);

            modelBuilder.Entity<AML_ANDON_Stations>()
                .Property(e => e.TIMESECONDS)
                .HasPrecision(6, 0);

            modelBuilder.Entity<AML_LineStatus>()
                .Property(e => e.LineID)
                .HasPrecision(4, 0);

            modelBuilder.Entity<AML_LineStatus>()
                .Property(e => e.StationNO)
                .IsUnicode(false);

            modelBuilder.Entity<AML_LineStatus>()
                .Property(e => e.BuildNo)
                .IsUnicode(false);

            modelBuilder.Entity<AML_LineStatus>()
                .Property(e => e.IPCStatus)
                .HasPrecision(1, 0);

            modelBuilder.Entity<AML_LineStatus>()
                .Property(e => e.AndonCALL)
                .HasPrecision(1, 0);

            modelBuilder.Entity<AML_PLC_BuildList>()
                .Property(e => e.LineID)
                .HasPrecision(4, 0);

            modelBuilder.Entity<AML_PLC_BuildList>()
                .Property(e => e.BuildNo)
                .IsUnicode(false);

            modelBuilder.Entity<AML_PLC_BuildList>()
                .Property(e => e.EASERead)
                .HasPrecision(1, 0);

            modelBuilder.Entity<AML_PLC_BuildList_LOG>()
                .Property(e => e.BuildNo)
                .IsUnicode(false);

            modelBuilder.Entity<AML_PLC_BuildList_LOG>()
                .Property(e => e.LogDescription)
                .IsUnicode(false);

            modelBuilder.Entity<AML_PLCStatus>()
                .Property(e => e.StationNo)
                .IsFixedLength();

            modelBuilder.Entity<LINE>()
                .Property(e => e.LINEID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<LINE>()
                .Property(e => e.DESCRIPTION)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LINE>()
                .Property(e => e.PlantID)
                .HasPrecision(5, 0);

            modelBuilder.Entity<LINE>()
                .Property(e => e.LINECODE)
                .IsUnicode(false);

            modelBuilder.Entity<STATION>()
                .Property(e => e.LINEID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<STATION>()
                .Property(e => e.ABSNNO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<STATION>()
                .Property(e => e.ABSNDESC)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<STATION>()
                .Property(e => e.ABSNSTART)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<STATION>()
                .Property(e => e.ABSNEND)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<STATION>()
                .Property(e => e.Operators)
                .HasPrecision(5, 0);

            modelBuilder.Entity<STATION>()
                .Property(e => e.OSMREQUIRED)
                .HasPrecision(1, 0);

            modelBuilder.Entity<AML_LINESTATUS_BODYSHOP>()
                .Property(e => e.LINEID)
                .HasPrecision(4, 0);

            modelBuilder.Entity<AML_LINESTATUS_BODYSHOP>()
                .Property(e => e.STATIONNO)
                .IsUnicode(false);

            modelBuilder.Entity<AML_LINESTATUS_BODYSHOP>()
                .Property(e => e.BUILDNO)
                .HasPrecision(6, 0);

            modelBuilder.Entity<AML_LINESTATUS_BODYSHOP>()
                .Property(e => e.IPCSTATUS)
                .HasPrecision(1, 0);

            modelBuilder.Entity<AML_LINESTATUS_BODYSHOP>()
                .Property(e => e.ANDONCALL)
                .HasPrecision(1, 0);

            modelBuilder.Entity<AML_LINESTATUS_BODYSHOP>()
                .Property(e => e.PLATTENID)
                .HasPrecision(4, 0);

            modelBuilder.Entity<AML_LINESTATUS_BODYSHOP>()
                .Property(e => e.TAKTTIMESECONDS)
                .HasPrecision(4, 0);
        }
    }
}
