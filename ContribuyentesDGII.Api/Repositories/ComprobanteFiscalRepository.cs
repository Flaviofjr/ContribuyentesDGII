namespace ContribuyentesDGII.Api.Repositories
{
    public interface IComprobanteFiscalRepository
    {
        Task<IEnumerable<ComprobanteFiscal>> GetComprobantes();
        Task<ComprobanteFiscal?> GetComprobante(string ncf);
        Task<ComprobanteFiscal> AddComprobante(ComprobanteFiscal comprobante);
        Task<ComprobanteFiscal?> UpdateComprobante(string ncf, ComprobanteFiscal comprobante);
        Task<bool> DeleteComprobante(string ncf);
    }
    public class ComprobanteFiscalRepository : IComprobanteFiscalRepository
    {
        private readonly ContribuyentesDbContext _contribuyentesDbContext;
        public ComprobanteFiscalRepository(ContribuyentesDbContext contribuyentesDbContext)
        {
            _contribuyentesDbContext = contribuyentesDbContext;
        }
        public async Task<IEnumerable<ComprobanteFiscal>> GetComprobantes()
        {
            return await _contribuyentesDbContext.ComprobantesFiscales.ToListAsync();
        }
        public async Task<ComprobanteFiscal?> GetComprobante(string ncf)
        {
            var comprobante = await _contribuyentesDbContext.ComprobantesFiscales
                .FirstOrDefaultAsync(r => r.NCF == ncf);
            if (comprobante == null)
            {
                return null;
            }
            return comprobante;
        }
        public async Task<ComprobanteFiscal> AddComprobante(ComprobanteFiscal comprobante)
        {
            var result = await _contribuyentesDbContext.ComprobantesFiscales.AddAsync(comprobante);
            _contribuyentesDbContext.SaveChanges();
            return result.Entity;
        }

        public async Task<ComprobanteFiscal?> UpdateComprobante(string ncf, ComprobanteFiscal comprobante)
        {
            var existingComprobante = await _contribuyentesDbContext.Set<ComprobanteFiscal>().FindAsync(ncf);
            if (existingComprobante == null)
            {
                return null;
            }
            _contribuyentesDbContext.Entry(existingComprobante).CurrentValues.SetValues(comprobante);
            _contribuyentesDbContext.SaveChanges();
            return existingComprobante;
        }
        public async Task<bool> DeleteComprobante(string ncf)
        {
            var comprobante = await _contribuyentesDbContext.Set<ComprobanteFiscal>().FindAsync(ncf);
            if (comprobante == null)
            {
                return false;
            }

            _contribuyentesDbContext.Set<ComprobanteFiscal>().Remove(comprobante);
            _contribuyentesDbContext.SaveChanges();
            return true;
        }
    }
}
