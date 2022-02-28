using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskTrackerWebApi.Migrations
{
    public partial class TaskTracker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CompletionDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: false),
                    Status = table.Column<string>(type: "varchar(64)", unicode: false, maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "varchar(1028)", unicode: false, maxLength: 1028, nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: true),
                    Project_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Task__Project_id__5EBF139D",
                        column: x => x.Project_id,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Task_Project_id",
                table: "Task",
                column: "Project_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
