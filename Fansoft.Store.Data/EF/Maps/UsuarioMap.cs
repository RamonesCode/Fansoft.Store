﻿using Fansoft.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fansoft.Store.Data.EF.Maps
{
    public class UsuarioMap : EntityMap<Usuario>, IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {

            builder
                    .ToTable("Usuario") //Table
                    .HasKey(x => x.Id); //PK

            builder
                .Property(x => x.Nome)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder
                .Property(x => x.Email)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder
               .Property(x => x.Senha)
               .HasColumnType("char(88)")
               .IsRequired();

            builder
                .Property(x => x.Genero)
                .HasColumnType("int")
                .IsRequired();

            builder
                .HasOne(x => x.Usuario)
                .WithMany(x => x.Usuarios)
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);


            builder
               .HasMany(p => p.Perfis)
               .WithMany(p => p.Usuarios)
                .UsingEntity<Dictionary<string, object>>(
               
                "UsuarioPerfil",

                  
                    perfil => perfil
                        .HasOne<Perfil>()
                        .WithMany()
                        .HasForeignKey("PerfilId"),

                    usuario => usuario
                        .HasOne<Usuario>()
                        .WithMany()
                        .HasForeignKey("UsuarioId")



                );

            base.Setup(builder);

        }
    }
}