using Microsoft.EntityFrameworkCore.Migrations;

namespace OngProject.Infrastructure.Data.Migrations
{
    public partial class UserRoleSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c7b013f0-5201-4317-abd8-c211f91b7330", "3", null, "Admin", "Admin" },
                    { "c7b013f0-5201-4317-abd8-c211f91b7033", "4", null, "Common", "Common" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Photo", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "b74ddd14-6340-4840-95c2-db1255484337", 0, "1188e1d3-cc82-48d4-bfef-9f2969ea8a22", "mail37@mail.com", false, "User 37", false, "LastName 37", false, null, "mail37@mail.com", null, "AQAAAAEAACcQAAAAEGj/FgoDzxxZfZUxYm8it7dcBcDlZ5hw+L7P1tvnE+k5FbMVG+H9MaeBk5PQpjfNvw==", "No Available", false, null, "44c2a0fb-b4ad-4920-8d45-e6e62c290b1f", false, "User 37" },
                    { "b74ddd14-6340-4840-95c2-db1255484336", 0, "dfa1100b-69fe-4813-895b-42b1ba2a6227", "mail36@mail.com", false, "User 36", false, "LastName 36", false, null, "mail36@mail.com", null, "AQAAAAEAACcQAAAAEL/526DUVkwPd1AKlvDF/OB3EFHtFdXsq1Z3d2hBHgQbPy34SFvioYdEBXsaA44NNg==", "No Available", false, null, "94741c65-5580-454a-a27b-a1bfc782e519", false, "User 36" },
                    { "b74ddd14-6340-4840-95c2-db1255484335", 0, "7a787ac9-d836-4b9b-86df-ec0a0fb03e94", "mail35@mail.com", false, "User 35", false, "LastName 35", false, null, "mail35@mail.com", null, "AQAAAAEAACcQAAAAEFUS3L10tMyTuiJsBlD0VarOTM1P/yTt5HxJMsjhKi6VipYWKRvIR0PRuYQ7YEP2eg==", "No Available", false, null, "5bfa64e3-2472-47a7-b296-0ed9a37053c0", false, "User 35" },
                    { "b74ddd14-6340-4840-95c2-db1255484334", 0, "d2f520b3-40c1-4769-99cc-75fe9bb04e96", "mail34@mail.com", false, "User 34", false, "LastName 34", false, null, "mail34@mail.com", null, "AQAAAAEAACcQAAAAEBu47XmDr8MelfLnPqlw2uklvPYLgHj5frKOhRwnWWXWiLoGOVakEpkm1d98G/8Vmw==", "No Available", false, null, "c9689bab-bcd5-4075-82e6-3a4ac0762572", false, "User 34" },
                    { "b74ddd14-6340-4840-95c2-db1255484333", 0, "c59b6729-d14c-4612-b604-aaa8caffaad9", "mail33@mail.com", false, "User 33", false, "LastName 33", false, null, "mail33@mail.com", null, "AQAAAAEAACcQAAAAEP78cb5OIvPYb+tnuDl3+8FBPGdJKyoA2eJlH4pQTTBbSPTjrDCmR3GGvsXvzX63rw==", "No Available", false, null, "6e0dd3eb-9ba5-46f1-9d4d-fe176c0308a1", false, "User 33" },
                    { "b74ddd14-6340-4840-95c2-db1255484332", 0, "3aef7b02-fd73-42ae-ab63-0af1f64fd9a4", "mail32@mail.com", false, "User 32", false, "LastName 32", false, null, "mail32@mail.com", null, "AQAAAAEAACcQAAAAEL8HuB1ORnrHOmmn5AHGus5OYORzG/6ibpZF/KU3bhgBlve0rq+6yH0rJSkHnOD6Ww==", "No Available", false, null, "4e2f357e-e40f-49a8-be0e-de2948f79336", false, "User 32" },
                    { "b74ddd14-6340-4840-95c2-db1255484331", 0, "dd71c028-4c43-4453-9cac-23851835542f", "mail31@mail.com", false, "User 31", false, "LastName 31", false, null, "mail31@mail.com", null, "AQAAAAEAACcQAAAAEMA9G4c+ttqRhuItGFgbXbwurKy4dxGf/8NDAldQpNxop8QMwp2z6zMT1nWnjjhrYg==", "No Available", false, null, "f26d849d-ac95-4589-adba-e3f978fd4a9a", false, "User 31" },
                    { "b74ddd14-6340-4840-95c2-db1255484330", 0, "399e5ae5-262e-407f-9e16-6d79f7d1e977", "mail30@mail.com", false, "User 30", false, "LastName 30", false, null, "mail30@mail.com", null, "AQAAAAEAACcQAAAAEK3HMA1wexXvQ+FMCXdb2gwiirpLsdu3zah83AUOM/l2tR7r+Vys3FTS+v/kxfM06g==", "No Available", false, null, "d850fa49-f0fb-4f07-ad11-dabeac389474", false, "User 30" },
                    { "b74ddd14-6340-4840-95c2-db1255484319", 0, "e9704707-caca-4688-aad2-e67937298589", "mail19@mail.com", false, "User 19", false, "LastName 19", false, null, "mail19@mail.com", null, "AQAAAAEAACcQAAAAELkEiChvvwRniEDyNuKF3ELlcNVyXDqwl7Wqr4d5jQabbsz0/GKj7O8dF6yyc0kltQ==", "No Available", false, null, "7a0d4fc8-d861-447e-b8b0-5d424ce8a265", false, "User 19" },
                    { "b74ddd14-6340-4840-95c2-db1255484318", 0, "2ed58c08-1bf2-47dd-885c-d477cde83113", "mail18@mail.com", false, "User 18", false, "LastName 18", false, null, "mail18@mail.com", null, "AQAAAAEAACcQAAAAEKxLsJE9SoOHHIWCks9YsN/+m2avQPJ6eUgE0UQO09lpy/FG4T3dr61GHZdxb6DdvA==", "No Available", false, null, "4e14e9f2-2beb-425a-bde5-7e3da382497d", false, "User 18" },
                    { "b74ddd14-6340-4840-95c2-db1255484317", 0, "8ad0b51d-d55e-4206-b3c1-380ecce99e17", "mail17@mail.com", false, "User 17", false, "LastName 17", false, null, "mail17@mail.com", null, "AQAAAAEAACcQAAAAELLn4tMuN30emgqLqO/y3ZAufCaWm+V118VeU4aKlsgWl1CGnYu7ry/xUWprDhK2OA==", "No Available", false, null, "82d4610f-9d75-44cf-a4de-f52527c47728", false, "User 17" },
                    { "b74ddd14-6340-4840-95c2-db1255484316", 0, "53f809a5-8f82-4d5b-8aa5-6306ff827756", "mail16@mail.com", false, "User 16", false, "LastName 16", false, null, "mail16@mail.com", null, "AQAAAAEAACcQAAAAEBV4FtKAhxyQveaH6EJhpUXSgeGfnR6owNr9d9wc0Vbdq2ucfdRMQ78F35fx4bgadQ==", "No Available", false, null, "867fed5b-c578-4fe3-9848-5ad8b06ee58b", false, "User 16" },
                    { "b74ddd14-6340-4840-95c2-db1255484315", 0, "8c344daa-d51c-4845-9ec6-fcc7500ea6e0", "mail15@mail.com", false, "User 15", false, "LastName 15", false, null, "mail15@mail.com", null, "AQAAAAEAACcQAAAAEBJ3G5EMhd6/X5t9DrZqDZZun1fjYKPVe5rrMbgmfBdORgUfNuIGawR/mKHwf9CX0w==", "No Available", false, null, "77c2be2c-fd1f-4519-8170-daa7f7a2460e", false, "User 15" },
                    { "b74ddd14-6340-4840-95c2-db1255484314", 0, "068f82c3-8e43-481f-b88d-08784da0ae04", "mail14@mail.com", false, "User 14", false, "LastName 14", false, null, "mail14@mail.com", null, "AQAAAAEAACcQAAAAEFE7SyL75rLEpBrXzeJo0zl6QzDntsZo20vE34aMjTBwYQXcr3Iz7cvId/TDAqj8Og==", "No Available", false, null, "a0748b59-7a2a-4283-953f-74bd4f259afb", false, "User 14" },
                    { "b74ddd14-6340-4840-95c2-db1255484313", 0, "2cd1ed71-4a9d-462a-b764-e6ff93709838", "mail13@mail.com", false, "User 13", false, "LastName 13", false, null, "mail13@mail.com", null, "AQAAAAEAACcQAAAAEEYHvp1UQQiwQLQ6DR+aaBOTIwB+PmGmWmMxZTrR57D8ltea5RQ62ahL+TOYrMtVZg==", "No Available", false, null, "51bd39e9-2d21-4ad7-b763-050e3336b944", false, "User 13" },
                    { "b74ddd14-6340-4840-95c2-db1255484312", 0, "dea823d7-6103-474e-b1d0-77fa5860a9a8", "mail12@mail.com", false, "User 12", false, "LastName 12", false, null, "mail12@mail.com", null, "AQAAAAEAACcQAAAAEE6KShzOeSAhYdPlgtciteZS8MTcdKi3CQNjztNsboluNBHuFpDRjijp9ruoiGntZw==", "No Available", false, null, "ff383dba-819f-4863-887e-b6197a467c01", false, "User 12" },
                    { "b74ddd14-6340-4840-95c2-db1255484311", 0, "bb903d69-7949-49c1-b1e3-fccbe1f32bb4", "mail11@mail.com", false, "User 11", false, "LastName 11", false, null, "mail11@mail.com", null, "AQAAAAEAACcQAAAAEAs2KH6ISy4dq9N39yEaYj8oYXW92wurOOKXcFS3FBQgR7XE3IHYs8zgD2P+4SApwg==", "No Available", false, null, "1aaecce6-bad8-4fbb-bf7d-7eabbdf609d4", false, "User 11" },
                    { "b74ddd14-6340-4840-95c2-db1255484310", 0, "780308a0-808d-4707-9314-329138961afe", "mail10@mail.com", false, "User 10", false, "LastName 10", false, null, "mail10@mail.com", null, "AQAAAAEAACcQAAAAEEFVxwPtFa8Nklo8puS7IfV8fSstBuZ4wr1kBrObxXzFTisdKmSleB34vU3ju7vySg==", "No Available", false, null, "b83bf0d5-126e-4182-8d11-03d5f6283f26", false, "User 10" },
                    { "b74ddd14-6340-4840-95c2-db1255484338", 0, "5d094b1c-01f9-4daf-baf2-181c2b4762bd", "mail38@mail.com", false, "User 38", false, "LastName 38", false, null, "mail38@mail.com", null, "AQAAAAEAACcQAAAAEDnp2xc9JlciwJD8tjme3Q/Ebt5o/se+iWjqTwM7JvRm4qanA7P31dqXflDFnau8xg==", "No Available", false, null, "54fef47d-c807-4a9e-a3df-9613dac409d0", false, "User 38" },
                    { "b74ddd14-6340-4840-95c2-db1255484339", 0, "d0037b09-3ed6-43a6-b2c0-18a94de86a54", "mail39@mail.com", false, "User 39", false, "LastName 39", false, null, "mail39@mail.com", null, "AQAAAAEAACcQAAAAEL8+6wZqvYsrAf5RTM8mRSdyrZCVk/LNqGtQ/gUfzuUthtL+mMS8ZlW2IqXylVa8tQ==", "No Available", false, null, "04360e04-d150-41b8-af26-9d34e94f785a", false, "User 39" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c7b013f0-5201-4317-abd8-c211f91b7330", "b74ddd14-6340-4840-95c2-db1255484310" },
                    { "c7b013f0-5201-4317-abd8-c211f91b7033", "b74ddd14-6340-4840-95c2-db1255484337" },
                    { "c7b013f0-5201-4317-abd8-c211f91b7033", "b74ddd14-6340-4840-95c2-db1255484336" },
                    { "c7b013f0-5201-4317-abd8-c211f91b7033", "b74ddd14-6340-4840-95c2-db1255484335" },
                    { "c7b013f0-5201-4317-abd8-c211f91b7033", "b74ddd14-6340-4840-95c2-db1255484334" },
                    { "c7b013f0-5201-4317-abd8-c211f91b7033", "b74ddd14-6340-4840-95c2-db1255484333" },
                    { "c7b013f0-5201-4317-abd8-c211f91b7033", "b74ddd14-6340-4840-95c2-db1255484332" },
                    { "c7b013f0-5201-4317-abd8-c211f91b7033", "b74ddd14-6340-4840-95c2-db1255484331" },
                    { "c7b013f0-5201-4317-abd8-c211f91b7033", "b74ddd14-6340-4840-95c2-db1255484330" },
                    { "c7b013f0-5201-4317-abd8-c211f91b7330", "b74ddd14-6340-4840-95c2-db1255484319" },
                    { "c7b013f0-5201-4317-abd8-c211f91b7330", "b74ddd14-6340-4840-95c2-db1255484318" },
                    { "c7b013f0-5201-4317-abd8-c211f91b7330", "b74ddd14-6340-4840-95c2-db1255484317" },
                    { "c7b013f0-5201-4317-abd8-c211f91b7330", "b74ddd14-6340-4840-95c2-db1255484316" },
                    { "c7b013f0-5201-4317-abd8-c211f91b7330", "b74ddd14-6340-4840-95c2-db1255484315" },
                    { "c7b013f0-5201-4317-abd8-c211f91b7330", "b74ddd14-6340-4840-95c2-db1255484314" },
                    { "c7b013f0-5201-4317-abd8-c211f91b7330", "b74ddd14-6340-4840-95c2-db1255484313" },
                    { "c7b013f0-5201-4317-abd8-c211f91b7330", "b74ddd14-6340-4840-95c2-db1255484312" },
                    { "c7b013f0-5201-4317-abd8-c211f91b7330", "b74ddd14-6340-4840-95c2-db1255484311" },
                    { "c7b013f0-5201-4317-abd8-c211f91b7033", "b74ddd14-6340-4840-95c2-db1255484338" },
                    { "c7b013f0-5201-4317-abd8-c211f91b7033", "b74ddd14-6340-4840-95c2-db1255484339" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7b013f0-5201-4317-abd8-c211f91b7330", "b74ddd14-6340-4840-95c2-db1255484310" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7b013f0-5201-4317-abd8-c211f91b7330", "b74ddd14-6340-4840-95c2-db1255484311" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7b013f0-5201-4317-abd8-c211f91b7330", "b74ddd14-6340-4840-95c2-db1255484312" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7b013f0-5201-4317-abd8-c211f91b7330", "b74ddd14-6340-4840-95c2-db1255484313" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7b013f0-5201-4317-abd8-c211f91b7330", "b74ddd14-6340-4840-95c2-db1255484314" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7b013f0-5201-4317-abd8-c211f91b7330", "b74ddd14-6340-4840-95c2-db1255484315" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7b013f0-5201-4317-abd8-c211f91b7330", "b74ddd14-6340-4840-95c2-db1255484316" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7b013f0-5201-4317-abd8-c211f91b7330", "b74ddd14-6340-4840-95c2-db1255484317" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7b013f0-5201-4317-abd8-c211f91b7330", "b74ddd14-6340-4840-95c2-db1255484318" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7b013f0-5201-4317-abd8-c211f91b7330", "b74ddd14-6340-4840-95c2-db1255484319" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7b013f0-5201-4317-abd8-c211f91b7033", "b74ddd14-6340-4840-95c2-db1255484330" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7b013f0-5201-4317-abd8-c211f91b7033", "b74ddd14-6340-4840-95c2-db1255484331" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7b013f0-5201-4317-abd8-c211f91b7033", "b74ddd14-6340-4840-95c2-db1255484332" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7b013f0-5201-4317-abd8-c211f91b7033", "b74ddd14-6340-4840-95c2-db1255484333" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7b013f0-5201-4317-abd8-c211f91b7033", "b74ddd14-6340-4840-95c2-db1255484334" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7b013f0-5201-4317-abd8-c211f91b7033", "b74ddd14-6340-4840-95c2-db1255484335" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7b013f0-5201-4317-abd8-c211f91b7033", "b74ddd14-6340-4840-95c2-db1255484336" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7b013f0-5201-4317-abd8-c211f91b7033", "b74ddd14-6340-4840-95c2-db1255484337" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7b013f0-5201-4317-abd8-c211f91b7033", "b74ddd14-6340-4840-95c2-db1255484338" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7b013f0-5201-4317-abd8-c211f91b7033", "b74ddd14-6340-4840-95c2-db1255484339" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7b013f0-5201-4317-abd8-c211f91b7033");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7b013f0-5201-4317-abd8-c211f91b7330");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db1255484310");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db1255484311");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db1255484312");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db1255484313");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db1255484314");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db1255484315");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db1255484316");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db1255484317");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db1255484318");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db1255484319");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db1255484330");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db1255484331");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db1255484332");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db1255484333");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db1255484334");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db1255484335");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db1255484336");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db1255484337");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db1255484338");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db1255484339");
        }
    }
}
