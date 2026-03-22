using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AttandanceTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttandanceTable",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttandanceTable", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "AttandanceUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttandanceUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttandanceUser_AttandanceTable_RoleID",
                        column: x => x.RoleID,
                        principalTable: "AttandanceTable",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttandanceCheck",
                columns: table => new
                {
                    AttendanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Course = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecordedBy = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttandanceCheck", x => x.AttendanceID);
                    table.ForeignKey(
                        name: "FK_AttandanceCheck_AttandanceUser_RecordedBy",
                        column: x => x.RecordedBy,
                        principalTable: "AttandanceUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AttandanceCheck_AttandanceUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AttandanceUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AttandanceCheck_AttandanceUser_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AttandanceUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AttandanceDetailsDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttandanceDetailsDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttandanceDetailsDetails_AttandanceUser_UserId",
                        column: x => x.UserId,
                        principalTable: "AttandanceUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttandanceCheck_RecordedBy",
                table: "AttandanceCheck",
                column: "RecordedBy");

            migrationBuilder.CreateIndex(
                name: "IX_AttandanceCheck_UserId",
                table: "AttandanceCheck",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AttandanceCheck_UserId1",
                table: "AttandanceCheck",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_AttandanceDetailsDetails_UserId",
                table: "AttandanceDetailsDetails",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AttandanceUser_RoleID",
                table: "AttandanceUser",
                column: "RoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttandanceCheck");

            migrationBuilder.DropTable(
                name: "AttandanceDetailsDetails");

            migrationBuilder.DropTable(
                name: "AttandanceUser");

            migrationBuilder.DropTable(
                name: "AttandanceTable");
        }
    }
}
