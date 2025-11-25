using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Codex.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Computers_IdComputers",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Favorites_IdFavorites",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_TypeUser_IdType",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_IdFavorites",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeUser",
                table: "TypeUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favorites",
                table: "Favorites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Computers",
                table: "Computers");

            migrationBuilder.DropColumn(
                name: "IdFavorites",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "TypeUser",
                newName: "typeuser");

            migrationBuilder.RenameTable(
                name: "Favorites",
                newName: "favorites");

            migrationBuilder.RenameTable(
                name: "Computers",
                newName: "computers");

            migrationBuilder.RenameIndex(
                name: "IX_Users_IdType",
                table: "users",
                newName: "IX_users_IdType");

            migrationBuilder.RenameIndex(
                name: "IX_Favorites_IdComputers",
                table: "favorites",
                newName: "IX_favorites_IdComputers");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "users",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Rol",
                table: "users",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "users",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Type_User",
                table: "typeuser",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "favorites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Storage",
                table: "computers",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Processor",
                table: "computers",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "computers",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Memory",
                table: "computers",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "computers",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "IdUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_typeuser",
                table: "typeuser",
                column: "IdType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_favorites",
                table: "favorites",
                column: "IdFavorites");

            migrationBuilder.AddPrimaryKey(
                name: "PK_computers",
                table: "computers",
                column: "IdComputers");

            migrationBuilder.CreateIndex(
                name: "IX_favorites_IdUser",
                table: "favorites",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_favorites_computers_IdComputers",
                table: "favorites",
                column: "IdComputers",
                principalTable: "computers",
                principalColumn: "IdComputers",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_favorites_users_IdUser",
                table: "favorites",
                column: "IdUser",
                principalTable: "users",
                principalColumn: "IdUsers",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_typeuser_IdType",
                table: "users",
                column: "IdType",
                principalTable: "typeuser",
                principalColumn: "IdType",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_favorites_computers_IdComputers",
                table: "favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_favorites_users_IdUser",
                table: "favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_users_typeuser_IdType",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_typeuser",
                table: "typeuser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_favorites",
                table: "favorites");

            migrationBuilder.DropIndex(
                name: "IX_favorites_IdUser",
                table: "favorites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_computers",
                table: "computers");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "favorites");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "typeuser",
                newName: "TypeUser");

            migrationBuilder.RenameTable(
                name: "favorites",
                newName: "Favorites");

            migrationBuilder.RenameTable(
                name: "computers",
                newName: "Computers");

            migrationBuilder.RenameIndex(
                name: "IX_users_IdType",
                table: "Users",
                newName: "IX_Users_IdType");

            migrationBuilder.RenameIndex(
                name: "IX_favorites_IdComputers",
                table: "Favorites",
                newName: "IX_Favorites_IdComputers");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Rol",
                table: "Users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "IdFavorites",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type_User",
                table: "TypeUser",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Storage",
                table: "Computers",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Processor",
                table: "Computers",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Computers",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Memory",
                table: "Computers",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Computers",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "IdUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeUser",
                table: "TypeUser",
                column: "IdType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favorites",
                table: "Favorites",
                column: "IdFavorites");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Computers",
                table: "Computers",
                column: "IdComputers");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdFavorites",
                table: "Users",
                column: "IdFavorites");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Computers_IdComputers",
                table: "Favorites",
                column: "IdComputers",
                principalTable: "Computers",
                principalColumn: "IdComputers",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Favorites_IdFavorites",
                table: "Users",
                column: "IdFavorites",
                principalTable: "Favorites",
                principalColumn: "IdFavorites");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_TypeUser_IdType",
                table: "Users",
                column: "IdType",
                principalTable: "TypeUser",
                principalColumn: "IdType",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
