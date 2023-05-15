
namespace ContribuyentesDGII.Data.Config
{
    public class ContribuyenteConfig : IEntityTypeConfiguration<Contribuyente>
    {
        public void Configure(EntityTypeBuilder<Contribuyente> builder)
        {
            builder.ToTable("Contribuyentes");
            builder.HasKey(e => e.RncCedula);
            builder.Property(e => e.Nombre).IsRequired();
            builder.Property(e => e.IdTipoPersona).IsRequired();
            builder.Property(e => e.IdEstatus).IsRequired();
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.UltimaFechaModificacion).HasColumnType("datetime");

            builder.HasOne(fk => fk.Tipo)
                .WithMany(c => c.Contribuyentes)
                .HasForeignKey(i => i.IdTipoPersona)
                .HasConstraintName("FK_Contribuyentes_TipoPersonas");

            builder.HasOne(fk => fk.Estatus)
                .WithMany(c => c.Contribuyentes)
                .HasForeignKey(i => i.IdEstatus)
                .HasConstraintName("FK_Contribuyentes_Estatus");
        }
    }
}
