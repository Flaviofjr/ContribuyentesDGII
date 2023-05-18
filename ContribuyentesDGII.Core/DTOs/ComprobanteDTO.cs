using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using AutoMapper;

namespace ContribuyentesDGII.Core.DTOs
{
    public class ComprobanteDTO
    {
        [Required(ErrorMessage = "Debe introducir un numero de RNC o Cédula para asociarla al comprobante fiscal.")]
        public string? RncCedula { get; set; }
        [Required(ErrorMessage = "Debe introducir un numero de comprobante fiscal único.")]
        public string? NCF { get; set; }
        [Required(ErrorMessage = "Debe introducir un monto.")]
        public decimal Monto{ get;set;}
    }
}
