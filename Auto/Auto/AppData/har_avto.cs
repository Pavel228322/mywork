namespace Auto.AppData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class har_avto
    {
        public decimal? Price { get; set; }

        public int? Mileage { get; set; }

        [Key]
        [StringLength(9)]
        public string CarNum { get; set; }

        [StringLength(50)]
        public string Firm { get; set; }

        [StringLength(50)]
        public string Model { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        [StringLength(10)]
        public string Country { get; set; }

        public int? Year { get; set; }

        public decimal? EngineVolume { get; set; }

        public int? Power { get; set; }

        [StringLength(50)]
        public string FuelType { get; set; }

        public string Description { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public virtual Prodaji Prodaji { get; set; }
    }
}
