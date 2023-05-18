

namespace ContribuyentesDGII.Core
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ComprobanteFiscal, ComprobanteDTO>().ReverseMap();
        }
    }
}
