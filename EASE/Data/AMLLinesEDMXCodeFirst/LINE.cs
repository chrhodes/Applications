namespace AMLLinesEDMXCodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LINES")]
    public partial class LINE
    {
        [Column(TypeName = "numeric")]
        public decimal LINEID { get; set; }

        [StringLength(80)]
        public string DESCRIPTION { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PlantID { get; set; }

        [StringLength(30)]
        public string LINECODE { get; set; }
    }
}
