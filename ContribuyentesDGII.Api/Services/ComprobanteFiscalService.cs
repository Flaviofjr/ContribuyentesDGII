namespace ContribuyentesDGII.Api.Services
{
    public interface IComprobanteFiscalService
    {
        Task<IEnumerable<ComprobanteFiscal>> GetComprobantes();
        Task<ComprobanteFiscal?> GetComprobante(string ncf);
        Task<ComprobanteFiscal> AddComprobante(ComprobanteFiscal comprobante);
        Task<ComprobanteFiscal?> UpdateComprobante(string ncf, ComprobanteFiscal comprobante);
        Task<bool> DeleteComprobante(string ncf);
    }
    public class ComprobanteFiscalService : IComprobanteFiscalService
    {
        private readonly IComprobanteFiscalRepository _comprobanteRepository;
        public ComprobanteFiscalService(IComprobanteFiscalRepository comprobanteRepository)
        {
            _comprobanteRepository = comprobanteRepository;
        }
        public async Task<ComprobanteFiscal> AddComprobante(ComprobanteFiscal comprobante)
        {
            var newComprobante = await _comprobanteRepository.AddComprobante(comprobante);
            return newComprobante;
        }

        public async Task<bool> DeleteComprobante(string ncf)
        {
            return await _comprobanteRepository.DeleteComprobante(ncf);
        }

        public async Task<ComprobanteFiscal?> GetComprobante(string ncf)
        {
            return await _comprobanteRepository.GetComprobante(ncf);
        }

        public async Task<IEnumerable<ComprobanteFiscal>> GetComprobantes()
        {
            return await _comprobanteRepository.GetComprobantes();
        }

        public async Task<ComprobanteFiscal?> UpdateComprobante(string ncf, ComprobanteFiscal comprobante)
        {
            var updatedComprobante = await _comprobanteRepository.UpdateComprobante(ncf, comprobante);
            return updatedComprobante;
        }
    }
}
