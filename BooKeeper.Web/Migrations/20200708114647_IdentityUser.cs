using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BooKeeper.Web.Migrations
{
    public partial class IdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_IdCategory",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleDetails_Books_Isbn",
                table: "SaleDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleDetails_Sales_SaleId",
                table: "SaleDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Users_IdUser",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_IdUser",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_SaleDetails_Isbn",
                table: "SaleDetails");

            migrationBuilder.DropIndex(
                name: "IX_Books_IdCategory",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "Isbn",
                table: "SaleDetails");

            migrationBuilder.DropColumn(
                name: "IdCategory",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Sales",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SaleId",
                table: "SaleDetails",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Isbn1",
                table: "SaleDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryIdCategory",
                table: "Books",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
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
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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

            migrationBuilder.CreateIndex(
                name: "IX_Sales_UserId",
                table: "Sales",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetails_Isbn1",
                table: "SaleDetails",
                column: "Isbn1");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryIdCategory",
                table: "Books",
                column: "CategoryIdCategory");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_CategoryIdCategory",
                table: "Books",
                column: "CategoryIdCategory",
                principalTable: "Categories",
                principalColumn: "IdCategory",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleDetails_Books_Isbn1",
                table: "SaleDetails",
                column: "Isbn1",
                principalTable: "Books",
                principalColumn: "Isbn",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleDetails_Sales_SaleId",
                table: "SaleDetails",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "SaleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_AspNetUsers_UserId",
                table: "Sales",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CategoryIdCategory",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleDetails_Books_Isbn1",
                table: "SaleDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleDetails_Sales_SaleId",
                table: "SaleDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_AspNetUsers_UserId",
                table: "Sales");

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
                name: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "IX_Sales_UserId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_SaleDetails_Isbn1",
                table: "SaleDetails");

            migrationBuilder.DropIndex(
                name: "IX_Books_CategoryIdCategory",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "EmailIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "Isbn1",
                table: "SaleDetails");

            migrationBuilder.DropColumn(
                name: "CategoryIdCategory",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "Users");

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Sales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SaleId",
                table: "SaleDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Isbn",
                table: "SaleDetails",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCategory",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_IdUser",
                table: "Sales",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetails_Isbn",
                table: "SaleDetails",
                column: "Isbn");

            migrationBuilder.CreateIndex(
                name: "IX_Books_IdCategory",
                table: "Books",
                column: "IdCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_IdCategory",
                table: "Books",
                column: "IdCategory",
                principalTable: "Categories",
                principalColumn: "IdCategory",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleDetails_Books_Isbn",
                table: "SaleDetails",
                column: "Isbn",
                principalTable: "Books",
                principalColumn: "Isbn",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleDetails_Sales_SaleId",
                table: "SaleDetails",
                column: "SaleId",
                principalTable: "Sales",
                principalColumn: "SaleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Users_IdUser",
                table: "Sales",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "IdUser",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
