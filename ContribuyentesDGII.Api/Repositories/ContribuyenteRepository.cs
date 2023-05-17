

namespace ContribuyentesDGII.Api.Repositories
{
    public interface IContribuyenteRepository
    {
        Task<IEnumerable<ContribuyenteDTO>> GetContribuyentes();
        Task<Contribuyente?> GetContribuyente(string rncCedula);
        Task<Contribuyente> AddContribuyente(Contribuyente contribuyente);
        Task<Contribuyente?> UpdateContribuyente(string rnCedula, Contribuyente contribuyente);
        Task<bool> DeleteContribuyente(string rncCedula);
        bool RncCedulaExists(string? rncCedula);
    }
    public class ContribuyenteRepository : IContribuyenteRepository
    {
        private readonly ContribuyentesDbContext _contribuyentesDbContext;
        public ContribuyenteRepository(ContribuyentesDbContext contribuyentesDbContext)
        {
            _contribuyentesDbContext = contribuyentesDbContext;
        }
        public async Task<IEnumerable<ContribuyenteDTO>> GetContribuyentes()
        {
            var contrs = await _contribuyentesDbContext.Contribuyentes
                .Include(t => t.Tipo)
                .Include(e => e.Estatus)
                .ToListAsync();
            List<ContribuyenteDTO> contribuyentes = new();
            foreach (var item in contrs)
            {
                var c = new ContribuyenteDTO
                {
                    RncCedula = item.RncCedula,
                    Nombre = item.Nombre,
                    Tipo = item.Tipo?.DescripcionPersona,
                    Estatus = item.Estatus?.Descripcion
                };
                contribuyentes.Add(c);
            }
            return contribuyentes.ToList();
        }

        public async Task<Contribuyente?> GetContribuyente(string rncCedula)
        {
            var contribuyente = await _contribuyentesDbContext.Contribuyentes
                .Include(e => e.Estatus)
                .Include(t => t.Tipo)
                .Include(c => c.Comprobantes)
                .FirstOrDefaultAsync(r => r.RncCedula == rncCedula);
            if (contribuyente == null)
            {
                return null;
            }
            return contribuyente;
        }

        public async Task<Contribuyente> AddContribuyente(Contribuyente contribuyente)
        {
            var result = _contribuyentesDbContext.Contribuyentes.Add(contribuyente);
            _contribuyentesDbContext.SaveChanges();
            return result.Entity;
        }
        public async Task<Contribuyente?> UpdateContribuyente(string rncCedula, Contribuyente contribuyente)
        {
            var existingContribuyente = await _contribuyentesDbContext.Set<Contribuyente>().FindAsync(rncCedula);
            if (existingContribuyente == null)
            {
                return null;
            }
            _contribuyentesDbContext.Entry(existingContribuyente).CurrentValues.SetValues(contribuyente);
            _contribuyentesDbContext.SaveChanges();
            return existingContribuyente;
        }

        public async Task<bool> DeleteContribuyente(string rncCedula)
        {
            var contribuyente = await _contribuyentesDbContext.Set<Contribuyente>().FindAsync(rncCedula);
            if (contribuyente == null)
            {
                return false;
            }
            _contribuyentesDbContext.Set<Contribuyente>().Remove(contribuyente);
            _contribuyentesDbContext.SaveChanges();
            return true;
        }
        public bool RncCedulaExists(string? rncCedula)
        {
            return _contribuyentesDbContext.Contribuyentes.Any(n => n.RncCedula == rncCedula);
        }
    }
}
