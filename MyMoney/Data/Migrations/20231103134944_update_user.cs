using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMoney.Data.Migrations
{
    /// <inheritdoc />
    public partial class update_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfJoin",
                table: "Users",
                newName: "JoinDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JoinDate",
                table: "Users",
                newName: "DateOfJoin");
        }
    }
}
