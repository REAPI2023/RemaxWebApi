using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RemaxWebApi.Migrations
{
    /// <inheritdoc />
    public partial class Create_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Property");

            migrationBuilder.CreateTable(
                name: "CommercialProperty",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuperBuiltUpArea = table.Column<double>(type: "float", nullable: false),
                    CarpetArea = table.Column<double>(type: "float", nullable: false),
                    ContractType = table.Column<int>(type: "int", nullable: false),
                    Maintenance = table.Column<double>(type: "float", nullable: false),
                    SecurityDeposit = table.Column<double>(type: "float", nullable: false),
                    PantryAvailable = table.Column<bool>(type: "bit", nullable: false),
                    NoOfCabins = table.Column<int>(type: "int", nullable: false),
                    NoOfWashRooms = table.Column<int>(type: "int", nullable: false),
                    NoOfWorkStations = table.Column<int>(type: "int", nullable: false),
                    LockInPeriod = table.Column<int>(type: "int", nullable: false),
                    FloorDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Facility = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Facing = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amenities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoOfCarParkings = table.Column<int>(type: "int", nullable: false),
                    Pictures = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FurnishedStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AskingPrice = table.Column<double>(type: "float", nullable: false),
                    FinalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommercialProperty", x => x.PropertyId);
                });

            migrationBuilder.CreateTable(
                name: "ResidentialProperty",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoOfBeds = table.Column<int>(type: "int", nullable: false),
                    NoOfBathRooms = table.Column<int>(type: "int", nullable: false),
                    NoOfBalcony = table.Column<int>(type: "int", nullable: false),
                    Dimention = table.Column<double>(type: "float", nullable: false),
                    FlatFloor = table.Column<int>(type: "int", nullable: false),
                    TotalFloors = table.Column<int>(type: "int", nullable: false),
                    NoOfFlatsInAFloor = table.Column<int>(type: "int", nullable: false),
                    PropertyAge = table.Column<int>(type: "int", nullable: false),
                    NoOfLifts = table.Column<int>(type: "int", nullable: false),
                    PropertyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Facility = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Facing = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amenities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoOfCarParkings = table.Column<int>(type: "int", nullable: false),
                    Pictures = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FurnishedStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AskingPrice = table.Column<double>(type: "float", nullable: false),
                    FinalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialProperty", x => x.PropertyId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommercialProperty");

            migrationBuilder.DropTable(
                name: "ResidentialProperty");

            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Facility = table.Column<int>(type: "int", nullable: true),
                    PropertyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.PropertyId);
                });
        }
    }
}
