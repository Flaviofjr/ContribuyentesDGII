
namespace ContribuyentesDGII.Data.Config
{
    public class ComprobanteFiscalConfig : IEntityTypeConfiguration<ComprobanteFiscal>
    {
        public void Configure(EntityTypeBuilder<ComprobanteFiscal> builder)
        {
            builder.ToTable("ComprobantesFiscales");
            builder.HasKey(i => i.NCF);
            builder.Property(e => e.RncCedula).IsRequired();
            builder.Property(e => e.Monto).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(e => e.Itbis18).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(e => e.FechaCreacion).HasColumnType("datetime");
            builder.Property(e => e.UltimaFechaModificacion).HasColumnType("datetime");

            builder.HasOne(fk => fk.Contribuyente)
                .WithMany(c => c.Comprobantes)
                .HasForeignKey(i => i.RncCedula)
                .HasConstraintName("FK_ComprobantesFiscales_Contribuyentes");
        }
    }
}
