namespace AMLVehicle
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AML_VehicleTrim
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string OrderNumber { get; set; }

        [Key]
        [Column(Order = 1)]
        public decimal BuildNumber { get; set; }

        [StringLength(10)]
        public string Environment { get; set; }

        [StringLength(50)]
        public string DescriptionX { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(4)]
        public string OptionCode1 { get; set; }

        [StringLength(50)]
        public string OptionDescription { get; set; }
    }
}
