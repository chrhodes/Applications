namespace AMLVehicle
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AML_VehicleOptions
    {
        [StringLength(8)]
        public string OrderNumber { get; set; }

        [Key]
        [Column(Order = 0)]
        public decimal BuildNumber { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string OptionCode1 { get; set; }

        [StringLength(50)]
        public string OptionDescription { get; set; }
    }
}
