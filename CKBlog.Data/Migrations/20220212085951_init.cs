using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CKBlog.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 14, 13, 20, 49, 442, DateTimeKind.Local).AddTicks(7740), new DateTime(2021, 12, 14, 13, 20, 49, 442, DateTimeKind.Local).AddTicks(7985) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 14, 13, 20, 49, 442, DateTimeKind.Local).AddTicks(8620), new DateTime(2021, 12, 14, 13, 20, 49, 442, DateTimeKind.Local).AddTicks(8621) });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "99a27df5-1c2d-4a41-a825-a805b17bfc0f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "898fb280-49ae-4a9b-ade9-16ff32972c64");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "3eeb341d-5658-47f1-bb4d-01519e65ce75");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "330b1609-b23d-4ea0-9436-709f79101534");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fad0b6df-f3da-4f89-be12-7dfc72f5209a", "AQAAAAEAACcQAAAAEN25u36wuY6w1xCGqWZ7RaPSugaB99M7y0BMT3ryhd8C7+TE0zXFfnPWX0wcYUB3Dg==", "1aad82aa-1438-4801-ac62-e6efd68a59f9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b794bfb0-5814-4583-bde2-bc15465b385f", "AQAAAAEAACcQAAAAEI59xwYctmeNT5rmGK/gB2mJbjgwybthhQVxfa60ql+cPfPYyGz3cQ5ktHvh1y2Djg==", "6c5cc371-3cd3-4c91-81c9-8b6ab2a74436" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 14, 13, 20, 49, 444, DateTimeKind.Local).AddTicks(6556), new DateTime(2021, 12, 14, 13, 20, 49, 444, DateTimeKind.Local).AddTicks(6563) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2021, 12, 14, 13, 20, 49, 444, DateTimeKind.Local).AddTicks(6574), new DateTime(2021, 12, 14, 13, 20, 49, 444, DateTimeKind.Local).AddTicks(6575) });
        }
    }
}
