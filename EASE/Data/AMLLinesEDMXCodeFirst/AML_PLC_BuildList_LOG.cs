namespace AMLLinesEDMXCodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AML_PLC_BuildList_LOG
    {
        [Key]
        [StringLength(10)]
        public string BuildNo { get; set; }

        public DateTime CompleteTime { get; set; }

        [StringLength(255)]
        public string LogDescription { get; set; }
    }
}
