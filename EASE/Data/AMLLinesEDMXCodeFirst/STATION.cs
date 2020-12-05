namespace AMLLinesEDMXCodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("STATIONS")]
    public partial class STATION
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal LINEID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string ABSNNO { get; set; }

        [StringLength(80)]
        public string ABSNDESC { get; set; }

        [StringLength(10)]
        public string ABSNSTART { get; set; }

        [StringLength(10)]
        public string ABSNEND { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Operators { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? OSMREQUIRED { get; set; }

        public bool? PARTPROCESS { get; set; }

        public bool? DOCVIEWFIRST { get; set; }
    }
}
