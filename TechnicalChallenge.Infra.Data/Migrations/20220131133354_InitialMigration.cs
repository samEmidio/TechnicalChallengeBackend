using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnicalChallenge.Infra.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "technical_challenge_event",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    date = table.Column<string>(type: "varchar(255)", nullable: false),
                    description = table.Column<string>(type: "varchar(255)", nullable: false),
                    additional_information = table.Column<string>(type: "varchar(255)", nullable: true),
                    create = table.Column<DateTime>(type: "date", nullable: false),
                    created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    update = table.Column<DateTime>(type: "date", nullable: true),
                    updated_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_technical_challenge_event", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "technical_challenge_user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", nullable: false),
                    last_name = table.Column<string>(type: "varchar(255)", nullable: false),
                    email = table.Column<string>(type: "varchar(255)", nullable: false),
                    password = table.Column<string>(type: "varchar(50)", nullable: false),
                    create = table.Column<DateTime>(type: "date", nullable: false),
                    created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    update = table.Column<DateTime>(type: "date", nullable: true),
                    updated_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_technical_challenge_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "technical_challenge_event_user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    event_id = table.Column<Guid>(type: "UniqueIdentifier", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", nullable: false),
                    value = table.Column<double>(type: "float", nullable: false),
                    is_paid = table.Column<bool>(type: "bit", nullable: false),
                    create = table.Column<DateTime>(type: "date", nullable: false),
                    created_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    update = table.Column<DateTime>(type: "date", nullable: true),
                    updated_by = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_technical_challenge_event_user", x => x.id);
                    table.ForeignKey(
                        name: "FK_technical_challenge_event_user_technical_challenge_event_event_id",
                        column: x => x.event_id,
                        principalTable: "technical_challenge_event",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_technical_challenge_event_user_event_id",
                table: "technical_challenge_event_user",
                column: "event_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "technical_challenge_event_user");

            migrationBuilder.DropTable(
                name: "technical_challenge_user");

            migrationBuilder.DropTable(
                name: "technical_challenge_event");
        }
    }
}
