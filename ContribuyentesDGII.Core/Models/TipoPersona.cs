using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContribuyentesDGII.Core.Models
{
    public class TipoPersona : EntidadBase
    {
        public TipoPersona()
        {
            Contribuyentes = new HashSet<Contribuyente>();
        }
        public short IdTipoPersona { get; set; }
        [Required]
        [MaxLength(150, ErrorMessage = "La descripción del tipo de persona no puede tener mas de 150 caracteres")]
        public string DescripcionPersona { get; set; }
        public virtual ICollection<Contribuyente> Contribuyentes { get; set; }
    }
}
