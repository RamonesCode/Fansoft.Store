using Fansoft.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fansoft.Store.Data.EF.Maps
{
    public abstract class EntityMap<TEntity> where TEntity : Entity
    {
        protected void Setup(EntityTypeBuilder<TEntity> builder) 
        {
            builder
                .Property(x => x.DataCadastro)
                .HasColumnType("datetime2")
                .IsRequired();

            builder
                .Property(x => x.DataAlteracao)
                .HasColumnType("datetime2")
                .IsRequired();

            builder
                .Property(x => x.UsuarioId)
                .HasColumnType("int")
                .IsRequired();

            //builder
            //    .HasOne(x=>x.Usuario)
            //    .WithMany(nameOf(TEntity))
        }
    }
}
