using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class ChangeTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpectedCost_Crypta_CryptaId",
                table: "ExpectedCost");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpectedCost_User_UserId",
                table: "ExpectedCost");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Crypta_CryptaId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_UserId",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpectedCost",
                table: "ExpectedCost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Crypta",
                table: "Crypta");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "ExpectedCost",
                newName: "ExpectedCosts");

            migrationBuilder.RenameTable(
                name: "Crypta",
                newName: "Cryptas");

            migrationBuilder.RenameIndex(
                name: "IX_Order_UserId",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_CryptaId",
                table: "Orders",
                newName: "IX_Orders_CryptaId");

            migrationBuilder.RenameIndex(
                name: "IX_ExpectedCost_UserId",
                table: "ExpectedCosts",
                newName: "IX_ExpectedCosts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ExpectedCost_CryptaId",
                table: "ExpectedCosts",
                newName: "IX_ExpectedCosts_CryptaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpectedCosts",
                table: "ExpectedCosts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cryptas",
                table: "Cryptas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpectedCosts_Cryptas_CryptaId",
                table: "ExpectedCosts",
                column: "CryptaId",
                principalTable: "Cryptas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpectedCosts_Users_UserId",
                table: "ExpectedCosts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Cryptas_CryptaId",
                table: "Orders",
                column: "CryptaId",
                principalTable: "Cryptas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpectedCosts_Cryptas_CryptaId",
                table: "ExpectedCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpectedCosts_Users_UserId",
                table: "ExpectedCosts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Cryptas_CryptaId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpectedCosts",
                table: "ExpectedCosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cryptas",
                table: "Cryptas");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "ExpectedCosts",
                newName: "ExpectedCost");

            migrationBuilder.RenameTable(
                name: "Cryptas",
                newName: "Crypta");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                table: "Order",
                newName: "IX_Order_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CryptaId",
                table: "Order",
                newName: "IX_Order_CryptaId");

            migrationBuilder.RenameIndex(
                name: "IX_ExpectedCosts_UserId",
                table: "ExpectedCost",
                newName: "IX_ExpectedCost_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ExpectedCosts_CryptaId",
                table: "ExpectedCost",
                newName: "IX_ExpectedCost_CryptaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpectedCost",
                table: "ExpectedCost",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Crypta",
                table: "Crypta",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpectedCost_Crypta_CryptaId",
                table: "ExpectedCost",
                column: "CryptaId",
                principalTable: "Crypta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpectedCost_User_UserId",
                table: "ExpectedCost",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Crypta_CryptaId",
                table: "Order",
                column: "CryptaId",
                principalTable: "Crypta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User_UserId",
                table: "Order",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
