using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Open_Group.Migrations
{
    /// <inheritdoc />
    public partial class UniqueUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_T_OP_USUARIO_Email",
                table: "T_OP_USUARIO",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_T_OP_USUARIO_Identificacao",
                table: "T_OP_USUARIO",
                column: "Identificacao",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_T_OP_USUARIO_Email",
                table: "T_OP_USUARIO");

            migrationBuilder.DropIndex(
                name: "IX_T_OP_USUARIO_Identificacao",
                table: "T_OP_USUARIO");
        }
    }
}
