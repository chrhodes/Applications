namespace AMLLinesEDMXCodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AML_Andon_IndexLog
    {
        [Key]
        [Column(TypeName = "numeric")]
        public decimal Keyx { get; set; }

        public DateTime? Datex { get; set; }

        public decimal LineID { get; set; }

        [StringLength(12)]
        public string StationNO { get; set; }

        [StringLength(20)]
        public string Spare1 { get; set; }

        [StringLength(20)]
        public string Spare2 { get; set; }

        [StringLength(20)]
        public string Spare3 { get; set; }
    }
}
