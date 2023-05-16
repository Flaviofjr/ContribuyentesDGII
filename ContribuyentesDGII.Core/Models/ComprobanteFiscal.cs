
namespace ContribuyentesDGII.Core.Models
{
    public class ComprobanteFiscal : EntidadBase
    {
        private decimal _monto;
        //public int IdCedulation { get; set; }
        [Required(ErrorMessage = "Debe introducir un numero de RNC o Cédula para asociarla al comprobante fiscal.")]
        public string? RncCedula { get; set; }
        [Required]
        public string? NCF { get; set; }
        public decimal Monto {
            get => _monto;
            set
            {
                if (value > 0)
                {
                    _monto = value;
                    Itbis18 = _monto * 0.18m; // Calcular el valor del Itbis cuando Monto es agregado
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "El monto debe ser mayor que cero.");
                }
            }
        }
        public decimal Itbis18 { get ; private set;}
        [JsonIgnore]
        public virtual Contribuyente? Contribuyente { get; set; }
    }
}
