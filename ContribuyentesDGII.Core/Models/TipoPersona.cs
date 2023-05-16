
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
        public string? DescripcionPersona { get; set; }
        [JsonIgnore]
        public virtual ICollection<Contribuyente> Contribuyentes { get; set; }
    }
}
