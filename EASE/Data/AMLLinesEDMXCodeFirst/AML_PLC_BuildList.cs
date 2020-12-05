namespace AMLLinesEDMXCodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AML_PLC_BuildList
    {
        public decimal LineID { get; set; }

        [Key]
        [StringLength(10)]
        public string BuildNo { get; set; }

        public DateTime LastUpdated { get; set; }

        public decimal? EASERead { get; set; }
    }
}
