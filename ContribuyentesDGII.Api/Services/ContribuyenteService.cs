namespace ContribuyentesDGII.Api.Services
{
    public interface IContribuyenteService
    {
        Task<IEnumerable<ContribuyenteDTO>> GetContribuyentes();
        Task<Contribuyente?> GetContribuyente(string rncCedula);
        Task<Contribuyente> AddContribuyente(Contribuyente contribuyente);
        Task<Contribuyente?> UpdateContribuyente(string rncCedula, Contribuyente contribuyente);
        Task<bool> DeleteContribuyente(string rncCedula);
        bool RncCedulaExists(string? rncCedula);
    }
    public class ContribuyenteService : IContribuyenteService
    {
        private readonly IContribuyenteRepository _contribuyenteRepository;
        public ContribuyenteService(IContribuyenteRepository contribuyenteRepository)
        {
            _contribuyenteRepository = contribuyenteRepository;
        }
        public async Task<IEnumerable<ContribuyenteDTO>> GetContribuyentes()
        {
            return await _contribuyenteRepository.GetContribuyentes();
        }
        public async Task<Contribuyente?> GetContribuyente(string rncCedula)
        {
            return await _contribuyenteRepository.GetContribuyente(rncCedula);
        }

        public async Task<Contribuyente> AddContribuyente(Contribuyente contribuyente)
        {
            var newContribuyente = await _contribuyenteRepository.AddContribuyente(contribuyente);
            return newContribuyente;
        }

        public async Task<Contribuyente?> UpdateContribuyente(string rncCedula, Contribuyente contribuyente)
        {
            var updatedContribuyente = await _contribuyenteRepository.UpdateContribuyente(rncCedula, contribuyente);
            return updatedContribuyente;
        }
        public async Task<bool> DeleteContribuyente(string rncCedula)
        {
            return await _contribuyenteRepository.DeleteContribuyente(rncCedula);
        }
        public bool RncCedulaExists(string? rncCedula)
        {
            return _contribuyenteRepository.RncCedulaExists(rncCedula);
        }
    }
}
