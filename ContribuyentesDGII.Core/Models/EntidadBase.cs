
namespace ContribuyentesDGII.Core.Models
{
    public class EntidadBase
    {
        [JsonIgnore]
        public DateTime FechaCreacion { get; set; }
        [JsonIgnore]
        public DateTime UltimaFechaModificacion { get; set; }
    }
}
