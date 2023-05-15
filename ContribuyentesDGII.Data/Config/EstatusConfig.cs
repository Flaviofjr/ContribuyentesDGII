

namespace ContribuyentesDGII.Data.Config
{
    public class EstatusConfig : IEntityTypeConfiguration<Estatus>
    {
        public void Configure(EntityTypeBuilder<Estatus> builder)
        {
            builder.ToTable("Estatus");
            builder.HasKey(e => e.IdEstatus);
            builder.Property(e => e.Descripcion).IsRequired().HasMaxLength(50);
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.UltimaFechaModificacion).HasColumnType("datetime");
        }
    }
}
