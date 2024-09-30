using API_P1700.DTOs;
using API_P1700.Models;
using Microsoft.EntityFrameworkCore;

namespace API_P1700.Data;

public partial class P1700Context : DbContext
{
    public P1700Context()
    {
    }

    public P1700Context(DbContextOptions<P1700Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<EmpleadosVistum> EmpleadosVista { get; set; }

    public virtual DbSet<ErroresProcedimiento> ErroresProcedimientos { get; set; }

    public virtual DbSet<Perfile> Perfiles { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<PermisosPerfile> PermisosPerfiles { get; set; }

    public virtual DbSet<Tienda> Tiendas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            var root = builder.Build();
            optionsBuilder.UseSqlServer(root.GetConnectionString("DevConnection"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado);

            entity.ToTable("EMPLEADOS");

            entity.HasIndex(e => e.Nombre, "IX_NOMBRE");

            entity.Property(e => e.IdEmpleado).HasColumnName("ID_EMPLEADO");
            entity.Property(e => e.CedulaInclusion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("CEDULA_INCLUSION");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("ESTADO");
            entity.Property(e => e.FechaInclusion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("FECHA_INCLUSION");
            entity.Property(e => e.IdSupervisor).HasColumnName("ID_SUPERVISOR");
            entity.Property(e => e.IdTienda).HasColumnName("ID_TIENDA");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Salario)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(11, 2)")
                .HasColumnName("SALARIO");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("TELEFONO");
            entity.Property(e => e.EsSupervisor)
                .HasDefaultValue(false)
                .HasColumnName("ES_SUPERVISOR");

            entity.HasOne(d => d.IdSupervisorNavigation).WithMany(p => p.InverseIdSupervisorNavigation)
                .HasForeignKey(d => d.IdSupervisor)
                .HasConstraintName("FK_EMPLEADOS_VS_EMPLEADOS");

            entity.HasOne(d => d.IdTiendaNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdTienda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("EMPLEADOS_VS_TIENDAS");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("EMPLEADOS_VS_USUARIOS");
        });

        modelBuilder.Entity<EmpleadosVistum>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("EMPLEADOS_VISTA");

            entity.Property(e => e.FechaInclusion).HasColumnName("FECHA_INCLUSION");
            entity.Property(e => e.IdEmpleado).HasColumnName("ID_EMPLEADO");
            entity.Property(e => e.IdSupervisor).HasColumnName("ID_SUPERVISOR");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Salario)
                .HasColumnType("decimal(11, 2)")
                .HasColumnName("SALARIO");
            entity.Property(e => e.Supervisor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SUPERVISOR");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TELEFONO");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TIPO");
        });

