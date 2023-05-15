
namespace ContribuyentesDGII.Data.DBContext
{
    public partial class ContribuyentesDbContext : DbContext
    {
        public ContribuyentesDbContext(DbContextOptions<ContribuyentesDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Contribuyente> Contribuyentes { get; set; }
        public virtual DbSet<ComprobanteFiscal> ComprobantesFiscales { get; set; }
        public virtual DbSet<Estatus> Estatus { get; set; }
        public virtual DbSet<TipoPersona> TipoPersonas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(InternalConnections.ConnectionString);
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ContribuyentesDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
            modelBuilder.ApplyConfiguration(new EstatusConfig());
            modelBuilder.ApplyConfiguration(new TipoPersonaConfig());
            modelBuilder.ApplyConfiguration(new ContribuyenteConfig());
            modelBuilder.ApplyConfiguration(new ComprobanteFiscalConfig());
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is EntidadBase
            && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                //Asignar la fecha de creacion si la operacion es de insertar nuevos datos
                if (entityEntry.State == EntityState.Added)
                {
                    ((EntidadBase)entityEntry.Entity).FechaCreacion = DateTime.Now;
                }
                else
                {
                    //Si la operacion no es de insertar entonces no modificar la fecha de creacion,
                    //porque si llega a este punto quiere decir que ya el registro existe
                    Entry((EntidadBase)entityEntry.Entity).Property(p => p.FechaCreacion).IsModified = false;
                }

                ((EntidadBase)entityEntry.Entity).UltimaFechaModificacion = DateTime.Now;
            }
            return base.SaveChanges();
        }
    }
}
