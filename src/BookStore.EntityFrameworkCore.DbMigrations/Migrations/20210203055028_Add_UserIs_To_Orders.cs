using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.Migrations
{
    public partial class Add_UserIs_To_Orders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "AppOrders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppOrders_UserId",
                table: "AppOrders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppOrders_AbpUsers_UserId",
                table: "AppOrders",
                column: "UserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppOrders_AbpUsers_UserId",
                table: "AppOrders");

            migrationBuilder.DropIndex(
                name: "IX_AppOrders_UserId",
                table: "AppOrders");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AppOrders");
        }
    }
}
