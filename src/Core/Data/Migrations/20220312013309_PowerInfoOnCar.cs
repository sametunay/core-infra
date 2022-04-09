using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class PowerInfoOnCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PowerInfo_Engine_CylinderVolume",
                table: "Cars",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PowerInfo_Engine_MaxPower",
                table: "Cars",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PowerInfo_Engine_MaxTorque",
                table: "Cars",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PowerInfo_Engine_Transmission",
                table: "Cars",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PowerInfo_Engine_Type",
                table: "Cars",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "PowerInfo_MaxSpeed",
                table: "Cars",
                type: "smallint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PowerInfo_Engine_CylinderVolume",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "PowerInfo_Engine_MaxPower",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "PowerInfo_Engine_MaxTorque",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "PowerInfo_Engine_Transmission",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "PowerInfo_Engine_Type",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "PowerInfo_MaxSpeed",
                table: "Cars");
        }
    }
}
