using System;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace taxiModel
{
    public partial class taxiContext : DbContext
    {
        public taxiContext()
        {
        }

        public taxiContext(DbContextOptions<taxiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Function> Function { get; set; }
        public virtual DbSet<Mark> Mark { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Phototransport> Phototransport { get; set; }
        public virtual DbSet<Rf> Rf { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Statustransport> Statustransport { get; set; }
        public virtual DbSet<Transport> Transport { get; set; }
        public virtual DbSet<Ur> Ur { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Если нет строки подключения, выбрасывается ошибка
            if (ConnectionString == "")
                throw new Exception("Connection string not specified");

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(ConnectionString);
            }
        }

        /// <summary>
        /// Устанка строки соеденения с Базой данных
        /// </summary>
        /// <param name="ConnectingString"></param>
        public static void SetConnectionString(string ConnectingString)
        {
            taxiContext.ConnectionString = ConnectingString;
        }

        /// <summary>
        /// Получение текущей строки соеденения с Базой данных
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString ()
        {
            return ConnectionString;
        }

        /// <summary>
        /// Строка для соеденения с Базой данных
        /// </summary>
        static string ConnectionString = "";

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Function>(entity =>
            {
                entity.ToTable("function");

                entity.HasIndex(e => e.Id)
                    .HasName("xpkfunction")
                    .IsUnique();

                entity.HasIndex(e => e.Systemname)
                    .HasName("xak1function")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Systemname)
                    .HasColumnName("systemname")
                    .HasMaxLength(20)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Mark>(entity =>
            {
                entity.ToTable("mark");

                entity.HasIndex(e => e.Id)
                    .HasName("xpkmark")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.ToTable("orders");

                entity.HasIndex(e => e.Id)
                    .HasName("xpkorders")
                    .IsUnique();

                entity.HasIndex(e => e.Idclient)
                    .HasName("xif1orders");

                entity.HasIndex(e => e.Idoperator)
                    .HasName("xif3orders");

                entity.HasIndex(e => e.Idtransport)
                    .HasName("xif2orders");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Endaddress)
                    .HasColumnName("endaddress")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Idclient).HasColumnName("idclient");

                entity.Property(e => e.Idoperator).HasColumnName("idoperator");

                entity.Property(e => e.Idtransport).HasColumnName("idtransport");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Startaddress)
                    .HasColumnName("startaddress")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.HasOne(d => d.IdclientNavigation)
                    .WithMany(p => p.OrdersIdclientNavigation)
                    .HasForeignKey(d => d.Idclient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("orders_fk");

                entity.HasOne(d => d.IdoperatorNavigation)
                    .WithMany(p => p.OrdersIdoperatorNavigation)
                    .HasForeignKey(d => d.Idoperator)
                    .HasConstraintName("orders_fk_3");

                entity.HasOne(d => d.IdtransportNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Idtransport)
                    .HasConstraintName("orders_fk_2");
            });

            modelBuilder.Entity<Phototransport>(entity =>
            {
                entity.ToTable("phototransport");

                entity.HasIndex(e => e.Id)
                    .HasName("xpkphototransport")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Photo).HasColumnName("photo");
            });

            modelBuilder.Entity<Rf>(entity =>
            {
                entity.ToTable("rf");

                entity.HasIndex(e => e.Id)
                    .HasName("xpkrf")
                    .IsUnique();

                entity.HasIndex(e => e.Idfunction)
                    .HasName("xif1rf");

                entity.HasIndex(e => e.Idroles)
                    .HasName("xif2rf");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Idfunction).HasColumnName("idfunction");

                entity.Property(e => e.Idroles).HasColumnName("idroles");

                entity.HasOne(d => d.IdfunctionNavigation)
                    .WithMany(p => p.Rf)
                    .HasForeignKey(d => d.Idfunction)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rf_fk_1");

                entity.HasOne(d => d.IdrolesNavigation)
                    .WithMany(p => p.Rf)
                    .HasForeignKey(d => d.Idroles)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rf_fk");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("roles");

                entity.HasIndex(e => e.Id)
                    .HasName("xpkroles")
                    .IsUnique();

                entity.HasIndex(e => e.Systemname)
                    .HasName("xak1roles")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Systemname)
                    .HasColumnName("systemname")
                    .HasMaxLength(20)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Statustransport>(entity =>
            {
                entity.ToTable("statustransport");

                entity.HasIndex(e => e.Id)
                    .HasName("xpkstatustransport")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Transport>(entity =>
            {
                entity.ToTable("transport");

                entity.HasIndex(e => e.Id)
                    .HasName("xpktransport")
                    .IsUnique();

                entity.HasIndex(e => e.Idmark)
                    .HasName("xif1transport");

                entity.HasIndex(e => e.Idphoto)
                    .HasName("xif2transport");

                entity.HasIndex(e => e.Idstatus)
                    .HasName("xif3transport");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Datecreate)
                    .HasColumnName("datecreate")
                    .HasColumnType("date");

                entity.Property(e => e.Dateregistration)
                    .HasColumnName("dateregistration")
                    .HasColumnType("date");

                entity.Property(e => e.Datewriteoff)
                    .HasColumnName("datewriteoff")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Idmark).HasColumnName("idmark");

                entity.Property(e => e.Idphoto).HasColumnName("idphoto");

                entity.Property(e => e.Idstatus).HasColumnName("idstatus");

                entity.Property(e => e.Model)
                    .HasColumnName("model")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.Property(e => e.Nunber)
                    .HasColumnName("nunber")
                    .HasMaxLength(20)
                    .IsFixedLength();

                entity.HasOne(d => d.IdmarkNavigation)
                    .WithMany(p => p.Transport)
                    .HasForeignKey(d => d.Idmark)
                    .HasConstraintName("transport_fk");

                entity.HasOne(d => d.IdphotoNavigation)
                    .WithMany(p => p.Transport)
                    .HasForeignKey(d => d.Idphoto)
                    .HasConstraintName("transport_fk_1");

                entity.HasOne(d => d.IdstatusNavigation)
                    .WithMany(p => p.Transport)
                    .HasForeignKey(d => d.Idstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("transport_fk_2");
            });

            modelBuilder.Entity<Ur>(entity =>
            {
                entity.ToTable("ur");

                entity.HasIndex(e => e.Id)
                    .HasName("xpkur")
                    .IsUnique();

                entity.HasIndex(e => e.Idroles)
                    .HasName("xif2ur");

                entity.HasIndex(e => e.Idusers)
                    .HasName("xif1ur");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Idroles).HasColumnName("idroles");

                entity.Property(e => e.Idusers).HasColumnName("idusers");

                entity.HasOne(d => d.IdrolesNavigation)
                    .WithMany(p => p.Ur)
                    .HasForeignKey(d => d.Idroles)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ur_fk_1");

                entity.HasOne(d => d.IdusersNavigation)
                    .WithMany(p => p.Ur)
                    .HasForeignKey(d => d.Idusers)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ur_fk");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Id)
                    .HasName("xpkusers")
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .HasName("xak1users")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Datebirth)
                    .HasColumnName("datebirth")
                    .HasColumnType("date");

                entity.Property(e => e.Firstname).HasColumnName("firstname");

                entity.Property(e => e.Hash)
                    .HasColumnName("hash")
                    .HasMaxLength(40)
                    .IsFixedLength();

                entity.Property(e => e.Salt)
                    .HasColumnName("salt")
                    .HasMaxLength(40)
                    .IsFixedLength();

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(200)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasColumnName("Email")
                    .HasMaxLength(200)
                    .IsFixedLength();

                entity.Property(e => e.Midname)
                    .HasColumnName("midname")
                    .HasMaxLength(200)
                    .IsFixedLength();

                entity.Property(e => e.Number)
                   .HasColumnName("number")
                   .HasMaxLength(200)
                   .IsFixedLength();

                entity.Property(e => e.Photo).HasColumnName("photo");

                entity.Property(e => e.Sex).HasColumnName("sex");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
