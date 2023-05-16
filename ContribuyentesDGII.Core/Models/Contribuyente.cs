
namespace ContribuyentesDGII.Core.Models
{
    public class Contribuyente : EntidadBase
    {
        public Contribuyente()
        {
            Comprobantes = new HashSet<ComprobanteFiscal>();
        }
        [Required(ErrorMessage = "Debe de ingresar un número de cédula o RNC")]
        [MaxLength(11, ErrorMessage = "La cedula o RNC no pueden tener mas de 11 dígitos")]
        public string? RncCedula { get; set; }
        //public int IdCedulation { get; set; }
        [Required(ErrorMessage = "Es obligatorio el nombre del contribuyente")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El campo del tipo de persona es requerido")]
        public short IdTipoPersona { get; set; }
        [Required(ErrorMessage = "El campo del estatus es requerido")]
        public short IdEstatus { get; set; }
        public virtual TipoPersona? Tipo { get; set; }
        public virtual Estatus? Estatus { get; set; }
        public virtual ICollection<ComprobanteFiscal> Comprobantes { get; set; }
    }
}
