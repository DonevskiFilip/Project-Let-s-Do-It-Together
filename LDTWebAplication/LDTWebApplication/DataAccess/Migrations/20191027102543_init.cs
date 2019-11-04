using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserEvents",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    CreatedEventId = table.Column<int>(nullable: false),
                    GoingEventId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEvents", x => new { x.UserId, x.ID });
                    table.UniqueConstraint("AK_UserEvents_ID", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Firstname = table.Column<string>(nullable: false),
                    Lastname = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    EventId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventName = table.Column<string>(nullable: false),
                    EventLocation = table.Column<string>(nullable: false),
                    EventStart = table.Column<string>(nullable: false),
                    EventDuration = table.Column<int>(nullable: false),
                    EventOpenPleaces = table.Column<int>(nullable: true),
                    EventDiscription = table.Column<string>(nullable: false),
                    EventType = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Address", "City", "Country", "DateOfBirth", "Email", "EventId", "Firstname", "Lastname", "Password", "Username" },
                values: new object[] { 1, "Mirce Acev18", "Kumanovo", "Macedonia", "12.12.1990", "filip.Donevski1@gmail.com", null, "Filip", "Donevski", "Done123", "Done" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Address", "City", "Country", "DateOfBirth", "Email", "EventId", "Firstname", "Lastname", "Password", "Username" },
                values: new object[] { 2, "Mirce Acev18", "Kumanovo", "Macedonia", "12.12.1990", "Niakolin.Donevskia@gmail.com", null, "Nikolina", "Donevska", "Nane123", "Nane" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "EventDiscription", "EventDuration", "EventLocation", "EventName", "EventOpenPleaces", "EventStart", "EventType", "UserId" },
                values: new object[,]
                {
                    { 1, "Race to the top of the mountain Vodno, with price pool for first, second and third place.", 12, "Kumanovo", "Ture De Kumanovo", 54, "24.12.2019", 4, 1 },
                    { 2, "Race to the top of the mountain Vodno, with price pool for first, second and third place.", 12, "Skopje", "Skopje De Kumanovo", 54, "12.12.2019", 5, 2 }
                });

            migrationBuilder.InsertData(
                table: "UserEvents",
                columns: new[] { "UserId", "ID", "CreatedEventId", "EventId", "GoingEventId" },
                values: new object[,]
                {
                    { 1, 1, 1, null, 0 },
                    { 1, 2, 0, null, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_UserId",
                table: "Events",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEvents_EventId",
                table: "UserEvents",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EventId",
                table: "Users",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEvents_Users_UserId",
                table: "UserEvents",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEvents_Events_EventId",
                table: "UserEvents",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Events_EventId",
                table: "Users",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Users_UserId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "UserEvents");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
