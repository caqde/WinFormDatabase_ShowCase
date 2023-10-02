using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_DBLibrary.Migrations
{
    /// <inheritdoc />
    public partial class Version00004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowedBooks_Patrons_PatronId",
                table: "BorrowedBooks");

            migrationBuilder.AlterColumn<int>(
                name: "PatronId",
                table: "BorrowedBooks",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowedBooks_Patrons_PatronId",
                table: "BorrowedBooks",
                column: "PatronId",
                principalTable: "Patrons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowedBooks_Patrons_PatronId",
                table: "BorrowedBooks");

            migrationBuilder.AlterColumn<int>(
                name: "PatronId",
                table: "BorrowedBooks",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowedBooks_Patrons_PatronId",
                table: "BorrowedBooks",
                column: "PatronId",
                principalTable: "Patrons",
                principalColumn: "Id");
        }
    }
}
