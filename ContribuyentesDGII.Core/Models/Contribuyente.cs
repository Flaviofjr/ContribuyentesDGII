
namespace ContribuyentesDGII.Core.Models
{
    public class Contribuyente : EntidadBase
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Contribuyente()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            Comprobantes = new HashSet<ComprobanteFiscal>();
        }
        [Required(ErrorMessage = "Debe de ingresar un número de cédula o RNC")]
        public string RncCedula { get; set; }
        [Required(ErrorMessage = "Es obligatorio el nombre del contribuyente")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo del tipo de persona es requerido")]
        public short IdTipoPersona { get; set; }
        [Required(ErrorMessage = "El campo del estatus es requerido")]
        public short IdEstatus { get; set; }
        public virtual TipoPersona Tipo { get; set; }
        public virtual Estatus Estatus { get; set; }
        public virtual ICollection<ComprobanteFiscal> Comprobantes { get; set; }
    }
}
