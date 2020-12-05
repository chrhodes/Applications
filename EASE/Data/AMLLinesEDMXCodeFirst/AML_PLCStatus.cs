namespace AMLLinesEDMXCodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AML_PLCStatus
    {
        public int? LineID { get; set; }

        [Key]
        [StringLength(12)]
        public string StationNo { get; set; }

        public int? AndonCall { get; set; }

        public int? ReadStatus { get; set; }

        public DateTime? LastUpdated { get; set; }
    }
}
