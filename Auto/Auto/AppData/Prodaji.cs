namespace Auto.AppData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Prodaji")]
    public partial class Prodaji
    {
        [Key]
        [StringLength(9)]
        public string CarNum { get; set; }

        public int Seller { get; set; }

        [Column(TypeName = "date")]
        public DateTime? SeleDate { get; set; }

        public int? Buyer { get; set; }

        public virtual har_avto har_avto { get; set; }

        public virtual Pokupatel Pokupatel { get; set; }

        public virtual Prodavets Prodavets { get; set; }
    }
}
