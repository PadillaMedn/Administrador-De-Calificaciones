namespace Base_Notas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class alumnos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public alumnos()
        {
            notas = new HashSet<notas>();
        }

        public int id { get; set; }

        [StringLength(50)]
        [Required]
        public string Nombre { get; set; }

        [StringLength(50)]
        [Required]
        public string Apellido { get; set; }

        public int? Edad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<notas> notas { get; set; }
    }
}
