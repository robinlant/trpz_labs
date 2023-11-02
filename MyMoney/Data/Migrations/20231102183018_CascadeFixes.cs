using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyMoney.Data.Migrations
{
    /// <inheritdoc />
    public partial class CascadeFixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepeatingTransaction_Accounts_AccountId",
                table: "RepeatingTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_RepeatingTransaction_Users_MadeById",
                table: "RepeatingTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_RepeatingTransaction_RepeatingTransactionId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_MadeById",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RepeatingTransaction",
                table: "RepeatingTransaction");

            migrationBuilder.RenameTable(
                name: "RepeatingTransaction",
                newName: "RepeatingTransactions");

            migrationBuilder.RenameIndex(
                name: "IX_RepeatingTransaction_MadeById",
                table: "RepeatingTransactions",
                newName: "IX_RepeatingTransactions_MadeById");

            migrationBuilder.RenameIndex(
                name: "IX_RepeatingTransaction_AccountId",
                table: "RepeatingTransactions",
                newName: "IX_RepeatingTransactions_AccountId");

            migrationBuilder.AlterColumn<int>(
                name: "RepeatingTransactionId",
                table: "Transactions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "MadeById",
                table: "Transactions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "MadeById",
                table: "RepeatingTransactions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RepeatingTransactions",
                table: "RepeatingTransactions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RepeatingTransactions_Accounts_AccountId",
                table: "RepeatingTransactions",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RepeatingTransactions_Users_MadeById",
                table: "RepeatingTransactions",
                column: "MadeById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_RepeatingTransactions_RepeatingTransactionId",
                table: "Transactions",
                column: "RepeatingTransactionId",
                principalTable: "RepeatingTransactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_MadeById",
                table: "Transactions",
                column: "MadeById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepeatingTransactions_Accounts_AccountId",
                table: "RepeatingTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_RepeatingTransactions_Users_MadeById",
                table: "RepeatingTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_RepeatingTransactions_RepeatingTransactionId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Users_MadeById",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RepeatingTransactions",
                table: "RepeatingTransactions");

            migrationBuilder.RenameTable(
                name: "RepeatingTransactions",
                newName: "RepeatingTransaction");

            migrationBuilder.RenameIndex(
                name: "IX_RepeatingTransactions_MadeById",
                table: "RepeatingTransaction",
                newName: "IX_RepeatingTransaction_MadeById");

            migrationBuilder.RenameIndex(
                name: "IX_RepeatingTransactions_AccountId",
                table: "RepeatingTransaction",
                newName: "IX_RepeatingTransaction_AccountId");

            migrationBuilder.AlterColumn<int>(
                name: "RepeatingTransactionId",
                table: "Transactions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MadeById",
                table: "Transactions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MadeById",
                table: "RepeatingTransaction",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RepeatingTransaction",
                table: "RepeatingTransaction",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RepeatingTransaction_Accounts_AccountId",
                table: "RepeatingTransaction",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RepeatingTransaction_Users_MadeById",
                table: "RepeatingTransaction",
                column: "MadeById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_RepeatingTransaction_RepeatingTransactionId",
                table: "Transactions",
                column: "RepeatingTransactionId",
                principalTable: "RepeatingTransaction",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Users_MadeById",
                table: "Transactions",
                column: "MadeById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
