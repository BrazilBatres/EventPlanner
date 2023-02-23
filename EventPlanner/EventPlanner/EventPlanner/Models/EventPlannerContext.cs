using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EventPlannerModels;

public partial class EventPlannerContext : DbContext
{
    public EventPlannerContext()
    {
    }

    public EventPlannerContext(DbContextOptions<EventPlannerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    {
        if (!optionsBuilder.IsConfigured)

        {

            IConfigurationRoot configuration = new ConfigurationBuilder()

            .SetBasePath(Directory.GetCurrentDirectory())

                        .AddJsonFile("appsettings.json")

                        .Build();

            var connectionString = configuration.GetConnectionString("event_planner");

            optionsBuilder.UseMySQL(connectionString);

        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("categoria");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<TipoUsuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tipo_usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.TipoUsuario, "tipo_usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contrasenia)
                .HasMaxLength(255)
                .HasColumnName("contrasenia");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.TipoUsuario).HasColumnName("tipo_usuario");

            entity.HasOne(d => d.TipoUsuarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.TipoUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usuario_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
