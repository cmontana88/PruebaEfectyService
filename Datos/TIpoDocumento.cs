using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{

    [Table("TipoDocumento")]
    public partial class TipoDocumento
    {
        public TipoDocumento()
        {
            Persona = new HashSet<Persona>();
        }

        public int Id { get; set; }

        [StringLength(20)]
        public string Valor { get; set; }

        public virtual ICollection<Persona> Persona { get; set; }
    }
}
