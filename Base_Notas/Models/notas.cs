namespace Base_Notas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class notas
    {
        public int id { get; set; }
        [Required]
        public decimal? nota { get; set; }

        [StringLength(100)]
        [Required]
        public string descripcion { get; set; }
    
        public int? id_materia { get; set; }
    
        public int? id_alum { get; set; }
       
        public int? id_prof { get; set; }

        public virtual alumnos alumnos { get; set; }

        public virtual Materias Materias { get; set; }

        public virtual Profesores Profesores { get; set; }
    }
}
