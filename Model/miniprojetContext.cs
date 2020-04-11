using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MiniProjet_alpha.Model
{
    public partial class miniprojetContext : DbContext
    {
        public miniprojetContext()
        {
        }

        public miniprojetContext(DbContextOptions<miniprojetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Absance> Absance { get; set; }
        public virtual DbSet<Administrateur> Administrateur { get; set; }
        public virtual DbSet<Aspnetroleclaims> Aspnetroleclaims { get; set; }
        public virtual DbSet<Aspnetroles> Aspnetroles { get; set; }
        public virtual DbSet<Aspnetuserclaims> Aspnetuserclaims { get; set; }
        public virtual DbSet<Aspnetuserlogins> Aspnetuserlogins { get; set; }
        public virtual DbSet<Aspnetuserroles> Aspnetuserroles { get; set; }
        public virtual DbSet<Aspnetusers> Aspnetusers { get; set; }
        public virtual DbSet<Aspnetusertokens> Aspnetusertokens { get; set; }
        public virtual DbSet<Classe> Classe { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistory { get; set; }
        public virtual DbSet<Etudiant> Etudiant { get; set; }
        public virtual DbSet<Filiere> Filiere { get; set; }
        public virtual DbSet<Matiere> Matiere { get; set; }
        public virtual DbSet<Professeur> Professeur { get; set; }
        public virtual DbSet<Salle> Salle { get; set; }
        public virtual DbSet<Seance> Seance { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=127.0.0.1;port=3306;uid=root;database=miniprojet", x => x.ServerVersion("10.4.11-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Absance>(entity =>
            {
                entity.HasKey(e => e.IdAbsance)
                    .HasName("PRIMARY");

                entity.ToTable("absance");

                entity.HasIndex(e => e.EtudiantIdEtudiant);

                entity.HasIndex(e => e.SeanceIdSeance);

                entity.Property(e => e.IdAbsance).HasColumnType("int(11)");

                entity.Property(e => e.EstAbsant).HasColumnType("int(11)");

                entity.Property(e => e.EtudiantIdEtudiant).HasColumnType("int(11)");

                entity.Property(e => e.SeanceIdSeance).HasColumnType("int(11)");

                entity.HasOne(d => d.EtudiantIdEtudiantNavigation)
                    .WithMany(p => p.Absance)
                    .HasForeignKey(d => d.EtudiantIdEtudiant);

                entity.HasOne(d => d.SeanceIdSeanceNavigation)
                    .WithMany(p => p.Absance)
                    .HasForeignKey(d => d.SeanceIdSeance);
            });

            modelBuilder.Entity<Administrateur>(entity =>
            {
                entity.HasKey(e => e.IdAdministrateur)
                    .HasName("PRIMARY");

                entity.ToTable("administrateur");

                entity.HasIndex(e => e.UtilisateurId);

                entity.Property(e => e.IdAdministrateur).HasColumnType("int(11)");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Prenom)
                    .IsRequired()
                    .HasColumnName("prenom")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.UtilisateurId)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.Utilisateur)
                    .WithMany(p => p.Administrateur)
                    .HasForeignKey(d => d.UtilisateurId)
                    .HasConstraintName("FK_administrateur_AspNetUsers_UtilisateurId");
            });

            modelBuilder.Entity<Aspnetroleclaims>(entity =>
            {
                entity.ToTable("aspnetroleclaims");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ClaimType)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ClaimValue)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetroleclaims)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetRoleClaims_AspNetRoles_RoleId");
            });

            modelBuilder.Entity<Aspnetroles>(entity =>
            {
                entity.ToTable("aspnetroles");

                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ConcurrencyStamp)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(256)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.NormalizedName)
                    .HasColumnType("varchar(256)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Aspnetuserclaims>(entity =>
            {
                entity.ToTable("aspnetuserclaims");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserClaims_UserId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ClaimType)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ClaimValue)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserclaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserClaims_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserlogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PRIMARY");

                entity.ToTable("aspnetuserlogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider)
                    .HasColumnType("varchar(128)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ProviderKey)
                    .HasColumnType("varchar(128)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ProviderDisplayName)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserlogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetuserroles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PRIMARY");

                entity.ToTable("aspnetuserroles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetUserRoles_RoleId");

                entity.Property(e => e.UserId)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.RoleId)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetuserroles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserRoles_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Aspnetusers>(entity =>
            {
                entity.ToTable("aspnetusers");

                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");

                entity.Property(e => e.ConcurrencyStamp)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Datenaissance).HasColumnName("datenaissance");

                entity.Property(e => e.Discriminator)
                    .IsRequired()
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(256)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.NormalizedEmail)
                    .HasColumnType("varchar(256)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.NormalizedUserName)
                    .HasColumnType("varchar(256)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.PasswordHash)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.SecurityStamp)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Statut)
                    .HasColumnName("statut")
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.UserName)
                    .HasColumnType("varchar(256)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Aspnetusertokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                    .HasName("PRIMARY");

                entity.ToTable("aspnetusertokens");

                entity.Property(e => e.UserId)
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.LoginProvider)
                    .HasColumnType("varchar(128)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(128)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Value)
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Aspnetusertokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserTokens_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Classe>(entity =>
            {
                entity.HasKey(e => e.IdClasse)
                    .HasName("PRIMARY");

                entity.ToTable("classe");

                entity.HasIndex(e => e.FiliereIdFiliere);

                entity.Property(e => e.IdClasse).HasColumnType("int(11)");

                entity.Property(e => e.FiliereIdFiliere).HasColumnType("int(11)");

                entity.Property(e => e.Libelle)
                    .IsRequired()
                    .HasColumnName("libelle")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.FiliereIdFiliereNavigation)
                    .WithMany(p => p.Classe)
                    .HasForeignKey(d => d.FiliereIdFiliere);
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId)
                    .HasColumnType("varchar(95)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Etudiant>(entity =>
            {
                entity.HasKey(e => e.IdEtudiant)
                    .HasName("PRIMARY");

                entity.ToTable("etudiant");

                entity.HasIndex(e => e.ClasseIdClasse);

                entity.Property(e => e.IdEtudiant).HasColumnType("int(11)");

                entity.Property(e => e.ClasseIdClasse).HasColumnType("int(11)");

                entity.Property(e => e.Matricule)
                    .IsRequired()
                    .HasColumnName("matricule")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Prenom)
                    .IsRequired()
                    .HasColumnName("prenom")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.ClasseIdClasseNavigation)
                    .WithMany(p => p.Etudiant)
                    .HasForeignKey(d => d.ClasseIdClasse);
            });

            modelBuilder.Entity<Filiere>(entity =>
            {
                entity.HasKey(e => e.IdFiliere)
                    .HasName("PRIMARY");

                entity.ToTable("filiere");

                entity.Property(e => e.IdFiliere).HasColumnType("int(11)");

                entity.Property(e => e.Libelle)
                    .IsRequired()
                    .HasColumnName("libelle")
                    .HasColumnType("varchar(5)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Matiere>(entity =>
            {
                entity.HasKey(e => e.IdMatiere)
                    .HasName("PRIMARY");

                entity.ToTable("matiere");

                entity.Property(e => e.IdMatiere).HasColumnType("int(11)");

                entity.Property(e => e.Libelle)
                    .IsRequired()
                    .HasColumnName("libelle")
                    .HasColumnType("varchar(30)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Professeur>(entity =>
            {
                entity.HasKey(e => e.IdProfesseur)
                    .HasName("PRIMARY");

                entity.ToTable("professeur");

                entity.HasIndex(e => e.MatiereId);

                entity.HasIndex(e => e.UtilisateurId);

                entity.Property(e => e.IdProfesseur).HasColumnType("int(11)");

                entity.Property(e => e.Dateembauche).HasColumnName("dateembauche");

                entity.Property(e => e.Matericule)
                    .IsRequired()
                    .HasColumnName("matericule")
                    .HasColumnType("varchar(10)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.MatiereId).HasColumnType("int(11)");

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasColumnName("nom")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Prenom)
                    .IsRequired()
                    .HasColumnName("prenom")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.UtilisateurId)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.Matiere)
                    .WithMany(p => p.Professeur)
                    .HasForeignKey(d => d.MatiereId);

                entity.HasOne(d => d.Utilisateur)
                    .WithMany(p => p.Professeur)
                    .HasForeignKey(d => d.UtilisateurId)
                    .HasConstraintName("FK_professeur_AspNetUsers_UtilisateurId");
            });

            modelBuilder.Entity<Salle>(entity =>
            {
                entity.HasKey(e => e.IdSalle)
                    .HasName("PRIMARY");

                entity.ToTable("salle");

                entity.Property(e => e.IdSalle).HasColumnType("int(11)");

                entity.Property(e => e.Libelle)
                    .IsRequired()
                    .HasColumnType("longtext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Seance>(entity =>
            {
                entity.HasKey(e => e.IdSeance)
                    .HasName("PRIMARY");

                entity.ToTable("seance");

                entity.HasIndex(e => e.ClasseId);

                entity.HasIndex(e => e.IdSalle);

                entity.HasIndex(e => e.ProfesseurId);

                entity.Property(e => e.IdSeance).HasColumnType("int(11)");

                entity.Property(e => e.ClasseId).HasColumnType("int(11)");

                entity.Property(e => e.Dateseance).HasColumnName("dateseance");

                entity.Property(e => e.Heuredebut).HasColumnName("heuredebut");

                entity.Property(e => e.Heurefin).HasColumnName("heurefin");

                entity.Property(e => e.IdSalle).HasColumnType("int(11)");

                entity.Property(e => e.ProfesseurId).HasColumnType("int(11)");

                entity.HasOne(d => d.Classe)
                    .WithMany(p => p.Seance)
                    .HasForeignKey(d => d.ClasseId);

                entity.HasOne(d => d.IdSalleNavigation)
                    .WithMany(p => p.Seance)
                    .HasForeignKey(d => d.IdSalle);

                entity.HasOne(d => d.Professeur)
                    .WithMany(p => p.Seance)
                    .HasForeignKey(d => d.ProfesseurId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
