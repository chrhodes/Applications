namespace AMLLinesEDMXCodeFirst
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class AML_LineStatus
    {
        [Key]
        [Column(Order = 0)]
        public decimal LineID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(12)]
        public string StationNO { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string BuildNo { get; set; }

        public DateTime? EngineMoveDate { get; set; }

        public decimal? IPCStatus { get; set; }

        public decimal? AndonCALL { get; set; }

        public int? ReadStatus { get; set; }
    }
}
