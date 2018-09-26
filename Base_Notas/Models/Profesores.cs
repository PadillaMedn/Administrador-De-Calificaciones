namespace Base_Notas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Profesores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Profesores()
        {
            notas = new HashSet<notas>();
        }
        [Key]
        public int id { get; set; }

        [StringLength(50)]
        [Required]
        public string Nombre { get; set; }

        [StringLength(50)]
        [Required]
        public string Apellido { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<notas> notas { get; set; }
    }
}
