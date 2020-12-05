namespace AMLLinesEDMXCodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AML_LINESTATUS_BODYSHOP
    {
        [Key]
        [Column(Order = 0)]
        public decimal LINEID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(12)]
        public string STATIONNO { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal BUILDNO { get; set; }

        public DateTime? ENGINEMOVEDATE { get; set; }

        public decimal? IPCSTATUS { get; set; }

        public decimal? ANDONCALL { get; set; }

        public int? READSTATUS { get; set; }

        public decimal? PLATTENID { get; set; }

        public decimal? TAKTTIMESECONDS { get; set; }
    }
}
