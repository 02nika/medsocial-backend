﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class UserRelationAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_Status",
                schema: "backend",
                table: "Users",
                column: "Status");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserStatuses_Status",
                schema: "backend",
                table: "Users",
                column: "Status",
                principalSchema: "backend",
                principalTable: "UserStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserStatuses_Status",
                schema: "backend",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Status",
                schema: "backend",
                table: "Users");
        }
    }
}
