using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class AddCreatedDateProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedDate",
                table: "TblPayment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedDate",
                table: "TblOrder",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedDate",
                table: "TblFood",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedDate",
                table: "TblDelivery",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedDate",
                table: "TblCustomer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedDate",
                table: "TblCart",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedDate",
                table: "TblBranch",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedDate",
                table: "TblAgent",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedDate",
                table: "TblAddress",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TblPayment");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TblOrder");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TblFood");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TblDelivery");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TblCustomer");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TblCart");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TblBranch");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TblAgent");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TblAddress");
        }
    }
}
