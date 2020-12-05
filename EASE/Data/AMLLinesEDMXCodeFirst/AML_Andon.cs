namespace AMLLinesEDMXCodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AML_Andon
    {
        [Key]
        public decimal LineID { get; set; }

        public decimal TimeSeconds { get; set; }

        public decimal LineStatus { get; set; }

        public DateTime LastUpdated { get; set; }

        public decimal? ReadStatus { get; set; }
    }
}