        modelBuilder.Entity<ErroresProcedimiento>(entity =>
        {
            entity.HasKey(e => e.IdErrorProcedimiento);

            entity.ToTable("ERRORES_PROCEDIMIENTO");

            entity.Property(e => e.IdErrorProcedimiento).HasColumnName("ID_ERROR_PROCEDIMIENTO");
            entity.Property(e => e.Bloque)
                .HasDefaultValue((short)-1)
                .HasColumnName("BLOQUE");
            entity.Property(e => e.CedulaInclusion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("-1")
                .HasColumnName("CEDULA_INCLUSION");
            entity.Property(e => e.Estado)
                .HasDefaultValue(-1)
                .HasColumnName("ESTADO");
            entity.Property(e => e.FechaInclusion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("FECHA_INCLUSION");
            entity.Property(e => e.Importancia)
                .HasDefaultValue(-1)
                .HasColumnName("IMPORTANCIA");
            entity.Property(e => e.Linea)
                .HasDefaultValue(-1)
                .HasColumnName("LINEA");
            entity.Property(e => e.Mensaje)
                .HasMaxLength(200)
                .HasDefaultValue("")
                .HasColumnName("MENSAJE");
            entity.Property(e => e.MensajeBd)
                .HasMaxLength(2000)
                .HasDefaultValue("")
                .HasColumnName("MENSAJE_BD");
            entity.Property(e => e.NumeroError)
                .HasDefaultValue(-1)
                .HasColumnName("NUMERO_ERROR");
            entity.Property(e => e.Procedimiento)
                .HasMaxLength(200)
                .HasDefaultValue("")
                .HasColumnName("PROCEDIMIENTO");
        });

        modelBuilder.Entity<Perfile>(entity =>
        {
            entity.HasKey(e => e.IdPerfil);

            entity.ToTable("PERFILES");

            entity.HasIndex(e => e.Perfil, "IX_PERFIL");

            entity.Property(e => e.IdPerfil).HasColumnName("ID_PERFIL");
            entity.Property(e => e.CedulaInclusion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("CEDULA_INCLUSION");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("ESTADO");
            entity.Property(e => e.FechaInclusion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("FECHA_INCLUSION");
            entity.Property(e => e.Perfil)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PERFIL");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.IdPermiso);

            entity.ToTable("PERMISOS");

            entity.HasIndex(e => e.Permiso1, "IX_PERMISO");

            entity.Property(e => e.IdPermiso).HasColumnName("ID_PERMISO");
            entity.Property(e => e.CedulaInclusion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("CEDULA_INCLUSION");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("ESTADO");
            entity.Property(e => e.FechaInclusion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("FECHA_INCLUSION");
            entity.Property(e => e.Permiso1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PERMISO");
        });

        modelBuilder.Entity<PermisosPerfile>(entity =>
        {
            entity.HasKey(e => e.IdPermisoPerfil);

            entity.ToTable("PERMISOS_PERFILES");

            entity.Property(e => e.IdPermisoPerfil).HasColumnName("ID_PERMISO_PERFIL");
            entity.Property(e => e.FechaInclusion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("FECHA_INCLUSION");
            entity.Property(e => e.IdPerfil).HasColumnName("ID_PERFIL");
            entity.Property(e => e.IdPermiso).HasColumnName("ID_PERMISO");

            entity.HasOne(d => d.IdPerfilNavigation).WithMany(p => p.PermisosPerfiles)
                .HasForeignKey(d => d.IdPerfil)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PERMISOS_PERFILES_VS_PERFILES");

            entity.HasOne(d => d.IdPermisoNavigation).WithMany(p => p.PermisosPerfiles)
                .HasForeignKey(d => d.IdPermiso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PERMISOS_PERFILES_VS_PERMISOS");
        });

        modelBuilder.Entity<Tienda>(entity =>
        {
            entity.HasKey(e => e.IdTienda);

            entity.ToTable("TIENDAS");

            entity.HasIndex(e => e.Tienda1, "IX_TIENDA");

            entity.Property(e => e.IdTienda).HasColumnName("ID_TIENDA");
            entity.Property(e => e.CedulaInclusion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("CEDULA_INCLUSION");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("ESTADO");
            entity.Property(e => e.FechaInclusion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("FECHA_INCLUSION");
            entity.Property(e => e.Tienda1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TIENDA");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("USUARIOS");

            entity.HasIndex(e => e.Cedula, "IX_CEDULA");

            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(e => e.Cedula)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CEDULA");
            entity.Property(e => e.CedulaInclusion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("")
                .HasColumnName("CEDULA_INCLUSION");
            entity.Property(e => e.Contrasenia)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CONTRASENIA");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("ESTADO");
            entity.Property(e => e.FechaInclusion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("FECHA_INCLUSION");
            entity.Property(e => e.IdPerfil).HasColumnName("ID_PERFIL");

            entity.HasOne(d => d.IdPerfilNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdPerfil)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("USUARIOS_VS_PERFILES");
        });

        // Autoriza el ejecucion del SP y su respuesta
        modelBuilder.Entity<StoredProcedureDto>(entity =>
        {
            entity.HasNoKey();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}


