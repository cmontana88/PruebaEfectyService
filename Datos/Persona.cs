using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    [Table("Persona")]
    public partial class Persona
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Nombres { get; set; }

        [StringLength(50)]
        public string Apellidos { get; set; }

        public int? TipoDocumento { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public decimal? ValoraGanar { get; set; }

        public bool? EstadoCivil { get; set; }

        public virtual TipoDocumento TipoDocumento1 { get; set; }
    }
}
