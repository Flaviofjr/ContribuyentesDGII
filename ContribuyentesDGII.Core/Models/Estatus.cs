
namespace ContribuyentesDGII.Core.Models
{
    public class Estatus : EntidadBase
    {
        public Estatus()
        {
            Contribuyentes = new HashSet<Contribuyente>();
        }
        public short IdEstatus { get; set; }
        [Required(ErrorMessage ="Debe ingresar una descripcion de estado")]
        [MaxLength(50,ErrorMessage ="La descripción del estatus no puede tener mas de 50 caracteres")]
        public string Descripcion { get; set; }
        [JsonIgnore]
        public virtual ICollection<Contribuyente> Contribuyentes { get; set; }
    }
}
