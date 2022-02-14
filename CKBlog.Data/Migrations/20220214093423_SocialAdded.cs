using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CKBlog.Data.Migrations
{
    public partial class SocialAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SocialMedias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Link = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedias", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 14, 12, 34, 22, 712, DateTimeKind.Local).AddTicks(5920), new DateTime(2022, 2, 14, 12, 34, 22, 712, DateTimeKind.Local).AddTicks(6159) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 14, 12, 34, 22, 712, DateTimeKind.Local).AddTicks(7175), new DateTime(2022, 2, 14, 12, 34, 22, 712, DateTimeKind.Local).AddTicks(7176) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "40b6bac3-664c-48c3-b85e-3b253f7048ce");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "ab81cf22-2cc0-4b60-8065-49c4f9f2ebfb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "8206091e-af03-436d-b546-9eb32ebcf8ce");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "2244eb81-7b4c-4b0a-856b-64f5e18dcb6c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "054e8e85-9b99-4b37-845d-2538d73a6114", "AQAAAAEAACcQAAAAEEgWrTDvpAk4hGHj/RDyPumP6wX+gJoNoXw0Y4775yc6cl0Xom32ArK4xDUGXw4kYw==", "512fe2fc-6fb2-413c-b44c-840aeb3e6685" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f13250b0-b84c-4bbd-b267-21bcc4f40bb7", "AQAAAAEAACcQAAAAEG8lDGrddSnCrGW5HscpJg3o8M8DqLpAzf4pqYu/ddApnyq7ARmgRzfUAG0TAGtgBQ==", "645c7fc0-79b7-4c00-9978-418ca0ca089f" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 14, 12, 34, 22, 717, DateTimeKind.Local).AddTicks(8030), new DateTime(2022, 2, 14, 12, 34, 22, 717, DateTimeKind.Local).AddTicks(8036) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 14, 12, 34, 22, 717, DateTimeKind.Local).AddTicks(8054), new DateTime(2022, 2, 14, 12, 34, 22, 717, DateTimeKind.Local).AddTicks(8055) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocialMedias");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 12, 11, 59, 51, 490, DateTimeKind.Local).AddTicks(2653), new DateTime(2022, 2, 12, 11, 59, 51, 490, DateTimeKind.Local).AddTicks(2892) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 12, 11, 59, 51, 490, DateTimeKind.Local).AddTicks(3482), new DateTime(2022, 2, 12, 11, 59, 51, 490, DateTimeKind.Local).AddTicks(3483) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "ab236a0d-5bf3-414c-b4fc-0c015db6dc62");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "c9d39be9-b93d-485b-86c4-a860b2915d6c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "46b53d60-6825-44f5-8322-7b0473ffa04e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "9bee8c75-911e-4b86-bff4-10b6b7726640");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9fa9dd32-9cba-4597-9a92-817bcc0f0463", "AQAAAAEAACcQAAAAEIXWT56FDK3wk06idlN7PXx+9fpZJYvJjsANV4I594cLfSBJpA3eLBjsfZfPDrwHow==", "f085e18e-e768-405c-a514-4ff6d048054d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "670cdffc-9e9e-45d2-85c6-a6771e409fad", "AQAAAAEAACcQAAAAEKQk6GraU86cKZxPhm72Hoab7FqN6V86vNOivrEdJnGA39+Q1WrFSs19hhNH9NyNZA==", "d6a6cddc-8661-4ffb-af07-6ccfbc977de0" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 12, 11, 59, 51, 492, DateTimeKind.Local).AddTicks(1645), new DateTime(2022, 2, 12, 11, 59, 51, 492, DateTimeKind.Local).AddTicks(1650) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 2, 12, 11, 59, 51, 492, DateTimeKind.Local).AddTicks(1660), new DateTime(2022, 2, 12, 11, 59, 51, 492, DateTimeKind.Local).AddTicks(1661) });
        }
    }
}
