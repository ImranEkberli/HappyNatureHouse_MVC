using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HappyNatureHouse_MVC.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cottages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomCount = table.Column<int>(type: "int", nullable: false),
                    GuestCount = table.Column<int>(type: "int", nullable: false),
                    SingleBed = table.Column<int>(type: "int", nullable: false),
                    DoubleBed = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifierDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cottages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CottageRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CottageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CottageRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CottageRooms_Cottages_CottageId",
                        column: x => x.CottageId,
                        principalTable: "Cottages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CottageImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CottageId = table.Column<int>(type: "int", nullable: false),
                    CottageRoomId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CottageImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CottageImages_CottageRooms_CottageRoomId",
                        column: x => x.CottageRoomId,
                        principalTable: "CottageRooms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CottageImages_Cottages_CottageId",
                        column: x => x.CottageId,
                        principalTable: "Cottages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CottageImages_CottageId",
                table: "CottageImages",
                column: "CottageId");

            migrationBuilder.CreateIndex(
                name: "IX_CottageImages_CottageRoomId",
                table: "CottageImages",
                column: "CottageRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_CottageRooms_CottageId",
                table: "CottageRooms",
                column: "CottageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CottageImages");

            migrationBuilder.DropTable(
                name: "CottageRooms");

            migrationBuilder.DropTable(
                name: "Cottages");
        }
    }
}
