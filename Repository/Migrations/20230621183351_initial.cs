using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "backend");

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "backend",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CountryCode = table.Column<string>(type: "char(2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                schema: "backend",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                schema: "backend",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Timezones",
                schema: "backend",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timezones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserStatuses",
                schema: "backend",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "backend",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountyId",
                        column: x => x.CountyId,
                        principalSchema: "backend",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "backend",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimezoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRegistered = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "backend",
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "backend",
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Genders_Gender",
                        column: x => x.Gender,
                        principalSchema: "backend",
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Languages_Language",
                        column: x => x.Language,
                        principalSchema: "backend",
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Timezones_TimezoneId",
                        column: x => x.TimezoneId,
                        principalSchema: "backend",
                        principalTable: "Timezones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_UserStatuses_Status",
                        column: x => x.Status,
                        principalSchema: "backend",
                        principalTable: "UserStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "backend",
                table: "Genders",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" },
                    { 3, "Other" }
                });

            migrationBuilder.InsertData(
                schema: "backend",
                table: "Languages",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "English" },
                    { 2, "Georgian" },
                    { 3, "Spanish" },
                    { 4, "Mandarin" },
                    { 5, "French" },
                    { 6, "Arabic" },
                    { 7, "Portuguese" },
                    { 8, "German" },
                    { 9, "Japanese" },
                    { 10, "Hindi" },
                    { 11, "Italian" },
                    { 12, "Korean" },
                    { 13, "Dutch" },
                    { 14, "Swedish" },
                    { 15, "Polish" },
                    { 16, "Russian" }
                });

            migrationBuilder.InsertData(
                schema: "backend",
                table: "UserStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Costumer" },
                    { 2, "Doctor" },
                    { 3, "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountyId",
                schema: "backend",
                table: "Cities",
                column: "CountyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CityId",
                schema: "backend",
                table: "Users",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CountryId",
                schema: "backend",
                table: "Users",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Gender",
                schema: "backend",
                table: "Users",
                column: "Gender");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Language",
                schema: "backend",
                table: "Users",
                column: "Language");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Status",
                schema: "backend",
                table: "Users",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TimezoneId",
                schema: "backend",
                table: "Users",
                column: "TimezoneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users",
                schema: "backend");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "backend");

            migrationBuilder.DropTable(
                name: "Genders",
                schema: "backend");

            migrationBuilder.DropTable(
                name: "Languages",
                schema: "backend");

            migrationBuilder.DropTable(
                name: "Timezones",
                schema: "backend");

            migrationBuilder.DropTable(
                name: "UserStatuses",
                schema: "backend");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "backend");
        }
    }
}
