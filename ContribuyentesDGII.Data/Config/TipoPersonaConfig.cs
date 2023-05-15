
namespace ContribuyentesDGII.Data.Config
{
    public class TipoPersonaConfig : IEntityTypeConfiguration<TipoPersona>
    {
        public void Configure(EntityTypeBuilder<TipoPersona> builder)
        {
            builder.ToTable("TipoPersonas");
            builder.HasKey(i => i.IdTipoPersona);
            builder.Property(e => e.DescripcionPersona).IsRequired().HasMaxLength(150);
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.UltimaFechaModificacion).HasColumnType("datetime");
        }
    }
}
