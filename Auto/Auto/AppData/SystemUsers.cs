namespace Auto.AppData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SystemUsers
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Login { get; set; }

        [StringLength(50)]
        public string Role { get; set; }

        public int? IdProdavets { get; set; }

        public virtual Prodavets Prodavets { get; set; }
    }
}
