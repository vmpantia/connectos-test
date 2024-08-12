using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ACME.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialTableAndData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAtUtcNow = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAtUtcNow = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAtUtcNow = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAtUtcNow = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAtUtcNow = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAtUtcNow = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Magazines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAtUtcNow = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAtUtcNow = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAtUtcNow = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magazines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAtUtcNow = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAtUtcNow = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAtUtcNow = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publications_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAtUtcNow = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAtUtcNow = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAtUtcNow = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MagazineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAtUtcNow = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAtUtcNow = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAtUtcNow = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Magazines_MagazineId",
                        column: x => x.MagazineId,
                        principalTable: "Magazines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "CreatedAtUtcNow", "CreatedBy", "DeletedAtUtcNow", "DeletedBy", "Name", "Status", "UpdatedAtUtcNow", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("023e17d9-9a71-a52a-ce57-5cbe8f77846b"), "ET", new DateTimeOffset(new DateTime(2024, 6, 17, 15, 18, 20, 605, DateTimeKind.Unspecified).AddTicks(1766), new TimeSpan(0, 8, 0, 0, 0)), "Irving59@gmail.com", null, null, "United Kingdom", 2, null, null },
                    { new Guid("05f4f98b-bbe4-17e2-bacd-7207ba263526"), "LT", new DateTimeOffset(new DateTime(2024, 2, 13, 8, 58, 39, 519, DateTimeKind.Unspecified).AddTicks(1462), new TimeSpan(0, 8, 0, 0, 0)), "Micheal.Hansen@yahoo.com", null, null, "Holy See (Vatican City State)", 1, null, null },
                    { new Guid("0dfa34ae-0a25-195d-fa9a-f0752d143f5a"), "ES", new DateTimeOffset(new DateTime(2023, 12, 25, 6, 52, 59, 407, DateTimeKind.Unspecified).AddTicks(5733), new TimeSpan(0, 8, 0, 0, 0)), "Emmy65@yahoo.com", null, null, "Estonia", 1, null, null },
                    { new Guid("232b4a2c-bf44-14a8-b3f3-2a72fd2863fa"), "GU", new DateTimeOffset(new DateTime(2024, 6, 5, 19, 45, 57, 129, DateTimeKind.Unspecified).AddTicks(5349), new TimeSpan(0, 8, 0, 0, 0)), "Fredrick.Hyatt@gmail.com", null, null, "Gabon", 2, null, null },
                    { new Guid("2cc8100c-b48d-9752-4355-0e443a99e8dd"), "AS", new DateTimeOffset(new DateTime(2024, 5, 5, 18, 56, 21, 260, DateTimeKind.Unspecified).AddTicks(1796), new TimeSpan(0, 8, 0, 0, 0)), "Susanna_Koelpin@hotmail.com", null, null, "Philippines", 0, null, null },
                    { new Guid("40768e26-cc75-710e-180d-1a8870bbe1fc"), "CR", new DateTimeOffset(new DateTime(2023, 10, 19, 15, 4, 53, 283, DateTimeKind.Unspecified).AddTicks(7794), new TimeSpan(0, 8, 0, 0, 0)), "Vernie21@hotmail.com", null, null, "Montenegro", 1, null, null },
                    { new Guid("7822f9f4-31c0-1b5d-339b-52f0c2440a4d"), "IM", new DateTimeOffset(new DateTime(2024, 7, 31, 4, 15, 1, 163, DateTimeKind.Unspecified).AddTicks(5983), new TimeSpan(0, 8, 0, 0, 0)), "Rosemarie.Crist96@gmail.com", null, null, "Seychelles", 0, null, null },
                    { new Guid("9164ccb8-2c87-f6d1-e697-a7b3501651a8"), "MW", new DateTimeOffset(new DateTime(2023, 9, 19, 2, 59, 46, 983, DateTimeKind.Unspecified).AddTicks(3233), new TimeSpan(0, 8, 0, 0, 0)), "Esteban_Mayert83@hotmail.com", null, null, "Reunion", 2, null, null },
                    { new Guid("929a5447-ee63-fd54-cab9-9cf05c19cc32"), "IL", new DateTimeOffset(new DateTime(2024, 7, 28, 10, 18, 1, 461, DateTimeKind.Unspecified).AddTicks(162), new TimeSpan(0, 8, 0, 0, 0)), "Zachariah.Schoen98@gmail.com", null, null, "Egypt", 0, null, null },
                    { new Guid("bdcdde7e-ef6d-87ed-0034-20b124997faf"), "BQ", new DateTimeOffset(new DateTime(2023, 9, 19, 16, 13, 24, 354, DateTimeKind.Unspecified).AddTicks(402), new TimeSpan(0, 8, 0, 0, 0)), "Naomie.Jenkins50@hotmail.com", null, null, "Chile", 0, null, null }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedAtUtcNow", "CreatedBy", "DeletedAtUtcNow", "DeletedBy", "Email", "FirstName", "LastName", "MiddleName", "Phone", "Status", "UpdatedAtUtcNow", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("167e109b-f166-aed9-e7d8-b4dde5dc5076"), new DateTimeOffset(new DateTime(2024, 4, 30, 13, 50, 8, 277, DateTimeKind.Unspecified).AddTicks(8296), new TimeSpan(0, 8, 0, 0, 0)), "Genesis.Trantow2@yahoo.com", null, null, "Jordan_Kunde35@hotmail.com", "Jordan", "Kunde", null, "329.454.8603", 0, null, null },
                    { new Guid("18c4807f-b67a-61bd-5b25-87d61b61ad1b"), new DateTimeOffset(new DateTime(2024, 5, 15, 4, 6, 54, 668, DateTimeKind.Unspecified).AddTicks(5492), new TimeSpan(0, 8, 0, 0, 0)), "Frederik.Schamberger@gmail.com", null, null, "Theresa6@yahoo.com", "Theresa", "Cummerata", null, "(243) 368-1971 x0974", 0, null, null },
                    { new Guid("199ff32b-6afc-8120-50a4-6f0691d22300"), new DateTimeOffset(new DateTime(2024, 2, 27, 12, 38, 44, 891, DateTimeKind.Unspecified).AddTicks(7580), new TimeSpan(0, 8, 0, 0, 0)), "Constance_Gerhold@yahoo.com", null, null, "Dwayne97@gmail.com", "Dwayne", "Connelly", null, "1-240-937-7096 x292", 1, null, null },
                    { new Guid("1cdb4e7c-d7cf-3b03-59b3-02ad4b101b73"), new DateTimeOffset(new DateTime(2024, 6, 16, 2, 18, 56, 738, DateTimeKind.Unspecified).AddTicks(8626), new TimeSpan(0, 8, 0, 0, 0)), "Jada92@gmail.com", null, null, "Iris_Bernier93@gmail.com", "Iris", "Bernier", null, "1-994-231-8624 x3774", 1, null, null },
                    { new Guid("209abb0f-0b38-d0a0-c4d9-a9e9777c26b9"), new DateTimeOffset(new DateTime(2024, 1, 4, 6, 39, 54, 923, DateTimeKind.Unspecified).AddTicks(8457), new TimeSpan(0, 8, 0, 0, 0)), "Jakayla_Erdman@hotmail.com", null, null, "Nettie33@hotmail.com", "Nettie", "Gutkowski", null, "754.951.2603 x1638", 1, null, null },
                    { new Guid("27f12e06-fdc7-94bb-ad2b-ad70d70797d0"), new DateTimeOffset(new DateTime(2023, 8, 21, 5, 32, 31, 576, DateTimeKind.Unspecified).AddTicks(8770), new TimeSpan(0, 8, 0, 0, 0)), "Arnold.Kulas@hotmail.com", null, null, "Alfonso_Donnelly61@hotmail.com", "Alfonso", "Donnelly", null, "1-406-644-8787 x22826", 1, null, null },
                    { new Guid("3b6237d7-3571-fa61-6c3e-f9d8379f0bea"), new DateTimeOffset(new DateTime(2024, 3, 16, 6, 11, 1, 944, DateTimeKind.Unspecified).AddTicks(2609), new TimeSpan(0, 8, 0, 0, 0)), "Bertrand18@yahoo.com", null, null, "Timothy9@yahoo.com", "Timothy", "Will", null, "(952) 934-0292", 2, null, null },
                    { new Guid("4394cfcb-be58-5b63-ffdb-ec7f66ae5429"), new DateTimeOffset(new DateTime(2023, 12, 19, 22, 55, 45, 514, DateTimeKind.Unspecified).AddTicks(9329), new TimeSpan(0, 8, 0, 0, 0)), "Rocky.Wolff@yahoo.com", null, null, "Owen_Williamson58@hotmail.com", "Owen", "Williamson", null, "873-529-4916 x60535", 0, null, null },
                    { new Guid("4a3b1021-693e-8246-202d-2056bef26878"), new DateTimeOffset(new DateTime(2024, 5, 6, 16, 32, 58, 405, DateTimeKind.Unspecified).AddTicks(7438), new TimeSpan(0, 8, 0, 0, 0)), "Alfonzo.Schuppe@gmail.com", null, null, "Lester65@hotmail.com", "Lester", "Gottlieb", null, "571.833.5283 x73846", 1, null, null },
                    { new Guid("4ce4bf8b-6ebc-9bf3-ff1a-42572f6a14a5"), new DateTimeOffset(new DateTime(2023, 11, 15, 22, 54, 57, 536, DateTimeKind.Unspecified).AddTicks(9353), new TimeSpan(0, 8, 0, 0, 0)), "Laurine.Hegmann20@gmail.com", null, null, "Jenna_White0@yahoo.com", "Jenna", "White", null, "373-312-5275", 0, null, null },
                    { new Guid("55c85b96-4d6e-7386-21a6-02c675babaa7"), new DateTimeOffset(new DateTime(2024, 5, 30, 9, 30, 34, 918, DateTimeKind.Unspecified).AddTicks(9576), new TimeSpan(0, 8, 0, 0, 0)), "Kali_Emard27@gmail.com", null, null, "Shelley50@yahoo.com", "Shelley", "Franecki", null, "808-629-6348 x9080", 2, null, null },
                    { new Guid("6b634acc-f313-c75a-09bc-dbc5296177d4"), new DateTimeOffset(new DateTime(2024, 3, 25, 16, 36, 5, 309, DateTimeKind.Unspecified).AddTicks(8417), new TimeSpan(0, 8, 0, 0, 0)), "Aric28@yahoo.com", null, null, "Travis_Kuhic@gmail.com", "Travis", "Kuhic", null, "(875) 815-4614 x677", 1, null, null },
                    { new Guid("75537c47-807f-fced-6300-764e0ef57c31"), new DateTimeOffset(new DateTime(2023, 10, 1, 5, 31, 55, 874, DateTimeKind.Unspecified).AddTicks(2648), new TimeSpan(0, 8, 0, 0, 0)), "Bethel.Klein@hotmail.com", null, null, "Doreen0@hotmail.com", "Doreen", "Mueller", null, "(256) 788-5028 x36028", 2, null, null },
                    { new Guid("76e73c2a-0dca-37f0-8f17-35f8a7e7784b"), new DateTimeOffset(new DateTime(2023, 11, 13, 8, 27, 22, 379, DateTimeKind.Unspecified).AddTicks(4366), new TimeSpan(0, 8, 0, 0, 0)), "Guadalupe_Boyer@yahoo.com", null, null, "Dallas80@hotmail.com", "Dallas", "Reilly", null, "970-228-2946 x16141", 0, null, null },
                    { new Guid("7975fd4d-69a4-6e62-4229-8b52c78f0131"), new DateTimeOffset(new DateTime(2023, 11, 13, 11, 39, 41, 158, DateTimeKind.Unspecified).AddTicks(5571), new TimeSpan(0, 8, 0, 0, 0)), "Dock69@hotmail.com", null, null, "Blanca.Hettinger67@gmail.com", "Blanca", "Hettinger", null, "646-642-6083 x25959", 2, null, null },
                    { new Guid("95a21bd4-b409-b5fa-fcdc-25b02cc7d807"), new DateTimeOffset(new DateTime(2023, 10, 9, 18, 28, 15, 460, DateTimeKind.Unspecified).AddTicks(2832), new TimeSpan(0, 8, 0, 0, 0)), "Archibald34@gmail.com", null, null, "Boyd_Wilderman@gmail.com", "Boyd", "Wilderman", null, "(486) 867-9833 x9387", 0, null, null },
                    { new Guid("bf0115c9-d798-29cf-f6c1-68cede86c4a4"), new DateTimeOffset(new DateTime(2024, 1, 6, 15, 15, 51, 750, DateTimeKind.Unspecified).AddTicks(3068), new TimeSpan(0, 8, 0, 0, 0)), "Joshua.Dibbert@gmail.com", null, null, "Shelia.Ankunding60@gmail.com", "Shelia", "Ankunding", null, "244-552-6812 x7368", 1, null, null },
                    { new Guid("daf5e673-765e-4956-7876-5a74c967046d"), new DateTimeOffset(new DateTime(2024, 5, 30, 3, 22, 24, 247, DateTimeKind.Unspecified).AddTicks(4738), new TimeSpan(0, 8, 0, 0, 0)), "Ramona.Fisher45@gmail.com", null, null, "Anita_Kessler@hotmail.com", "Anita", "Kessler", null, "817.310.2177 x7817", 1, null, null },
                    { new Guid("f932b0a7-2115-591f-1dc6-5945d22dea68"), new DateTimeOffset(new DateTime(2023, 12, 1, 6, 20, 57, 726, DateTimeKind.Unspecified).AddTicks(2700), new TimeSpan(0, 8, 0, 0, 0)), "Marcus.Jakubowski30@yahoo.com", null, null, "Scott_Ferry@yahoo.com", "Scott", "Ferry", null, "355-941-5849 x4729", 0, null, null },
                    { new Guid("f9aee77d-22f8-6e91-a828-763fe2b6659c"), new DateTimeOffset(new DateTime(2024, 8, 5, 0, 36, 50, 349, DateTimeKind.Unspecified).AddTicks(3323), new TimeSpan(0, 8, 0, 0, 0)), "Johnathon.Collins@hotmail.com", null, null, "Gary60@yahoo.com", "Gary", "Farrell", null, "1-810-804-7592 x10410", 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "Magazines",
                columns: new[] { "Id", "Code", "CreatedAtUtcNow", "CreatedBy", "DeletedAtUtcNow", "DeletedBy", "Description", "Name", "Status", "UpdatedAtUtcNow", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("02d732b9-a0ba-c380-fd47-72289b799f28"), "Group", new DateTimeOffset(new DateTime(2024, 7, 5, 13, 57, 8, 535, DateTimeKind.Unspecified).AddTicks(1460), new TimeSpan(0, 8, 0, 0, 0)), "Benedict86@hotmail.com", null, null, "Profit-focused cohesive projection", "Dietrich, Bins and Effertz", 0, null, null },
                    { new Guid("03728bdb-5ebd-8a36-05d5-d1210938b333"), "LLC", new DateTimeOffset(new DateTime(2024, 3, 21, 18, 37, 14, 562, DateTimeKind.Unspecified).AddTicks(6431), new TimeSpan(0, 8, 0, 0, 0)), "Serenity96@gmail.com", null, null, "Optimized real-time attitude", "Rodriguez Inc", 0, null, null },
                    { new Guid("038a9bc7-d4c2-90be-aa55-2c17df1d8080"), "LLC", new DateTimeOffset(new DateTime(2023, 12, 14, 23, 21, 46, 149, DateTimeKind.Unspecified).AddTicks(8883), new TimeSpan(0, 8, 0, 0, 0)), "Krista_Shields23@hotmail.com", null, null, "Digitized object-oriented migration", "Russel, Cruickshank and Herzog", 1, null, null },
                    { new Guid("03d6c4b6-f727-9a23-be99-13fb7135799b"), "LLC", new DateTimeOffset(new DateTime(2024, 3, 24, 7, 31, 30, 927, DateTimeKind.Unspecified).AddTicks(2573), new TimeSpan(0, 8, 0, 0, 0)), "Anabel.Rippin23@yahoo.com", null, null, "Managed disintermediate leverage", "Marks LLC", 0, null, null },
                    { new Guid("043c9502-66c2-df63-94d3-77a3424eecf3"), "Inc", new DateTimeOffset(new DateTime(2023, 11, 11, 12, 17, 56, 349, DateTimeKind.Unspecified).AddTicks(3046), new TimeSpan(0, 8, 0, 0, 0)), "Laverne.Powlowski43@gmail.com", null, null, "Innovative local migration", "Schmidt, Champlin and Morissette", 0, null, null },
                    { new Guid("05d7af28-8127-4008-df8b-9f7d3e17f534"), "Group", new DateTimeOffset(new DateTime(2024, 6, 2, 14, 35, 1, 310, DateTimeKind.Unspecified).AddTicks(96), new TimeSpan(0, 8, 0, 0, 0)), "Raegan91@yahoo.com", null, null, "Exclusive high-level complexity", "Waelchi - Hudson", 2, null, null },
                    { new Guid("08a69a9e-e3d2-2d05-9f4a-cc47eb9ff42e"), "Inc", new DateTimeOffset(new DateTime(2023, 11, 27, 3, 56, 56, 943, DateTimeKind.Unspecified).AddTicks(2932), new TimeSpan(0, 8, 0, 0, 0)), "Paula57@yahoo.com", null, null, "Visionary local internet solution", "Kohler, Bosco and Funk", 1, null, null },
                    { new Guid("09172986-0d63-3ed5-4e3e-e8ad75bc13a7"), "Group", new DateTimeOffset(new DateTime(2024, 2, 6, 1, 42, 20, 847, DateTimeKind.Unspecified).AddTicks(2522), new TimeSpan(0, 8, 0, 0, 0)), "Krystel_McKenzie@gmail.com", null, null, "Synergized dedicated middleware", "Schumm, Quigley and Beier", 2, null, null },
                    { new Guid("0b7adfcb-9a7a-c4f8-02de-0b4b0d520a51"), "LLC", new DateTimeOffset(new DateTime(2024, 6, 5, 8, 24, 47, 252, DateTimeKind.Unspecified).AddTicks(9772), new TimeSpan(0, 8, 0, 0, 0)), "Felix_Walter@yahoo.com", null, null, "Focused static array", "Mayer Group", 0, null, null },
                    { new Guid("0d4512a2-80d4-e118-91bd-590c7d800e3f"), "Inc", new DateTimeOffset(new DateTime(2023, 11, 20, 16, 33, 9, 748, DateTimeKind.Unspecified).AddTicks(8102), new TimeSpan(0, 8, 0, 0, 0)), "Adelbert16@yahoo.com", null, null, "Phased reciprocal initiative", "Bode - Daugherty", 1, null, null },
                    { new Guid("0d88d1f5-623b-5c4f-8d15-9114e970a4d3"), "LLC", new DateTimeOffset(new DateTime(2023, 12, 20, 19, 23, 18, 14, DateTimeKind.Unspecified).AddTicks(3457), new TimeSpan(0, 8, 0, 0, 0)), "Kole_Bartoletti60@hotmail.com", null, null, "Face to face real-time extranet", "Crist - Haley", 0, null, null },
                    { new Guid("0d94815a-ea18-9051-6d74-eb2c6e8ee1ee"), "and Sons", new DateTimeOffset(new DateTime(2023, 10, 5, 23, 51, 52, 266, DateTimeKind.Unspecified).AddTicks(8527), new TimeSpan(0, 8, 0, 0, 0)), "Demario15@gmail.com", null, null, "Compatible attitude-oriented neural-net", "Morar and Sons", 1, null, null },
                    { new Guid("1043960e-9d7b-4c8e-3a1b-1c33105fd775"), "Group", new DateTimeOffset(new DateTime(2024, 6, 18, 17, 28, 41, 533, DateTimeKind.Unspecified).AddTicks(6944), new TimeSpan(0, 8, 0, 0, 0)), "Jalon_Beahan@yahoo.com", null, null, "Profit-focused tangible architecture", "Larson, Leannon and Schmeler", 2, null, null },
                    { new Guid("11c088a6-5318-59a1-62fe-c6f9fc86b3fc"), "and Sons", new DateTimeOffset(new DateTime(2024, 7, 22, 18, 27, 23, 687, DateTimeKind.Unspecified).AddTicks(1748), new TimeSpan(0, 8, 0, 0, 0)), "Eloy.Schumm@yahoo.com", null, null, "Visionary value-added functionalities", "Hane - Satterfield", 2, null, null },
                    { new Guid("12504b2f-6d46-90cb-564c-8bd2debd79d8"), "Inc", new DateTimeOffset(new DateTime(2023, 12, 7, 15, 2, 19, 362, DateTimeKind.Unspecified).AddTicks(1054), new TimeSpan(0, 8, 0, 0, 0)), "Justine.Fritsch@gmail.com", null, null, "Team-oriented dynamic parallelism", "Gerhold - Armstrong", 2, null, null },
                    { new Guid("17af1a49-5ed5-aeba-dc58-da79cc784f42"), "Group", new DateTimeOffset(new DateTime(2023, 11, 13, 15, 16, 12, 861, DateTimeKind.Unspecified).AddTicks(8452), new TimeSpan(0, 8, 0, 0, 0)), "Nona52@yahoo.com", null, null, "Implemented logistical groupware", "Denesik and Sons", 2, null, null },
                    { new Guid("1888d239-103a-7b97-eac4-f2f2150e24fd"), "LLC", new DateTimeOffset(new DateTime(2024, 7, 3, 2, 30, 50, 665, DateTimeKind.Unspecified).AddTicks(2599), new TimeSpan(0, 8, 0, 0, 0)), "Mable22@hotmail.com", null, null, "De-engineered methodical artificial intelligence", "Ortiz Inc", 2, null, null },
                    { new Guid("1dab55c0-32dc-feef-3c70-c49584f3a3e2"), "Inc", new DateTimeOffset(new DateTime(2023, 8, 25, 13, 8, 24, 152, DateTimeKind.Unspecified).AddTicks(1389), new TimeSpan(0, 8, 0, 0, 0)), "Hiram83@yahoo.com", null, null, "Stand-alone object-oriented matrix", "McKenzie, Tillman and Douglas", 2, null, null },
                    { new Guid("1fe19421-2989-bdda-71d5-7f39b5df5958"), "LLC", new DateTimeOffset(new DateTime(2024, 6, 8, 4, 33, 43, 664, DateTimeKind.Unspecified).AddTicks(2059), new TimeSpan(0, 8, 0, 0, 0)), "Albertha.Dibbert@yahoo.com", null, null, "Reactive fault-tolerant extranet", "Cormier - Roob", 2, null, null },
                    { new Guid("24e53ebf-fc8c-85c6-8f84-844c74cfeac6"), "LLC", new DateTimeOffset(new DateTime(2023, 9, 17, 8, 43, 34, 280, DateTimeKind.Unspecified).AddTicks(1041), new TimeSpan(0, 8, 0, 0, 0)), "Adaline_Rogahn67@yahoo.com", null, null, "Right-sized bifurcated instruction set", "Donnelly - Muller", 2, null, null },
                    { new Guid("252914b0-e150-ef18-35c2-f4e809b06df6"), "Inc", new DateTimeOffset(new DateTime(2024, 4, 16, 6, 44, 0, 866, DateTimeKind.Unspecified).AddTicks(1457), new TimeSpan(0, 8, 0, 0, 0)), "Clementine.Gottlieb@gmail.com", null, null, "Exclusive real-time alliance", "Kovacek, Emmerich and Murazik", 2, null, null },
                    { new Guid("25db9c73-a630-be5b-759d-39884add0264"), "Group", new DateTimeOffset(new DateTime(2024, 1, 9, 6, 42, 15, 923, DateTimeKind.Unspecified).AddTicks(4741), new TimeSpan(0, 8, 0, 0, 0)), "Nedra78@gmail.com", null, null, "Optimized logistical monitoring", "Hartmann - Barton", 0, null, null },
                    { new Guid("26243396-eaa2-725e-1dfb-cb47b27eb6a2"), "and Sons", new DateTimeOffset(new DateTime(2024, 5, 5, 14, 49, 47, 566, DateTimeKind.Unspecified).AddTicks(701), new TimeSpan(0, 8, 0, 0, 0)), "Shannon4@gmail.com", null, null, "Future-proofed contextually-based model", "Gorczany, Schroeder and Bogisich", 0, null, null },
                    { new Guid("278ab156-bc9d-f8db-44f9-d4cfbe6e3b2a"), "Inc", new DateTimeOffset(new DateTime(2024, 8, 6, 5, 26, 38, 594, DateTimeKind.Unspecified).AddTicks(696), new TimeSpan(0, 8, 0, 0, 0)), "Tania.Beatty@yahoo.com", null, null, "Upgradable demand-driven success", "Dibbert - Gerhold", 2, null, null },
                    { new Guid("284815c1-2ca4-0154-cc5e-1890e0ddd5d3"), "Inc", new DateTimeOffset(new DateTime(2024, 2, 11, 22, 26, 38, 731, DateTimeKind.Unspecified).AddTicks(8199), new TimeSpan(0, 8, 0, 0, 0)), "Tina18@gmail.com", null, null, "Function-based explicit infrastructure", "Windler and Sons", 1, null, null },
                    { new Guid("2a910774-cf94-6015-4fac-e70d4cf1ef14"), "Group", new DateTimeOffset(new DateTime(2024, 3, 22, 16, 10, 56, 757, DateTimeKind.Unspecified).AddTicks(9111), new TimeSpan(0, 8, 0, 0, 0)), "Princess2@gmail.com", null, null, "Innovative needs-based structure", "Krajcik LLC", 1, null, null },
                    { new Guid("2bace653-c0b0-897e-a72c-007683bd28aa"), "LLC", new DateTimeOffset(new DateTime(2023, 12, 29, 13, 57, 33, 938, DateTimeKind.Unspecified).AddTicks(6541), new TimeSpan(0, 8, 0, 0, 0)), "Morgan_Gislason@yahoo.com", null, null, "Organized 24/7 encryption", "Wehner - Lockman", 0, null, null },
                    { new Guid("2cc51d03-3369-92dc-ae0f-94b775a3abbf"), "Group", new DateTimeOffset(new DateTime(2024, 1, 1, 11, 54, 35, 424, DateTimeKind.Unspecified).AddTicks(1997), new TimeSpan(0, 8, 0, 0, 0)), "Ellsworth.Grant@gmail.com", null, null, "Compatible incremental ability", "Koepp - Hilpert", 2, null, null },
                    { new Guid("361123a7-6d87-c45f-3cd7-5e58b655baef"), "Group", new DateTimeOffset(new DateTime(2024, 6, 22, 13, 51, 32, 888, DateTimeKind.Unspecified).AddTicks(9098), new TimeSpan(0, 8, 0, 0, 0)), "Timothy.Stehr22@gmail.com", null, null, "Pre-emptive web-enabled orchestration", "Erdman, Lowe and Padberg", 2, null, null },
                    { new Guid("384f77ef-41a1-ab36-b037-b53e7eeface2"), "Inc", new DateTimeOffset(new DateTime(2024, 5, 14, 11, 24, 50, 540, DateTimeKind.Unspecified).AddTicks(567), new TimeSpan(0, 8, 0, 0, 0)), "Laisha_Hudson@yahoo.com", null, null, "Extended heuristic local area network", "Wisoky, Luettgen and Fay", 1, null, null },
                    { new Guid("3c27f3b3-7c39-5d6b-3ba8-5269809b1e8c"), "and Sons", new DateTimeOffset(new DateTime(2023, 12, 15, 6, 53, 17, 875, DateTimeKind.Unspecified).AddTicks(3419), new TimeSpan(0, 8, 0, 0, 0)), "Palma_Walsh@hotmail.com", null, null, "Polarised zero defect help-desk", "Breitenberg Inc", 0, null, null },
                    { new Guid("41a01a6d-6389-faa2-40bc-22acd4d4fa0d"), "and Sons", new DateTimeOffset(new DateTime(2024, 3, 9, 19, 11, 31, 456, DateTimeKind.Unspecified).AddTicks(3701), new TimeSpan(0, 8, 0, 0, 0)), "Gussie22@hotmail.com", null, null, "Vision-oriented static access", "O'Kon - Bahringer", 2, null, null },
                    { new Guid("434deb54-3539-bc24-6efc-f256673d9921"), "Group", new DateTimeOffset(new DateTime(2023, 8, 28, 22, 26, 21, 188, DateTimeKind.Unspecified).AddTicks(4959), new TimeSpan(0, 8, 0, 0, 0)), "Diana.Keebler@yahoo.com", null, null, "Expanded logistical monitoring", "Braun Group", 2, null, null },
                    { new Guid("44957cbb-c3de-8fcf-0d8a-d34eaefd3a02"), "Inc", new DateTimeOffset(new DateTime(2023, 10, 24, 17, 38, 16, 282, DateTimeKind.Unspecified).AddTicks(8651), new TimeSpan(0, 8, 0, 0, 0)), "Abdul48@yahoo.com", null, null, "Reduced local matrices", "Bergnaum Inc", 0, null, null },
                    { new Guid("46ea3f36-decc-a472-0203-67957ad4b0df"), "LLC", new DateTimeOffset(new DateTime(2024, 5, 25, 2, 36, 34, 960, DateTimeKind.Unspecified).AddTicks(4053), new TimeSpan(0, 8, 0, 0, 0)), "Malvina62@yahoo.com", null, null, "Fundamental clear-thinking productivity", "McClure, Daugherty and McKenzie", 1, null, null },
                    { new Guid("470ad5ca-48e0-e845-0522-a1d4df8c7e6b"), "and Sons", new DateTimeOffset(new DateTime(2024, 3, 4, 21, 49, 10, 341, DateTimeKind.Unspecified).AddTicks(1042), new TimeSpan(0, 8, 0, 0, 0)), "Dayna_Smith98@hotmail.com", null, null, "Innovative transitional circuit", "Schoen and Sons", 1, null, null },
                    { new Guid("4afa77ac-7657-0010-0cb3-121b727202a5"), "LLC", new DateTimeOffset(new DateTime(2023, 8, 23, 4, 6, 27, 77, DateTimeKind.Unspecified).AddTicks(8049), new TimeSpan(0, 8, 0, 0, 0)), "Minnie.Harris70@hotmail.com", null, null, "Distributed scalable local area network", "Gutkowski - Davis", 2, null, null },
                    { new Guid("4c3f3fad-3e01-a21d-7f64-0b69fa5ca97b"), "LLC", new DateTimeOffset(new DateTime(2024, 1, 30, 11, 24, 31, 280, DateTimeKind.Unspecified).AddTicks(545), new TimeSpan(0, 8, 0, 0, 0)), "Ellie_Watsica@hotmail.com", null, null, "Business-focused empowering intranet", "Price, Rosenbaum and Reichert", 1, null, null },
                    { new Guid("4eefb399-dd35-9329-de4c-bdbe77fe28a6"), "Group", new DateTimeOffset(new DateTime(2024, 2, 13, 3, 30, 14, 257, DateTimeKind.Unspecified).AddTicks(1062), new TimeSpan(0, 8, 0, 0, 0)), "Donny.Cole@yahoo.com", null, null, "Function-based well-modulated project", "Boyer and Sons", 2, null, null },
                    { new Guid("4fef846f-b76f-2c33-718b-a1849c6386a3"), "Group", new DateTimeOffset(new DateTime(2024, 1, 20, 7, 49, 7, 637, DateTimeKind.Unspecified).AddTicks(5461), new TimeSpan(0, 8, 0, 0, 0)), "Cooper.Koepp77@yahoo.com", null, null, "Vision-oriented homogeneous knowledge user", "Ryan and Sons", 2, null, null },
                    { new Guid("50b84c62-fb27-4156-9a6b-7aec7d14e3e6"), "Inc", new DateTimeOffset(new DateTime(2024, 1, 23, 17, 30, 5, 346, DateTimeKind.Unspecified).AddTicks(2581), new TimeSpan(0, 8, 0, 0, 0)), "Mona_Reynolds@yahoo.com", null, null, "Switchable dynamic product", "Donnelly - Quigley", 2, null, null },
                    { new Guid("5443d23c-5cd3-b1de-9e0d-dc57dd772135"), "and Sons", new DateTimeOffset(new DateTime(2024, 5, 30, 23, 24, 30, 560, DateTimeKind.Unspecified).AddTicks(20), new TimeSpan(0, 8, 0, 0, 0)), "Aisha.Grady@gmail.com", null, null, "Profit-focused even-keeled artificial intelligence", "Wiza - Koch", 2, null, null },
                    { new Guid("56426133-21ad-0245-f908-be96db36a3d1"), "Inc", new DateTimeOffset(new DateTime(2024, 6, 23, 1, 40, 12, 442, DateTimeKind.Unspecified).AddTicks(5586), new TimeSpan(0, 8, 0, 0, 0)), "Hortense_Blanda13@yahoo.com", null, null, "Upgradable client-server attitude", "Gerlach, Medhurst and Friesen", 1, null, null },
                    { new Guid("575093d2-dad3-f20a-b2bf-93903bc1f420"), "LLC", new DateTimeOffset(new DateTime(2024, 5, 13, 16, 41, 59, 313, DateTimeKind.Unspecified).AddTicks(3002), new TimeSpan(0, 8, 0, 0, 0)), "Wayne.Hills@hotmail.com", null, null, "Phased discrete portal", "Gulgowski Inc", 1, null, null },
                    { new Guid("593aaa63-e1ab-9f87-d62c-f84b960560ab"), "Group", new DateTimeOffset(new DateTime(2024, 4, 2, 11, 17, 9, 881, DateTimeKind.Unspecified).AddTicks(940), new TimeSpan(0, 8, 0, 0, 0)), "Ewell.Trantow19@hotmail.com", null, null, "Seamless next generation groupware", "Bergstrom Inc", 1, null, null },
                    { new Guid("60209a9c-5f63-df24-6f74-303aa2b0217f"), "LLC", new DateTimeOffset(new DateTime(2023, 11, 14, 5, 22, 50, 561, DateTimeKind.Unspecified).AddTicks(1024), new TimeSpan(0, 8, 0, 0, 0)), "Jaiden_Tromp@yahoo.com", null, null, "Customizable intangible contingency", "O'Conner, Predovic and Rosenbaum", 2, null, null },
                    { new Guid("616ebde5-64d2-015f-265b-297e604eda17"), "Inc", new DateTimeOffset(new DateTime(2024, 3, 12, 5, 23, 36, 275, DateTimeKind.Unspecified).AddTicks(5170), new TimeSpan(0, 8, 0, 0, 0)), "Ladarius.Kerluke26@yahoo.com", null, null, "Profound methodical interface", "Ferry - Dickens", 0, null, null },
                    { new Guid("61b22a11-b1c4-ca58-3732-4fc6213987c5"), "Inc", new DateTimeOffset(new DateTime(2023, 11, 22, 0, 1, 40, 310, DateTimeKind.Unspecified).AddTicks(7781), new TimeSpan(0, 8, 0, 0, 0)), "Maida67@yahoo.com", null, null, "Programmable analyzing initiative", "Hintz, Marvin and Hegmann", 2, null, null },
                    { new Guid("61f06402-9238-4c3c-1d14-dcd068e8d133"), "Inc", new DateTimeOffset(new DateTime(2024, 1, 19, 16, 59, 23, 258, DateTimeKind.Unspecified).AddTicks(8208), new TimeSpan(0, 8, 0, 0, 0)), "Juliana_Morissette25@gmail.com", null, null, "User-friendly logistical knowledge base", "Lockman - Blick", 0, null, null },
                    { new Guid("62076bc8-2986-bbfa-8557-c5be2bb0674c"), "and Sons", new DateTimeOffset(new DateTime(2024, 1, 26, 21, 14, 33, 459, DateTimeKind.Unspecified).AddTicks(1038), new TimeSpan(0, 8, 0, 0, 0)), "Kelli.Gislason@gmail.com", null, null, "Face to face asynchronous implementation", "Rohan and Sons", 2, null, null },
                    { new Guid("654a2694-98c2-48e7-a76c-62cec412d4cc"), "LLC", new DateTimeOffset(new DateTime(2024, 3, 2, 7, 19, 29, 601, DateTimeKind.Unspecified).AddTicks(1040), new TimeSpan(0, 8, 0, 0, 0)), "Cordell_Conroy@hotmail.com", null, null, "Horizontal regional collaboration", "Turcotte - Rau", 0, null, null },
                    { new Guid("6851e8ee-2a19-f0aa-22a6-ccc5b587b6bf"), "Group", new DateTimeOffset(new DateTime(2024, 5, 9, 14, 18, 34, 518, DateTimeKind.Unspecified).AddTicks(9657), new TimeSpan(0, 8, 0, 0, 0)), "Chaz_Reichel@hotmail.com", null, null, "Customer-focused well-modulated encoding", "Hudson Group", 1, null, null },
                    { new Guid("720dad4a-6ac3-30b6-4592-8f55328e2b7a"), "Group", new DateTimeOffset(new DateTime(2024, 4, 12, 2, 44, 57, 172, DateTimeKind.Unspecified).AddTicks(19), new TimeSpan(0, 8, 0, 0, 0)), "Rod_Gerlach@gmail.com", null, null, "Quality-focused asymmetric encryption", "Ferry - Stanton", 1, null, null },
                    { new Guid("72391cbc-faf3-eff9-4f09-e01f5c8352e3"), "and Sons", new DateTimeOffset(new DateTime(2023, 9, 2, 16, 50, 9, 487, DateTimeKind.Unspecified).AddTicks(1152), new TimeSpan(0, 8, 0, 0, 0)), "Eli.Stehr10@yahoo.com", null, null, "Profound 4th generation frame", "McCullough - Toy", 2, null, null },
                    { new Guid("743fe418-b58b-bd11-c203-ef196e4d12ca"), "LLC", new DateTimeOffset(new DateTime(2024, 2, 28, 4, 0, 46, 929, DateTimeKind.Unspecified).AddTicks(2304), new TimeSpan(0, 8, 0, 0, 0)), "Elnora.Dicki@gmail.com", null, null, "Face to face client-server encoding", "Bradtke Group", 0, null, null },
                    { new Guid("784f5b1f-579b-b005-746c-73b20684c9b6"), "and Sons", new DateTimeOffset(new DateTime(2024, 5, 5, 11, 54, 12, 168, DateTimeKind.Unspecified).AddTicks(9571), new TimeSpan(0, 8, 0, 0, 0)), "Jackeline91@yahoo.com", null, null, "Open-architected radical emulation", "Gusikowski Inc", 2, null, null },
                    { new Guid("78fd1d63-e998-0a1b-9682-983d67846a19"), "and Sons", new DateTimeOffset(new DateTime(2024, 5, 8, 13, 35, 19, 837, DateTimeKind.Unspecified).AddTicks(7051), new TimeSpan(0, 8, 0, 0, 0)), "Stacy.Johnston21@gmail.com", null, null, "Pre-emptive well-modulated framework", "Kassulke - Dickinson", 2, null, null },
                    { new Guid("79d54c76-1121-8fbb-dc41-0f9781bfd5c3"), "Inc", new DateTimeOffset(new DateTime(2023, 11, 5, 20, 22, 11, 15, DateTimeKind.Unspecified).AddTicks(4474), new TimeSpan(0, 8, 0, 0, 0)), "Carmel.Erdman3@hotmail.com", null, null, "Balanced interactive frame", "Hessel Inc", 2, null, null },
                    { new Guid("826e391a-056a-f038-69f8-29e0faa34a55"), "Inc", new DateTimeOffset(new DateTime(2024, 6, 20, 3, 10, 54, 487, DateTimeKind.Unspecified).AddTicks(3892), new TimeSpan(0, 8, 0, 0, 0)), "Dayton60@hotmail.com", null, null, "Profound impactful strategy", "Fay LLC", 1, null, null },
                    { new Guid("878399c6-3c38-87e0-d175-5755f3dfba58"), "Group", new DateTimeOffset(new DateTime(2024, 8, 5, 4, 10, 54, 56, DateTimeKind.Unspecified).AddTicks(1564), new TimeSpan(0, 8, 0, 0, 0)), "Zola56@gmail.com", null, null, "Versatile uniform archive", "Ondricka - Herman", 1, null, null },
                    { new Guid("890b4f47-2f17-8c04-4db3-c41f45cfd33a"), "and Sons", new DateTimeOffset(new DateTime(2023, 11, 14, 18, 41, 8, 575, DateTimeKind.Unspecified).AddTicks(7238), new TimeSpan(0, 8, 0, 0, 0)), "Bryce_Langworth79@hotmail.com", null, null, "Customer-focused exuding secured line", "Gleason, Koepp and Ferry", 0, null, null },
                    { new Guid("8a1f0565-8c49-b2ca-c2d4-ebc1fc095fb4"), "Group", new DateTimeOffset(new DateTime(2024, 5, 4, 10, 14, 23, 277, DateTimeKind.Unspecified).AddTicks(1610), new TimeSpan(0, 8, 0, 0, 0)), "Nathen73@hotmail.com", null, null, "Integrated regional superstructure", "Quitzon - Kassulke", 0, null, null },
                    { new Guid("93653f98-5c4d-791d-5c88-8777380a56a5"), "LLC", new DateTimeOffset(new DateTime(2024, 7, 21, 4, 8, 31, 621, DateTimeKind.Unspecified).AddTicks(8690), new TimeSpan(0, 8, 0, 0, 0)), "Brett.Barton@hotmail.com", null, null, "Public-key executive pricing structure", "Lakin, Hagenes and Hagenes", 1, null, null },
                    { new Guid("94387622-249d-6a20-69f2-ec3cb031d400"), "Group", new DateTimeOffset(new DateTime(2024, 8, 11, 9, 6, 55, 388, DateTimeKind.Unspecified).AddTicks(4971), new TimeSpan(0, 8, 0, 0, 0)), "Maryam_Mohr28@yahoo.com", null, null, "Managed systemic encoding", "Johnson Inc", 0, null, null },
                    { new Guid("963b0ce5-48e5-798d-525a-6b2e97fd01cb"), "Group", new DateTimeOffset(new DateTime(2023, 12, 29, 11, 20, 40, 164, DateTimeKind.Unspecified).AddTicks(7181), new TimeSpan(0, 8, 0, 0, 0)), "Buddy88@gmail.com", null, null, "Managed hybrid pricing structure", "Lueilwitz, Gibson and Kessler", 0, null, null },
                    { new Guid("97eb8ce7-63c1-e2b7-3b7a-d3d8f45195fa"), "Group", new DateTimeOffset(new DateTime(2024, 7, 16, 12, 20, 31, 726, DateTimeKind.Unspecified).AddTicks(2912), new TimeSpan(0, 8, 0, 0, 0)), "Dawson_Thompson86@yahoo.com", null, null, "Integrated stable analyzer", "Kilback - O'Reilly", 0, null, null },
                    { new Guid("995c7d4f-2980-3589-9681-2a49ddfee047"), "Inc", new DateTimeOffset(new DateTime(2024, 6, 9, 7, 9, 45, 168, DateTimeKind.Unspecified).AddTicks(351), new TimeSpan(0, 8, 0, 0, 0)), "Elinore.Deckow@gmail.com", null, null, "Organized intermediate interface", "Pfeffer, Conroy and Bashirian", 2, null, null },
                    { new Guid("9c422f8f-9307-b0ae-6a71-8fe2812e01c8"), "and Sons", new DateTimeOffset(new DateTime(2024, 5, 19, 13, 7, 17, 233, DateTimeKind.Unspecified).AddTicks(1726), new TimeSpan(0, 8, 0, 0, 0)), "Dandre.Harvey@yahoo.com", null, null, "Centralized bifurcated benchmark", "Nienow and Sons", 2, null, null },
                    { new Guid("a179e560-5783-97aa-af52-8763aa853e8d"), "Inc", new DateTimeOffset(new DateTime(2023, 10, 17, 23, 37, 29, 607, DateTimeKind.Unspecified).AddTicks(1482), new TimeSpan(0, 8, 0, 0, 0)), "Frankie_Little@hotmail.com", null, null, "Automated reciprocal encryption", "Pfannerstill - Maggio", 2, null, null },
                    { new Guid("a42c2e23-a9a5-937b-7bc5-28e73c4b798a"), "Inc", new DateTimeOffset(new DateTime(2024, 1, 4, 8, 11, 14, 755, DateTimeKind.Unspecified).AddTicks(3997), new TimeSpan(0, 8, 0, 0, 0)), "Gussie91@hotmail.com", null, null, "Universal 24 hour algorithm", "Harber - Bahringer", 2, null, null },
                    { new Guid("a5063557-32b6-2342-d9c7-5d19327fa626"), "and Sons", new DateTimeOffset(new DateTime(2024, 7, 12, 8, 55, 21, 218, DateTimeKind.Unspecified).AddTicks(6578), new TimeSpan(0, 8, 0, 0, 0)), "Stacy43@hotmail.com", null, null, "Open-architected maximized framework", "Bradtke, Zboncak and Corwin", 1, null, null },
                    { new Guid("a78ca05b-d28c-0f68-4435-2c0c210aef35"), "Inc", new DateTimeOffset(new DateTime(2024, 1, 9, 20, 20, 43, 952, DateTimeKind.Unspecified).AddTicks(671), new TimeSpan(0, 8, 0, 0, 0)), "Karianne2@hotmail.com", null, null, "Secured background Graphic Interface", "Torp, Schumm and Sanford", 1, null, null },
                    { new Guid("a79e32b3-06ae-99b2-61de-4cd63271bf78"), "LLC", new DateTimeOffset(new DateTime(2024, 5, 28, 19, 56, 51, 121, DateTimeKind.Unspecified).AddTicks(1391), new TimeSpan(0, 8, 0, 0, 0)), "Darion66@hotmail.com", null, null, "De-engineered dynamic attitude", "Swaniawski and Sons", 0, null, null },
                    { new Guid("a873eaf6-9467-f6e3-0be7-f4326f7cde08"), "LLC", new DateTimeOffset(new DateTime(2023, 12, 6, 3, 7, 42, 335, DateTimeKind.Unspecified).AddTicks(5079), new TimeSpan(0, 8, 0, 0, 0)), "Rosina_Runolfsdottir@hotmail.com", null, null, "Balanced incremental Graphic Interface", "Bechtelar, Quitzon and Littel", 1, null, null },
                    { new Guid("ab42f983-9868-2b08-606c-6ceee13430c6"), "Inc", new DateTimeOffset(new DateTime(2023, 12, 26, 14, 15, 24, 36, DateTimeKind.Unspecified).AddTicks(5236), new TimeSpan(0, 8, 0, 0, 0)), "Sabrina.Haley@hotmail.com", null, null, "Vision-oriented uniform encoding", "Kub, Marvin and Hoppe", 2, null, null },
                    { new Guid("ac14e7d5-b29e-ba8f-5ff2-b7cbbaaba147"), "Group", new DateTimeOffset(new DateTime(2023, 12, 31, 18, 48, 3, 376, DateTimeKind.Unspecified).AddTicks(1684), new TimeSpan(0, 8, 0, 0, 0)), "Hector_Sipes64@hotmail.com", null, null, "Centralized mobile Graphic Interface", "Kilback, Green and Hayes", 0, null, null },
                    { new Guid("ac829118-03b5-61ae-233a-a67006c53a84"), "and Sons", new DateTimeOffset(new DateTime(2024, 1, 28, 17, 27, 19, 640, DateTimeKind.Unspecified).AddTicks(4), new TimeSpan(0, 8, 0, 0, 0)), "Dangelo.Ruecker77@hotmail.com", null, null, "Fully-configurable optimal knowledge base", "Howe Inc", 2, null, null },
                    { new Guid("ae1aa5e0-0c84-1467-a01b-28661c2974c9"), "Group", new DateTimeOffset(new DateTime(2024, 1, 1, 2, 40, 41, 235, DateTimeKind.Unspecified).AddTicks(2574), new TimeSpan(0, 8, 0, 0, 0)), "Bernadine_McGlynn82@hotmail.com", null, null, "Profit-focused 6th generation implementation", "Waters LLC", 2, null, null },
                    { new Guid("aef0f2f7-7e16-3e31-9d02-0b893462a76a"), "and Sons", new DateTimeOffset(new DateTime(2023, 11, 11, 19, 41, 56, 358, DateTimeKind.Unspecified).AddTicks(514), new TimeSpan(0, 8, 0, 0, 0)), "Christ66@hotmail.com", null, null, "Team-oriented foreground challenge", "Jerde, Yundt and Macejkovic", 0, null, null },
                    { new Guid("b4043dfa-483a-2fd1-b792-990dfb436a7b"), "LLC", new DateTimeOffset(new DateTime(2024, 6, 22, 10, 54, 23, 826, DateTimeKind.Unspecified).AddTicks(4414), new TimeSpan(0, 8, 0, 0, 0)), "Krista_Nikolaus@hotmail.com", null, null, "Multi-lateral bifurcated database", "Macejkovic LLC", 2, null, null },
                    { new Guid("b72c9d66-8e80-70a9-8f57-1c9e1cb4773f"), "Inc", new DateTimeOffset(new DateTime(2024, 3, 14, 4, 14, 21, 802, DateTimeKind.Unspecified).AddTicks(7678), new TimeSpan(0, 8, 0, 0, 0)), "Carlee65@gmail.com", null, null, "Universal web-enabled infrastructure", "Terry - Doyle", 2, null, null },
                    { new Guid("b91fd015-c376-000d-6de4-10c6d901005f"), "and Sons", new DateTimeOffset(new DateTime(2023, 12, 3, 18, 7, 29, 725, DateTimeKind.Unspecified).AddTicks(2991), new TimeSpan(0, 8, 0, 0, 0)), "Haylie.Collins@gmail.com", null, null, "Optimized user-facing contingency", "Stoltenberg LLC", 2, null, null },
                    { new Guid("ba8d0199-fea2-9162-e34e-e3ac6ac0bb5d"), "Group", new DateTimeOffset(new DateTime(2024, 2, 11, 23, 7, 39, 147, DateTimeKind.Unspecified).AddTicks(8556), new TimeSpan(0, 8, 0, 0, 0)), "Alejandrin69@gmail.com", null, null, "Optional composite forecast", "Lebsack - Medhurst", 0, null, null },
                    { new Guid("bfe6ec15-a20e-d40e-a68c-708c49a87d58"), "Group", new DateTimeOffset(new DateTime(2024, 2, 12, 21, 31, 25, 360, DateTimeKind.Unspecified).AddTicks(2147), new TimeSpan(0, 8, 0, 0, 0)), "Nona_Pfannerstill@hotmail.com", null, null, "Re-engineered attitude-oriented task-force", "Blanda, Murray and Stanton", 1, null, null },
                    { new Guid("c294575e-2f95-4039-5021-669f91d93dcc"), "and Sons", new DateTimeOffset(new DateTime(2024, 2, 23, 4, 34, 18, 34, DateTimeKind.Unspecified).AddTicks(6915), new TimeSpan(0, 8, 0, 0, 0)), "Imelda_Mosciski16@hotmail.com", null, null, "Mandatory hybrid groupware", "Hills Group", 2, null, null },
                    { new Guid("c9ff9eaf-2a0d-5daa-42fb-d97b542aca83"), "Group", new DateTimeOffset(new DateTime(2023, 12, 3, 13, 5, 54, 757, DateTimeKind.Unspecified).AddTicks(9120), new TimeSpan(0, 8, 0, 0, 0)), "Mallie.Senger@gmail.com", null, null, "Phased disintermediate monitoring", "Kiehn Group", 1, null, null },
                    { new Guid("ca36b7bb-185a-3dde-ee09-c1005704bd90"), "and Sons", new DateTimeOffset(new DateTime(2024, 1, 26, 2, 0, 3, 641, DateTimeKind.Unspecified).AddTicks(4095), new TimeSpan(0, 8, 0, 0, 0)), "Wilbert_Jacobson@gmail.com", null, null, "Implemented background middleware", "Paucek LLC", 2, null, null },
                    { new Guid("cadce29e-c390-c7b1-4be5-9f0a67d3fe2e"), "Inc", new DateTimeOffset(new DateTime(2024, 4, 30, 11, 42, 43, 751, DateTimeKind.Unspecified).AddTicks(8510), new TimeSpan(0, 8, 0, 0, 0)), "Domenico_Shields@gmail.com", null, null, "Compatible 5th generation collaboration", "Kerluke, Cummings and Beer", 2, null, null },
                    { new Guid("cde967e7-dfbe-7bd4-d695-6bc9aa576cf5"), "LLC", new DateTimeOffset(new DateTime(2024, 6, 2, 21, 38, 0, 953, DateTimeKind.Unspecified).AddTicks(9237), new TimeSpan(0, 8, 0, 0, 0)), "Kenneth.Little79@hotmail.com", null, null, "Cross-group secondary paradigm", "Krajcik - Kshlerin", 1, null, null },
                    { new Guid("d3851f65-f960-dfd4-ecbc-f4cbb37919d8"), "LLC", new DateTimeOffset(new DateTime(2024, 2, 22, 22, 47, 29, 672, DateTimeKind.Unspecified).AddTicks(7214), new TimeSpan(0, 8, 0, 0, 0)), "Abdullah.Grimes@hotmail.com", null, null, "Front-line empowering collaboration", "Feil LLC", 1, null, null },
                    { new Guid("d4796885-737a-c0eb-9769-4b96eefa5fce"), "LLC", new DateTimeOffset(new DateTime(2023, 9, 1, 3, 41, 30, 99, DateTimeKind.Unspecified).AddTicks(113), new TimeSpan(0, 8, 0, 0, 0)), "Julie.Huels21@yahoo.com", null, null, "Multi-channelled contextually-based process improvement", "Lesch - Vandervort", 0, null, null },
                    { new Guid("dd6f5f88-eac2-77e0-533e-3e3b931621cd"), "Inc", new DateTimeOffset(new DateTime(2024, 1, 5, 7, 42, 9, 943, DateTimeKind.Unspecified).AddTicks(8658), new TimeSpan(0, 8, 0, 0, 0)), "Hazel98@yahoo.com", null, null, "Multi-layered user-facing archive", "Gaylord and Sons", 1, null, null },
                    { new Guid("dd8474e1-a5e1-b5a1-4010-cf6f6bdfc990"), "LLC", new DateTimeOffset(new DateTime(2024, 6, 8, 10, 18, 26, 44, DateTimeKind.Unspecified).AddTicks(5174), new TimeSpan(0, 8, 0, 0, 0)), "Madisyn.Schoen@gmail.com", null, null, "Operative interactive circuit", "Reilly, Glover and Heathcote", 1, null, null },
                    { new Guid("dea675bd-8ebc-11d2-b838-6e5207f6e03a"), "Inc", new DateTimeOffset(new DateTime(2024, 7, 8, 1, 51, 6, 79, DateTimeKind.Unspecified).AddTicks(287), new TimeSpan(0, 8, 0, 0, 0)), "Chandler37@hotmail.com", null, null, "Ameliorated background data-warehouse", "Goyette Group", 2, null, null },
                    { new Guid("dfe11fdd-6e43-ac11-b109-23d38f7ce203"), "Inc", new DateTimeOffset(new DateTime(2023, 11, 9, 4, 43, 33, 430, DateTimeKind.Unspecified).AddTicks(8789), new TimeSpan(0, 8, 0, 0, 0)), "Nathanael99@hotmail.com", null, null, "Balanced fresh-thinking analyzer", "Lemke - Nolan", 0, null, null },
                    { new Guid("e3e06b71-b29b-dfd3-1138-ea07a8dcfa69"), "and Sons", new DateTimeOffset(new DateTime(2023, 10, 4, 11, 1, 53, 716, DateTimeKind.Unspecified).AddTicks(1402), new TimeSpan(0, 8, 0, 0, 0)), "Bria.Hackett@gmail.com", null, null, "Seamless foreground infrastructure", "Lehner Inc", 0, null, null },
                    { new Guid("e772974d-7b1e-5d62-caa2-0e99455bf957"), "LLC", new DateTimeOffset(new DateTime(2024, 7, 25, 5, 27, 2, 600, DateTimeKind.Unspecified).AddTicks(1910), new TimeSpan(0, 8, 0, 0, 0)), "Mercedes45@hotmail.com", null, null, "Decentralized object-oriented secured line", "Moen - Daniel", 0, null, null },
                    { new Guid("ed1ceb35-f1fa-f58c-faa1-d83011478036"), "Inc", new DateTimeOffset(new DateTime(2024, 3, 9, 6, 51, 18, 341, DateTimeKind.Unspecified).AddTicks(2758), new TimeSpan(0, 8, 0, 0, 0)), "Makayla.Strosin85@hotmail.com", null, null, "Multi-tiered regional neural-net", "McCullough, Kub and Mitchell", 2, null, null },
                    { new Guid("f02680bb-0837-301d-cdb2-0a210d61a11c"), "LLC", new DateTimeOffset(new DateTime(2024, 3, 30, 17, 7, 59, 658, DateTimeKind.Unspecified).AddTicks(6675), new TimeSpan(0, 8, 0, 0, 0)), "Melyssa_Hagenes59@hotmail.com", null, null, "Secured optimal analyzer", "Douglas and Sons", 0, null, null },
                    { new Guid("f9e81e5f-0aa0-330a-1d10-caa692e92105"), "LLC", new DateTimeOffset(new DateTime(2024, 1, 8, 7, 12, 34, 852, DateTimeKind.Unspecified).AddTicks(2455), new TimeSpan(0, 8, 0, 0, 0)), "Eleanora.OConnell45@hotmail.com", null, null, "Switchable systematic analyzer", "Towne, Hermann and Weber", 0, null, null }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AddressLine1", "AddressLine2", "City", "CountryId", "CreatedAtUtcNow", "CreatedBy", "CustomerId", "DeletedAtUtcNow", "DeletedBy", "State", "Status", "UpdatedAtUtcNow", "UpdatedBy", "ZipCode" },
                values: new object[,]
                {
                    { new Guid("0b671d90-91d3-3e09-8a28-ccd71e534b07"), "71041 Johanna Cape", null, "Okunevashire", new Guid("bdcdde7e-ef6d-87ed-0034-20b124997faf"), new DateTimeOffset(new DateTime(2024, 6, 4, 22, 41, 29, 96, DateTimeKind.Unspecified).AddTicks(7904), new TimeSpan(0, 8, 0, 0, 0)), "Aurelia.Romaguera7@yahoo.com", new Guid("209abb0f-0b38-d0a0-c4d9-a9e9777c26b9"), null, null, "Maryland", 0, null, null, "26693" },
                    { new Guid("14185642-798c-ae7d-55cf-1cde5b558b7f"), "488 Pagac Roads", null, "Considinestad", new Guid("7822f9f4-31c0-1b5d-339b-52f0c2440a4d"), new DateTimeOffset(new DateTime(2024, 3, 24, 14, 41, 45, 37, DateTimeKind.Unspecified).AddTicks(6561), new TimeSpan(0, 8, 0, 0, 0)), "Delpha11@hotmail.com", new Guid("f932b0a7-2115-591f-1dc6-5945d22dea68"), null, null, "Florida", 1, null, null, "48444" },
                    { new Guid("18c24b15-7316-e91c-a9e0-023e249179ec"), "09771 Gisselle Stream", null, "Makaylashire", new Guid("232b4a2c-bf44-14a8-b3f3-2a72fd2863fa"), new DateTimeOffset(new DateTime(2023, 12, 14, 8, 4, 37, 312, DateTimeKind.Unspecified).AddTicks(1254), new TimeSpan(0, 8, 0, 0, 0)), "Misael_Rau29@yahoo.com", new Guid("f9aee77d-22f8-6e91-a828-763fe2b6659c"), null, null, "Wisconsin", 2, null, null, "40764" },
                    { new Guid("1e02f4dd-19dd-28c9-b255-9513ccaaa804"), "389 Verner Track", null, "South Eric", new Guid("40768e26-cc75-710e-180d-1a8870bbe1fc"), new DateTimeOffset(new DateTime(2024, 7, 13, 8, 9, 20, 819, DateTimeKind.Unspecified).AddTicks(8613), new TimeSpan(0, 8, 0, 0, 0)), "Gerard.Greenholt@gmail.com", new Guid("4a3b1021-693e-8246-202d-2056bef26878"), null, null, "Oregon", 1, null, null, "91782-6489" },
                    { new Guid("3329cdb7-366f-0686-442f-482bec442af7"), "273 Anderson Locks", null, "Jarrellchester", new Guid("929a5447-ee63-fd54-cab9-9cf05c19cc32"), new DateTimeOffset(new DateTime(2023, 9, 29, 17, 44, 51, 988, DateTimeKind.Unspecified).AddTicks(36), new TimeSpan(0, 8, 0, 0, 0)), "Jessyca_Wolff@hotmail.com", new Guid("3b6237d7-3571-fa61-6c3e-f9d8379f0bea"), null, null, "North Dakota", 1, null, null, "39968-6635" },
                    { new Guid("4abdf487-c1e2-2188-bde5-0bbfb2b10b7d"), "1553 Lempi Fork", null, "Port Carolynemouth", new Guid("2cc8100c-b48d-9752-4355-0e443a99e8dd"), new DateTimeOffset(new DateTime(2024, 2, 29, 2, 10, 9, 1, DateTimeKind.Unspecified).AddTicks(980), new TimeSpan(0, 8, 0, 0, 0)), "Keshaun.Jakubowski45@yahoo.com", new Guid("daf5e673-765e-4956-7876-5a74c967046d"), null, null, "Iowa", 0, null, null, "98166-7691" },
                    { new Guid("4ef7f69b-169e-e612-19b8-888e12f3e459"), "1812 Heidenreich Gateway", null, "Lake Rubye", new Guid("023e17d9-9a71-a52a-ce57-5cbe8f77846b"), new DateTimeOffset(new DateTime(2023, 10, 17, 20, 27, 10, 322, DateTimeKind.Unspecified).AddTicks(3817), new TimeSpan(0, 8, 0, 0, 0)), "Nicholaus_Stracke9@hotmail.com", new Guid("7975fd4d-69a4-6e62-4229-8b52c78f0131"), null, null, "Connecticut", 0, null, null, "85053" },
                    { new Guid("54db743c-c9a2-65d2-2d98-fc3cd5015ec4"), "685 Kirlin Dam", null, "South Jerald", new Guid("bdcdde7e-ef6d-87ed-0034-20b124997faf"), new DateTimeOffset(new DateTime(2023, 10, 16, 0, 34, 52, 693, DateTimeKind.Unspecified).AddTicks(1871), new TimeSpan(0, 8, 0, 0, 0)), "Leopoldo_Sawayn36@gmail.com", new Guid("7975fd4d-69a4-6e62-4229-8b52c78f0131"), null, null, "North Dakota", 2, null, null, "62928-7662" },
                    { new Guid("596fffe0-8de3-d5f2-cefc-5829fa22c6ca"), "0688 Bartoletti Wall", null, "Port Ardenfurt", new Guid("232b4a2c-bf44-14a8-b3f3-2a72fd2863fa"), new DateTimeOffset(new DateTime(2023, 11, 26, 16, 15, 4, 28, DateTimeKind.Unspecified).AddTicks(728), new TimeSpan(0, 8, 0, 0, 0)), "Jayme19@yahoo.com", new Guid("75537c47-807f-fced-6300-764e0ef57c31"), null, null, "Maine", 0, null, null, "17686-5893" },
                    { new Guid("5b88983d-048e-da5f-f227-2cac3a2e669e"), "27107 Lila Plains", null, "Laynemouth", new Guid("9164ccb8-2c87-f6d1-e697-a7b3501651a8"), new DateTimeOffset(new DateTime(2023, 12, 16, 16, 8, 45, 316, DateTimeKind.Unspecified).AddTicks(5294), new TimeSpan(0, 8, 0, 0, 0)), "Nils_Conn@gmail.com", new Guid("7975fd4d-69a4-6e62-4229-8b52c78f0131"), null, null, "South Carolina", 0, null, null, "66161" },
                    { new Guid("5f39b59f-9e8c-9da3-ab22-7e2d6482e4b2"), "7325 Conroy River", null, "Lilyside", new Guid("40768e26-cc75-710e-180d-1a8870bbe1fc"), new DateTimeOffset(new DateTime(2023, 12, 31, 16, 24, 51, 66, DateTimeKind.Unspecified).AddTicks(7263), new TimeSpan(0, 8, 0, 0, 0)), "Alfred.Schimmel@hotmail.com", new Guid("bf0115c9-d798-29cf-f6c1-68cede86c4a4"), null, null, "Arkansas", 0, null, null, "60136-1085" },
                    { new Guid("66195908-6114-bb53-a31f-791a766ea9b1"), "089 Lenore Cove", null, "Christown", new Guid("232b4a2c-bf44-14a8-b3f3-2a72fd2863fa"), new DateTimeOffset(new DateTime(2024, 5, 21, 4, 29, 13, 541, DateTimeKind.Unspecified).AddTicks(4721), new TimeSpan(0, 8, 0, 0, 0)), "Chad19@yahoo.com", new Guid("18c4807f-b67a-61bd-5b25-87d61b61ad1b"), null, null, "Louisiana", 1, null, null, "82126" },
                    { new Guid("669e6cee-1bb7-0a6d-1f79-fcf0339c3a69"), "8382 Satterfield Manors", null, "Lake Tomberg", new Guid("40768e26-cc75-710e-180d-1a8870bbe1fc"), new DateTimeOffset(new DateTime(2024, 7, 20, 21, 54, 29, 691, DateTimeKind.Unspecified).AddTicks(4993), new TimeSpan(0, 8, 0, 0, 0)), "Guy.Leannon88@yahoo.com", new Guid("27f12e06-fdc7-94bb-ad2b-ad70d70797d0"), null, null, "South Carolina", 2, null, null, "89922" },
                    { new Guid("6754f590-402e-eca5-4fe4-410e28a44185"), "3914 Wiegand Garden", null, "West Dylanland", new Guid("bdcdde7e-ef6d-87ed-0034-20b124997faf"), new DateTimeOffset(new DateTime(2024, 6, 28, 15, 45, 3, 434, DateTimeKind.Unspecified).AddTicks(6399), new TimeSpan(0, 8, 0, 0, 0)), "Solon44@hotmail.com", new Guid("95a21bd4-b409-b5fa-fcdc-25b02cc7d807"), null, null, "Wyoming", 1, null, null, "09270-7788" },
                    { new Guid("7d639d04-9601-ceb9-b54d-ffbcc122808b"), "808 Graham Estates", null, "Greenstad", new Guid("2cc8100c-b48d-9752-4355-0e443a99e8dd"), new DateTimeOffset(new DateTime(2024, 2, 4, 11, 45, 14, 462, DateTimeKind.Unspecified).AddTicks(2715), new TimeSpan(0, 8, 0, 0, 0)), "Verla.Waters@yahoo.com", new Guid("27f12e06-fdc7-94bb-ad2b-ad70d70797d0"), null, null, "Texas", 2, null, null, "78547" },
                    { new Guid("7e598b83-dd8b-e608-8b0e-3ffe2018053a"), "54474 Ara Drive", null, "North Zariafurt", new Guid("2cc8100c-b48d-9752-4355-0e443a99e8dd"), new DateTimeOffset(new DateTime(2024, 1, 31, 15, 32, 21, 721, DateTimeKind.Unspecified).AddTicks(3370), new TimeSpan(0, 8, 0, 0, 0)), "Keely.Conn@hotmail.com", new Guid("76e73c2a-0dca-37f0-8f17-35f8a7e7784b"), null, null, "Montana", 1, null, null, "11084" },
                    { new Guid("7ff44c43-52ba-4913-956e-4ce9df233d67"), "840 Elbert Parkway", null, "Altenwerthton", new Guid("40768e26-cc75-710e-180d-1a8870bbe1fc"), new DateTimeOffset(new DateTime(2023, 10, 2, 5, 1, 12, 89, DateTimeKind.Unspecified).AddTicks(6650), new TimeSpan(0, 8, 0, 0, 0)), "Chet_Shields30@gmail.com", new Guid("6b634acc-f313-c75a-09bc-dbc5296177d4"), null, null, "Idaho", 0, null, null, "79090" },
                    { new Guid("81b3f55b-d6c9-6a3d-45b4-1045dd858e77"), "309 Guy Mall", null, "Joseville", new Guid("023e17d9-9a71-a52a-ce57-5cbe8f77846b"), new DateTimeOffset(new DateTime(2024, 8, 8, 15, 55, 27, 685, DateTimeKind.Unspecified).AddTicks(3005), new TimeSpan(0, 8, 0, 0, 0)), "Shanel_Turcotte94@hotmail.com", new Guid("6b634acc-f313-c75a-09bc-dbc5296177d4"), null, null, "Rhode Island", 2, null, null, "45805-3594" },
                    { new Guid("f736fae2-9377-b4e4-9ae6-34732e0c58f4"), "771 Lennie Pines", null, "Krajcikmouth", new Guid("0dfa34ae-0a25-195d-fa9a-f0752d143f5a"), new DateTimeOffset(new DateTime(2023, 8, 21, 19, 28, 53, 621, DateTimeKind.Unspecified).AddTicks(6980), new TimeSpan(0, 8, 0, 0, 0)), "Magnolia14@hotmail.com", new Guid("4ce4bf8b-6ebc-9bf3-ff1a-42572f6a14a5"), null, null, "Colorado", 2, null, null, "37112-7245" },
                    { new Guid("fb6a96c3-d4b3-e17c-92aa-37bffc19a244"), "85339 Schulist Avenue", null, "West Antonehaven", new Guid("0dfa34ae-0a25-195d-fa9a-f0752d143f5a"), new DateTimeOffset(new DateTime(2024, 3, 11, 21, 53, 56, 741, DateTimeKind.Unspecified).AddTicks(9068), new TimeSpan(0, 8, 0, 0, 0)), "Vicenta.Monahan42@hotmail.com", new Guid("bf0115c9-d798-29cf-f6c1-68cede86c4a4"), null, null, "Mississippi", 1, null, null, "68901-9003" }
                });

            migrationBuilder.InsertData(
                table: "Publications",
                columns: new[] { "Id", "CountryId", "CreatedAtUtcNow", "CreatedBy", "DeletedAtUtcNow", "DeletedBy", "Description", "Name", "Status", "UpdatedAtUtcNow", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("4b9d2345-1d66-50a2-09be-a96c495da6f5"), new Guid("0dfa34ae-0a25-195d-fa9a-f0752d143f5a"), new DateTimeOffset(new DateTime(2023, 10, 14, 11, 11, 44, 68, DateTimeKind.Unspecified).AddTicks(4343), new TimeSpan(0, 8, 0, 0, 0)), "Cecelia70@hotmail.com", null, null, null, "Reilly LLC", 1, null, null },
                    { new Guid("b232d3cc-2f89-5e97-9112-c81d5b75bab3"), new Guid("0dfa34ae-0a25-195d-fa9a-f0752d143f5a"), new DateTimeOffset(new DateTime(2024, 7, 5, 7, 13, 10, 586, DateTimeKind.Unspecified).AddTicks(2036), new TimeSpan(0, 8, 0, 0, 0)), "Gerardo61@hotmail.com", null, null, null, "Pouros and Sons", 1, null, null },
                    { new Guid("bd8138d7-0148-c442-fb40-6396712c8490"), new Guid("9164ccb8-2c87-f6d1-e697-a7b3501651a8"), new DateTimeOffset(new DateTime(2024, 5, 21, 16, 34, 12, 795, DateTimeKind.Unspecified).AddTicks(511), new TimeSpan(0, 8, 0, 0, 0)), "Korey87@gmail.com", null, null, null, "Batz, Hudson and Boyle", 0, null, null },
                    { new Guid("f6e19544-452f-e8f1-8dc2-3e4fa3ae83fe"), new Guid("232b4a2c-bf44-14a8-b3f3-2a72fd2863fa"), new DateTimeOffset(new DateTime(2023, 10, 13, 12, 42, 32, 688, DateTimeKind.Unspecified).AddTicks(7817), new TimeSpan(0, 8, 0, 0, 0)), "Georgiana_Hettinger40@hotmail.com", null, null, null, "Reichel, Koelpin and McDermott", 0, null, null },
                    { new Guid("f9b3228b-4d2f-5901-4765-20e18a4b3bd7"), new Guid("9164ccb8-2c87-f6d1-e697-a7b3501651a8"), new DateTimeOffset(new DateTime(2023, 12, 14, 12, 58, 57, 272, DateTimeKind.Unspecified).AddTicks(9275), new TimeSpan(0, 8, 0, 0, 0)), "Marcia_Wiza26@gmail.com", null, null, null, "Mann, Herman and Bashirian", 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "AddressId", "CreatedAtUtcNow", "CreatedBy", "CustomerId", "DeletedAtUtcNow", "DeletedBy", "MagazineId", "Status", "UpdatedAtUtcNow", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("13d2d51f-da9f-cd2c-85af-0484ab563190"), new Guid("1e02f4dd-19dd-28c9-b255-9513ccaaa804"), new DateTimeOffset(new DateTime(2024, 2, 19, 22, 27, 27, 737, DateTimeKind.Unspecified).AddTicks(2019), new TimeSpan(0, 8, 0, 0, 0)), "Geoffrey_Howe@yahoo.com", new Guid("4a3b1021-693e-8246-202d-2056bef26878"), null, null, new Guid("ba8d0199-fea2-9162-e34e-e3ac6ac0bb5d"), 0, null, null },
                    { new Guid("297fc119-6aaa-a2e8-997e-b90db549c1cf"), new Guid("669e6cee-1bb7-0a6d-1f79-fcf0339c3a69"), new DateTimeOffset(new DateTime(2023, 10, 25, 7, 20, 58, 415, DateTimeKind.Unspecified).AddTicks(3764), new TimeSpan(0, 8, 0, 0, 0)), "Mariah52@gmail.com", new Guid("27f12e06-fdc7-94bb-ad2b-ad70d70797d0"), null, null, new Guid("a873eaf6-9467-f6e3-0be7-f4326f7cde08"), 1, null, null },
                    { new Guid("2d9156a3-40fd-0fc3-e13f-978b25da369b"), new Guid("7ff44c43-52ba-4913-956e-4ce9df233d67"), new DateTimeOffset(new DateTime(2023, 11, 30, 12, 19, 52, 86, DateTimeKind.Unspecified).AddTicks(7858), new TimeSpan(0, 8, 0, 0, 0)), "Patsy_Bartell88@hotmail.com", new Guid("6b634acc-f313-c75a-09bc-dbc5296177d4"), null, null, new Guid("252914b0-e150-ef18-35c2-f4e809b06df6"), 2, null, null },
                    { new Guid("3c967e03-d0cd-26b9-9615-cd8116f709fb"), new Guid("7e598b83-dd8b-e608-8b0e-3ffe2018053a"), new DateTimeOffset(new DateTime(2023, 12, 23, 22, 19, 24, 528, DateTimeKind.Unspecified).AddTicks(7829), new TimeSpan(0, 8, 0, 0, 0)), "Darryl42@hotmail.com", new Guid("76e73c2a-0dca-37f0-8f17-35f8a7e7784b"), null, null, new Guid("b4043dfa-483a-2fd1-b792-990dfb436a7b"), 1, null, null },
                    { new Guid("3d427b90-193d-1ea8-e8ff-df0dac763945"), new Guid("6754f590-402e-eca5-4fe4-410e28a44185"), new DateTimeOffset(new DateTime(2023, 12, 30, 4, 13, 39, 14, DateTimeKind.Unspecified).AddTicks(3390), new TimeSpan(0, 8, 0, 0, 0)), "Lauryn.Rice83@yahoo.com", new Guid("95a21bd4-b409-b5fa-fcdc-25b02cc7d807"), null, null, new Guid("03728bdb-5ebd-8a36-05d5-d1210938b333"), 2, null, null },
                    { new Guid("429a6466-2666-2728-c632-50d1b3233b31"), new Guid("14185642-798c-ae7d-55cf-1cde5b558b7f"), new DateTimeOffset(new DateTime(2024, 7, 12, 19, 32, 37, 634, DateTimeKind.Unspecified).AddTicks(9881), new TimeSpan(0, 8, 0, 0, 0)), "Bertrand10@gmail.com", new Guid("f932b0a7-2115-591f-1dc6-5945d22dea68"), null, null, new Guid("94387622-249d-6a20-69f2-ec3cb031d400"), 0, null, null },
                    { new Guid("5e5a4fe9-9b38-1a4c-83b6-44b06bdf5445"), new Guid("18c24b15-7316-e91c-a9e0-023e249179ec"), new DateTimeOffset(new DateTime(2023, 9, 2, 4, 58, 42, 137, DateTimeKind.Unspecified).AddTicks(850), new TimeSpan(0, 8, 0, 0, 0)), "Okey68@gmail.com", new Guid("f9aee77d-22f8-6e91-a828-763fe2b6659c"), null, null, new Guid("97eb8ce7-63c1-e2b7-3b7a-d3d8f45195fa"), 2, null, null },
                    { new Guid("6e918027-d5f9-9cb2-a0fc-c13f11b6f549"), new Guid("54db743c-c9a2-65d2-2d98-fc3cd5015ec4"), new DateTimeOffset(new DateTime(2023, 12, 23, 11, 57, 1, 390, DateTimeKind.Unspecified).AddTicks(5101), new TimeSpan(0, 8, 0, 0, 0)), "Waylon_Christiansen@gmail.com", new Guid("7975fd4d-69a4-6e62-4229-8b52c78f0131"), null, null, new Guid("826e391a-056a-f038-69f8-29e0faa34a55"), 0, null, null },
                    { new Guid("8656dd07-23c9-9edf-05ee-01bef7035ab1"), new Guid("f736fae2-9377-b4e4-9ae6-34732e0c58f4"), new DateTimeOffset(new DateTime(2023, 9, 10, 18, 43, 8, 100, DateTimeKind.Unspecified).AddTicks(9134), new TimeSpan(0, 8, 0, 0, 0)), "Lewis85@gmail.com", new Guid("4ce4bf8b-6ebc-9bf3-ff1a-42572f6a14a5"), null, null, new Guid("24e53ebf-fc8c-85c6-8f84-844c74cfeac6"), 0, null, null },
                    { new Guid("903209c4-c453-5542-54d0-30f58a060b43"), new Guid("5f39b59f-9e8c-9da3-ab22-7e2d6482e4b2"), new DateTimeOffset(new DateTime(2024, 4, 26, 8, 51, 3, 80, DateTimeKind.Unspecified).AddTicks(4709), new TimeSpan(0, 8, 0, 0, 0)), "Jerry13@gmail.com", new Guid("bf0115c9-d798-29cf-f6c1-68cede86c4a4"), null, null, new Guid("361123a7-6d87-c45f-3cd7-5e58b655baef"), 2, null, null },
                    { new Guid("a23b4a08-de88-ad79-186d-3baf56de5656"), new Guid("5b88983d-048e-da5f-f227-2cac3a2e669e"), new DateTimeOffset(new DateTime(2024, 1, 21, 10, 9, 49, 37, DateTimeKind.Unspecified).AddTicks(7993), new TimeSpan(0, 8, 0, 0, 0)), "Zita_Howell15@yahoo.com", new Guid("7975fd4d-69a4-6e62-4229-8b52c78f0131"), null, null, new Guid("dea675bd-8ebc-11d2-b838-6e5207f6e03a"), 0, null, null },
                    { new Guid("a78f9971-b97e-671a-dbe6-990e3b8fccf6"), new Guid("4abdf487-c1e2-2188-bde5-0bbfb2b10b7d"), new DateTimeOffset(new DateTime(2024, 3, 8, 8, 46, 41, 961, DateTimeKind.Unspecified).AddTicks(1981), new TimeSpan(0, 8, 0, 0, 0)), "Melisa_Pfannerstill53@hotmail.com", new Guid("daf5e673-765e-4956-7876-5a74c967046d"), null, null, new Guid("1dab55c0-32dc-feef-3c70-c49584f3a3e2"), 2, null, null },
                    { new Guid("b04d6413-b15c-255f-3ccf-ebc695e07029"), new Guid("66195908-6114-bb53-a31f-791a766ea9b1"), new DateTimeOffset(new DateTime(2024, 7, 1, 1, 49, 29, 928, DateTimeKind.Unspecified).AddTicks(3509), new TimeSpan(0, 8, 0, 0, 0)), "Garrick.Harber38@hotmail.com", new Guid("18c4807f-b67a-61bd-5b25-87d61b61ad1b"), null, null, new Guid("1fe19421-2989-bdda-71d5-7f39b5df5958"), 0, null, null },
                    { new Guid("b54a3824-0c65-9822-0d69-399d8bc17660"), new Guid("3329cdb7-366f-0686-442f-482bec442af7"), new DateTimeOffset(new DateTime(2024, 3, 24, 10, 7, 50, 317, DateTimeKind.Unspecified).AddTicks(7444), new TimeSpan(0, 8, 0, 0, 0)), "Jonas_Dare@gmail.com", new Guid("3b6237d7-3571-fa61-6c3e-f9d8379f0bea"), null, null, new Guid("2cc51d03-3369-92dc-ae0f-94b775a3abbf"), 2, null, null },
                    { new Guid("b5fdf1a0-f402-ecca-a7f0-603a2b089834"), new Guid("596fffe0-8de3-d5f2-cefc-5829fa22c6ca"), new DateTimeOffset(new DateTime(2024, 4, 7, 21, 18, 56, 278, DateTimeKind.Unspecified).AddTicks(4790), new TimeSpan(0, 8, 0, 0, 0)), "Evans.Shanahan17@yahoo.com", new Guid("75537c47-807f-fced-6300-764e0ef57c31"), null, null, new Guid("94387622-249d-6a20-69f2-ec3cb031d400"), 0, null, null },
                    { new Guid("c8e438a0-44cc-b884-e3c9-a78e449f63ce"), new Guid("81b3f55b-d6c9-6a3d-45b4-1045dd858e77"), new DateTimeOffset(new DateTime(2024, 1, 6, 10, 2, 35, 856, DateTimeKind.Unspecified).AddTicks(8020), new TimeSpan(0, 8, 0, 0, 0)), "Yesenia_Torphy@hotmail.com", new Guid("6b634acc-f313-c75a-09bc-dbc5296177d4"), null, null, new Guid("26243396-eaa2-725e-1dfb-cb47b27eb6a2"), 0, null, null },
                    { new Guid("cca62c16-0070-cb25-c3a2-cc4c640d5b7b"), new Guid("0b671d90-91d3-3e09-8a28-ccd71e534b07"), new DateTimeOffset(new DateTime(2023, 11, 29, 21, 56, 13, 371, DateTimeKind.Unspecified).AddTicks(7518), new TimeSpan(0, 8, 0, 0, 0)), "Noelia.King@yahoo.com", new Guid("209abb0f-0b38-d0a0-c4d9-a9e9777c26b9"), null, null, new Guid("03d6c4b6-f727-9a23-be99-13fb7135799b"), 1, null, null },
                    { new Guid("ed10dd61-23a2-bfb8-8a35-2cfb9862ff6f"), new Guid("fb6a96c3-d4b3-e17c-92aa-37bffc19a244"), new DateTimeOffset(new DateTime(2024, 4, 12, 19, 7, 42, 359, DateTimeKind.Unspecified).AddTicks(8961), new TimeSpan(0, 8, 0, 0, 0)), "Bernhard_Raynor13@gmail.com", new Guid("bf0115c9-d798-29cf-f6c1-68cede86c4a4"), null, null, new Guid("720dad4a-6ac3-30b6-4592-8f55328e2b7a"), 1, null, null },
                    { new Guid("f4b256d1-f02e-034f-3042-5b36e0c4b040"), new Guid("4ef7f69b-169e-e612-19b8-888e12f3e459"), new DateTimeOffset(new DateTime(2024, 1, 5, 6, 51, 0, 472, DateTimeKind.Unspecified).AddTicks(8685), new TimeSpan(0, 8, 0, 0, 0)), "Sam_Runolfsdottir@hotmail.com", new Guid("7975fd4d-69a4-6e62-4229-8b52c78f0131"), null, null, new Guid("1043960e-9d7b-4c8e-3a1b-1c33105fd775"), 1, null, null },
                    { new Guid("f582b336-efde-3298-e37c-62b626dbf63b"), new Guid("7d639d04-9601-ceb9-b54d-ffbcc122808b"), new DateTimeOffset(new DateTime(2024, 7, 28, 18, 36, 6, 374, DateTimeKind.Unspecified).AddTicks(999), new TimeSpan(0, 8, 0, 0, 0)), "Alexandra66@gmail.com", new Guid("27f12e06-fdc7-94bb-ad2b-ad70d70797d0"), null, null, new Guid("17af1a49-5ed5-aeba-dc58-da79cc784f42"), 0, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                table: "Addresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_CountryId",
                table: "Publications",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_AddressId",
                table: "Subscriptions",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_CustomerId",
                table: "Subscriptions",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_MagazineId",
                table: "Subscriptions",
                column: "MagazineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Publications");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Magazines");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
