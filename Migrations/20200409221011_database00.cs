using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MiniProjet_alpha.Migrations
{
    public partial class database00 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    datenaissance = table.Column<DateTime>(nullable: true),
                    statut = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "filiere",
                columns: table => new
                {
                    IdFiliere = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    libelle = table.Column<string>(maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_filiere", x => x.IdFiliere);
                });

            migrationBuilder.CreateTable(
                name: "matiere",
                columns: table => new
                {
                    IdMatiere = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    libelle = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_matiere", x => x.IdMatiere);
                });

            migrationBuilder.CreateTable(
                name: "salle",
                columns: table => new
                {
                    IdSalle = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Libelle = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salle", x => x.IdSalle);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "administrateur",
                columns: table => new
                {
                    IdAdministrateur = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nom = table.Column<string>(maxLength: 20, nullable: false),
                    prenom = table.Column<string>(maxLength: 20, nullable: false),
                    UtilisateurId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_administrateur", x => x.IdAdministrateur);
                    table.ForeignKey(
                        name: "FK_administrateur_AspNetUsers_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "classe",
                columns: table => new
                {
                    IdClasse = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    libelle = table.Column<string>(maxLength: 10, nullable: false),
                    FiliereIdFiliere = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classe", x => x.IdClasse);
                    table.ForeignKey(
                        name: "FK_classe_filiere_FiliereIdFiliere",
                        column: x => x.FiliereIdFiliere,
                        principalTable: "filiere",
                        principalColumn: "IdFiliere",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "professeur",
                columns: table => new
                {
                    IdProfesseur = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nom = table.Column<string>(maxLength: 20, nullable: false),
                    prenom = table.Column<string>(maxLength: 20, nullable: false),
                    matericule = table.Column<string>(maxLength: 10, nullable: false),
                    dateembauche = table.Column<DateTime>(nullable: false),
                    MatiereId = table.Column<int>(nullable: false),
                    UtilisateurId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_professeur", x => x.IdProfesseur);
                    table.ForeignKey(
                        name: "FK_professeur_matiere_MatiereId",
                        column: x => x.MatiereId,
                        principalTable: "matiere",
                        principalColumn: "IdMatiere",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_professeur_AspNetUsers_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "etudiant",
                columns: table => new
                {
                    IdEtudiant = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nom = table.Column<string>(maxLength: 20, nullable: false),
                    prenom = table.Column<string>(maxLength: 20, nullable: false),
                    matricule = table.Column<string>(maxLength: 10, nullable: false),
                    ClasseIdClasse = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_etudiant", x => x.IdEtudiant);
                    table.ForeignKey(
                        name: "FK_etudiant_classe_ClasseIdClasse",
                        column: x => x.ClasseIdClasse,
                        principalTable: "classe",
                        principalColumn: "IdClasse",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "seance",
                columns: table => new
                {
                    IdSeance = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    dateseance = table.Column<DateTime>(nullable: false),
                    heuredebut = table.Column<TimeSpan>(nullable: false),
                    heurefin = table.Column<TimeSpan>(nullable: false),
                    ClasseId = table.Column<int>(nullable: false),
                    ProfesseurId = table.Column<int>(nullable: false),
                    IdSalle = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seance", x => x.IdSeance);
                    table.ForeignKey(
                        name: "FK_seance_classe_ClasseId",
                        column: x => x.ClasseId,
                        principalTable: "classe",
                        principalColumn: "IdClasse",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_seance_salle_IdSalle",
                        column: x => x.IdSalle,
                        principalTable: "salle",
                        principalColumn: "IdSalle",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_seance_professeur_ProfesseurId",
                        column: x => x.ProfesseurId,
                        principalTable: "professeur",
                        principalColumn: "IdProfesseur",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "absance",
                columns: table => new
                {
                    IdAbsance = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EstAbsant = table.Column<int>(nullable: false),
                    SeanceIdSeance = table.Column<int>(nullable: false),
                    EtudiantIdEtudiant = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_absance", x => x.IdAbsance);
                    table.ForeignKey(
                        name: "FK_absance_etudiant_EtudiantIdEtudiant",
                        column: x => x.EtudiantIdEtudiant,
                        principalTable: "etudiant",
                        principalColumn: "IdEtudiant",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_absance_seance_SeanceIdSeance",
                        column: x => x.SeanceIdSeance,
                        principalTable: "seance",
                        principalColumn: "IdSeance",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_absance_EtudiantIdEtudiant",
                table: "absance",
                column: "EtudiantIdEtudiant");

            migrationBuilder.CreateIndex(
                name: "IX_absance_SeanceIdSeance",
                table: "absance",
                column: "SeanceIdSeance");

            migrationBuilder.CreateIndex(
                name: "IX_administrateur_UtilisateurId",
                table: "administrateur",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_classe_FiliereIdFiliere",
                table: "classe",
                column: "FiliereIdFiliere");

            migrationBuilder.CreateIndex(
                name: "IX_etudiant_ClasseIdClasse",
                table: "etudiant",
                column: "ClasseIdClasse");

            migrationBuilder.CreateIndex(
                name: "IX_professeur_MatiereId",
                table: "professeur",
                column: "MatiereId");

            migrationBuilder.CreateIndex(
                name: "IX_professeur_UtilisateurId",
                table: "professeur",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_seance_ClasseId",
                table: "seance",
                column: "ClasseId");

            migrationBuilder.CreateIndex(
                name: "IX_seance_IdSalle",
                table: "seance",
                column: "IdSalle");

            migrationBuilder.CreateIndex(
                name: "IX_seance_ProfesseurId",
                table: "seance",
                column: "ProfesseurId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "absance");

            migrationBuilder.DropTable(
                name: "administrateur");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "etudiant");

            migrationBuilder.DropTable(
                name: "seance");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "classe");

            migrationBuilder.DropTable(
                name: "salle");

            migrationBuilder.DropTable(
                name: "professeur");

            migrationBuilder.DropTable(
                name: "filiere");

            migrationBuilder.DropTable(
                name: "matiere");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
