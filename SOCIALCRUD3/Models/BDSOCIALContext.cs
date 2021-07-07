using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SOCIALCRUD3.Models
{
    public partial class BDSOCIALContext : DbContext
    {
        public BDSOCIALContext()
        {
        }

        public BDSOCIALContext(DbContextOptions<BDSOCIALContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comentario> Comentarios { get; set; }
        public virtual DbSet<CtipoReac> CtipoReacs { get; set; }
        public virtual DbSet<CtipoUser> CtipoUsers { get; set; }
        public virtual DbSet<CtypePubli> CtypePublis { get; set; }
        public virtual DbSet<GruposS> GruposSes { get; set; }
        public virtual DbSet<ImagenesS> ImagenesSes { get; set; }
        public virtual DbSet<MensajesS> MensajesSes { get; set; }
        public virtual DbSet<PostGruposS> PostGruposSes { get; set; }
        public virtual DbSet<PublicacionesS> PublicacionesSes { get; set; }
        public virtual DbSet<ReaccionesS> ReaccionesSes { get; set; }
        public virtual DbSet<UsuarioGrupo> UsuarioGrupos { get; set; }
        public virtual DbSet<UsuariosS> UsuariosSes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-MMKDSEV; Initial catalog=BDSOCIAL; user id=sa; password=12345678;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.HasKey(e => e.IdComent);

                entity.Property(e => e.IdComent)
                    .ValueGeneratedNever()
                    .HasColumnName("id_coment");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdImagen).HasColumnName("id_imagen");

                entity.Property(e => e.IdPubli).HasColumnName("id_publi");

                entity.Property(e => e.IdUser)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_user");

                entity.Property(e => e.Texto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("texto");
            });

            modelBuilder.Entity<CtipoReac>(entity =>
            {
                entity.HasKey(e => e.IdTiporeact);

                entity.ToTable("CTipoReac");

                entity.Property(e => e.IdTiporeact).HasColumnName("id_tiporeact");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<CtipoUser>(entity =>
            {
                entity.HasKey(e => e.IdTipouser);

                entity.ToTable("CTipoUser");

                entity.Property(e => e.IdTipouser).HasColumnName("id_tipouser");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<CtypePubli>(entity =>
            {
                entity.HasKey(e => e.IdTypepost);

                entity.ToTable("CtypePubli");

                entity.Property(e => e.IdTypepost).HasColumnName("id_typepost");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<GruposS>(entity =>
            {
                entity.HasKey(e => e.IdGrupo);

                entity.ToTable("GruposS");

                entity.Property(e => e.IdGrupo).HasColumnName("id_grupo");

                entity.Property(e => e.TipoGrupo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipo_grupo");
            });

            modelBuilder.Entity<ImagenesS>(entity =>
            {
                entity.HasKey(e => e.IdImagen);

                entity.ToTable("ImagenesS");

                entity.Property(e => e.IdImagen).HasColumnName("id_imagen");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.Imagen)
                    .HasColumnType("image")
                    .HasColumnName("imagen");
            });

            modelBuilder.Entity<MensajesS>(entity =>
            {
                entity.HasKey(e => e.IdMsj);

                entity.ToTable("MensajesS");

                entity.Property(e => e.IdMsj)
                    .ValueGeneratedNever()
                    .HasColumnName("id_msj");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdEmisor).HasColumnName("id_emisor");

                entity.Property(e => e.IdReceptor)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_receptor");

                entity.Property(e => e.Texto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("texto");
            });

            modelBuilder.Entity<PostGruposS>(entity =>
            {
                entity.HasKey(e => e.IdPublicacion);

                entity.ToTable("PostGruposS");

                entity.Property(e => e.IdPublicacion)
                    .ValueGeneratedNever()
                    .HasColumnName("id_publicacion");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdGrupo).HasColumnName("id_grupo");

                entity.Property(e => e.IdImagen)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_imagen");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.Texto)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("texto");
            });

            modelBuilder.Entity<PublicacionesS>(entity =>
            {
                entity.HasKey(e => e.IdPublicacion);

                entity.ToTable("PublicacionesS");

                entity.Property(e => e.IdPublicacion)
                    .ValueGeneratedNever()
                    .HasColumnName("id_publicacion");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdImagen).HasColumnName("id_imagen");

                entity.Property(e => e.IdPostshared)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_postshared");

                entity.Property(e => e.IdTypepost).HasColumnName("id_typepost");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.Text)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("text");
            });

            modelBuilder.Entity<ReaccionesS>(entity =>
            {
                entity.HasKey(e => e.IdReaccion);

                entity.ToTable("ReaccionesS");

                entity.Property(e => e.IdReaccion)
                    .ValueGeneratedNever()
                    .HasColumnName("id_reaccion");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdPublicacion).HasColumnName("id_publicacion");

                entity.Property(e => e.IdTypereact)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_typereact");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            });

            modelBuilder.Entity<UsuarioGrupo>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("UsuarioGrupoS");

                entity.Property(e => e.IdUser)
                    .ValueGeneratedNever()
                    .HasColumnName("id_user");

                entity.Property(e => e.IdGrupo)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_grupo");

                entity.Property(e => e.TipoUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipo_usuario");
            });

            modelBuilder.Entity<UsuariosS>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("UsuariosS");

                entity.Property(e => e.IdUser)
                    .ValueGeneratedNever()
                    .HasColumnName("id_user");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contraseña");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombres");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("telefono");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
