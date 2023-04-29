using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bl.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Users",
                newName: "TbUsers");

            migrationBuilder.RenameTable(
                name: "BankAccounts",
                newName: "TbBankAccounts");

            migrationBuilder.RenameTable(
                name: "Payments",
                newName: "TbPayments");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbBankAccounts_TbUsers_UserId",
                table: "TbBankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_TbPayments_TbBankAccounts_BankAccountId",
                table: "TbPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_TbPayments_TbUsers_UserId",
                table: "TbPayments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbUsers",
                table: "TbUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbPayments",
                table: "TbPayments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbBankAccounts",
                table: "TbBankAccounts");

            migrationBuilder.DropColumn(
                name: "CurrentState",
                table: "TbUsers");

            migrationBuilder.RenameTable(
                name: "TbUsers",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "TbPayments",
                newName: "Payments");

            migrationBuilder.RenameTable(
                name: "TbBankAccounts",
                newName: "BankAccounts");

            migrationBuilder.RenameIndex(
                name: "IX_TbPayments_UserId",
                table: "Payments",
                newName: "IX_Payments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TbPayments_BankAccountId",
                table: "Payments",
                newName: "IX_Payments_BankAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_TbBankAccounts_UserId",
                table: "BankAccounts",
                newName: "IX_BankAccounts_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payments",
                table: "Payments",
                column: "PaymentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankAccounts",
                table: "BankAccounts",
                column: "BankAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_Users_UserId",
                table: "BankAccounts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_BankAccounts_BankAccountId",
                table: "Payments",
                column: "BankAccountId",
                principalTable: "BankAccounts",
                principalColumn: "BankAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Users_UserId",
                table: "Payments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
