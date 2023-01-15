using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Database.Sql.Migrations
{
    /// <inheritdoc />
    public partial class todolistmig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Priority",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priority", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTimeCreation = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    PriorityId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Task_Priority_PriorityId",
                        column: x => x.PriorityId,
                        principalSchema: "dbo",
                        principalTable: "Priority",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Task_Status_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "dbo",
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Task_PriorityId",
                schema: "dbo",
                table: "Task",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_StatusId",
                schema: "dbo",
                table: "Task",
                column: "StatusId");

            migrationBuilder.InsertData("Priority", new string[] {"Id", "Type"}, new object[] { 1, "Critical" }, "dbo");
            migrationBuilder.InsertData("Priority", new string[] { "Id", "Type" }, new object[] { 2, "High" }, "dbo");
            migrationBuilder.InsertData("Priority", new string[] { "Id", "Type" }, new object[] { 3, "Medium" }, "dbo");
            migrationBuilder.InsertData("Priority", new string[] { "Id", "Type" }, new object[] { 4, "Low" }, "dbo");
            
            migrationBuilder.InsertData("Status", new string[] { "Id", "Type" }, new object[] { 1, "New" }, "dbo");
            migrationBuilder.InsertData("Status", new string[] { "Id", "Type" }, new object[] { 2, "InProgress" }, "dbo");
            migrationBuilder.InsertData("Status", new string[] { "Id", "Type" }, new object[] { 3, "Done" }, "dbo");
            migrationBuilder.InsertData("Status", new string[] { "Id", "Type" }, new object[] { 4, "Removed" }, "dbo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Task",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Priority",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Status",
                schema: "dbo");
        }
    }
}
