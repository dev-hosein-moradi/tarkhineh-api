using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class initial_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblAddress",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAddress", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "TblAgent",
                columns: table => new
                {
                    AgentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAgent", x => x.AgentId);
                });

            migrationBuilder.CreateTable(
                name: "TblBranch",
                columns: table => new
                {
                    BranchId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OwnerFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerNatCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerRegion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaceArea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PalceAge = table.Column<int>(type: "int", nullable: false),
                    Verification = table.Column<bool>(type: "bit", nullable: false),
                    Kitchen = table.Column<bool>(type: "bit", nullable: false),
                    Parking = table.Column<bool>(type: "bit", nullable: false),
                    Store = table.Column<bool>(type: "bit", nullable: false),
                    WorkingTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tel2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblBranch", x => x.BranchId);
                });

            migrationBuilder.CreateTable(
                name: "TblCart",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodID = table.Column<int>(type: "int", nullable: false),
                    DeliveryID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCart", x => x.CartId);
                });

            migrationBuilder.CreateTable(
                name: "TblCustomer",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCustomer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "TblDelivery",
                columns: table => new
                {
                    DeliveryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    AddressID = table.Column<int>(type: "int", nullable: false),
                    AgentID = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinishDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SendType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SendPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuesDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblDelivery", x => x.DeliveryId);
                });

            migrationBuilder.CreateTable(
                name: "TblFood",
                columns: table => new
                {
                    FoodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RateStar = table.Column<int>(type: "int", nullable: false),
                    MainPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountPercent = table.Column<int>(type: "int", nullable: false),
                    Favorite = table.Column<bool>(type: "bit", nullable: false),
                    Score = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BranchID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblFood", x => x.FoodId);
                });

            migrationBuilder.CreateTable(
                name: "TblOrder",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblOrder", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "TblPayment",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPayment", x => x.PaymentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblAddress");

            migrationBuilder.DropTable(
                name: "TblAgent");

            migrationBuilder.DropTable(
                name: "TblBranch");

            migrationBuilder.DropTable(
                name: "TblCart");

            migrationBuilder.DropTable(
                name: "TblCustomer");

            migrationBuilder.DropTable(
                name: "TblDelivery");

            migrationBuilder.DropTable(
                name: "TblFood");

            migrationBuilder.DropTable(
                name: "TblOrder");

            migrationBuilder.DropTable(
                name: "TblPayment");
        }
    }
}
