namespace Auto.AppData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Prodavets
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Prodavets()
        {
            Prodaji = new HashSet<Prodaji>();
            SystemUsers = new HashSet<SystemUsers>();
        }

        [Key]
        public int idprodavets { get; set; }

        [StringLength(45)]
        public string FullName { get; set; }

        [StringLength(45)]
        public string Phone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prodaji> Prodaji { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SystemUsers> SystemUsers { get; set; }
    }
}
