namespace AMLVehicle
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AML_VehicleOrders
    {
        [StringLength(8)]
        public string OrderNumber { get; set; }

        [Key]
        public decimal BuildNumber { get; set; }

        [StringLength(30)]
        public string VinNumber { get; set; }

        public decimal? YearX { get; set; }

        [StringLength(8)]
        public string Model { get; set; }

        [StringLength(60)]
        public string DescriptionX { get; set; }

        public decimal? Model1 { get; set; }

        [StringLength(1)]
        public string Drive1 { get; set; }

        [StringLength(4)]
        public string Territory1 { get; set; }

        [StringLength(1)]
        public string Body { get; set; }

        [StringLength(1)]
        public string GearBox1 { get; set; }

        [StringLength(1)]
        public string Performance1 { get; set; }

        [StringLength(1)]
        public string Plant { get; set; }

        public decimal? TubNumber { get; set; }

        public decimal? CurrentStation { get; set; }

        [StringLength(4)]
        public string ModelYear { get; set; }
    }
}
