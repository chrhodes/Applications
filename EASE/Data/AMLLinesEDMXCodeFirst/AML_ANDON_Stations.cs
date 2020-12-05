namespace AMLLinesEDMXCodeFirst
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class AML_ANDON_Stations
    {
        [Key]
        [Column(Order = 0)]
        public decimal LINEID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(12)]
        public string STATIONNO { get; set; }

        public decimal TIMESECONDS { get; set; }

        public DateTime LASTUPDATED { get; set; }

        public int? READSTATUS { get; set; }

        public int? LINESTATUS { get; set; }
    }
}
