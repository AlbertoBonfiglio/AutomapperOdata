using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthIR.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(maxLength: 24, nullable: false, defaultValue: "EventType"),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 48, nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 48, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    Name = table.Column<string>(maxLength: 48, nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncidentTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(maxLength: 24, nullable: false, defaultValue: "IncidentType"),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 48, nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 48, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    Name = table.Column<string>(maxLength: 48, nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: false),
                    IsCritical = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(maxLength: 24, nullable: false, defaultValue: "Location"),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 48, nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 48, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    Name = table.Column<string>(maxLength: 48, nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(maxLength: 24, nullable: false, defaultValue: "PersonType"),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 48, nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 48, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    Name = table.Column<string>(maxLength: 48, nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(maxLength: 24, nullable: false, defaultValue: "JSONSetting"),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 48, nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 48, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false, defaultValue: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    JSONDocument = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(maxLength: 24, nullable: false, defaultValue: "IncidentReport"),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 24, nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 24, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    EmployeeId = table.Column<string>(maxLength: 48, nullable: false),
                    FirstName = table.Column<string>(maxLength: 48, nullable: false),
                    LastName = table.Column<string>(maxLength: 48, nullable: false),
                    Date = table.Column<DateTimeOffset>(nullable: false),
                    MRN = table.Column<string>(maxLength: 24, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 24, nullable: false),
                    Content = table.Column<string>(nullable: false),
                    IncidentTypeId = table.Column<Guid>(nullable: false),
                    PersonTypeId = table.Column<Guid>(nullable: false),
                    LocationId = table.Column<Guid>(nullable: false),
                    Finalized = table.Column<bool>(nullable: false, defaultValue: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incidents_IncidentTypes_IncidentTypeId",
                        column: x => x.IncidentTypeId,
                        principalTable: "IncidentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidents_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidents_PersonTypes_PersonTypeId",
                        column: x => x.PersonTypeId,
                        principalTable: "PersonTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(maxLength: 24, nullable: false, defaultValue: "IncidentAction"),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 24, nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 24, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    EmployeeId = table.Column<string>(maxLength: 48, nullable: false),
                    FirstName = table.Column<string>(maxLength: 48, nullable: false),
                    LastName = table.Column<string>(maxLength: 48, nullable: false),
                    Date = table.Column<DateTimeOffset>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    Complete = table.Column<bool>(nullable: false, defaultValue: false),
                    ReportId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actions_Incidents_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Incidents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(maxLength: 24, nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 24, nullable: false),
                    ModifiedBy = table.Column<string>(maxLength: 24, nullable: true),
                    ModifiedDate = table.Column<DateTimeOffset>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    MediaType = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: false),
                    ReportId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachments_Incidents_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Incidents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IncidentEventType",
                columns: table => new
                {
                    ReportId = table.Column<Guid>(nullable: false),
                    EventTypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidentEventType", x => new { x.ReportId, x.EventTypeId });
                    table.ForeignKey(
                        name: "FK_IncidentEventType_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IncidentEventType_Incidents_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Incidents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("319ab0d2-fe70-4a06-aaa3-c9809b8f7b09"), "SYSTEM", new DateTimeOffset(new DateTime(2020, 3, 25, 18, 52, 50, 196, DateTimeKind.Unspecified).AddTicks(5720), new TimeSpan(0, -7, 0, 0, 0)), "", null, null, "Medication Error" },
                    { new Guid("4f805c2a-2f98-46ec-a928-e718fa6adcaf"), "SYSTEM", new DateTimeOffset(new DateTime(2020, 3, 25, 18, 52, 50, 196, DateTimeKind.Unspecified).AddTicks(5807), new TimeSpan(0, -7, 0, 0, 0)), "", null, null, "Lab Error" },
                    { new Guid("26de5c77-d0ec-455b-8764-b6422cc6fe71"), "SYSTEM", new DateTimeOffset(new DateTime(2020, 3, 25, 18, 52, 50, 196, DateTimeKind.Unspecified).AddTicks(5815), new TimeSpan(0, -7, 0, 0, 0)), "", null, null, "Medical Alert" }
                });

            migrationBuilder.InsertData(
                table: "IncidentTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsCritical", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("03ab5e22-f2b7-409f-b9bc-6627cb36246b"), "SYSTEM", new DateTimeOffset(new DateTime(2020, 3, 25, 18, 52, 50, 182, DateTimeKind.Unspecified).AddTicks(6191), new TimeSpan(0, -7, 0, 0, 0)), "", false, null, null, "Incident" },
                    { new Guid("f01326f6-f5d3-4109-9f5e-ca62ecae498f"), "SYSTEM", new DateTimeOffset(new DateTime(2020, 3, 25, 18, 52, 50, 193, DateTimeKind.Unspecified).AddTicks(6392), new TimeSpan(0, -7, 0, 0, 0)), "", false, null, null, "Near Miss" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("29be4b00-82a7-4542-9ccc-71c2c55afca3"), "SYSTEM", new DateTimeOffset(new DateTime(2020, 3, 25, 18, 52, 50, 202, DateTimeKind.Unspecified).AddTicks(5351), new TimeSpan(0, -7, 0, 0, 0)), "", null, null, "BHC" },
                    { new Guid("88c5b999-91be-4e3b-aa5d-0d013d51af25"), "SYSTEM", new DateTimeOffset(new DateTime(2020, 3, 25, 18, 52, 50, 202, DateTimeKind.Unspecified).AddTicks(5395), new TimeSpan(0, -7, 0, 0, 0)), "", null, null, "ELHC" },
                    { new Guid("0827b871-cb71-4e2c-bd6b-91f04e19f5be"), "SYSTEM", new DateTimeOffset(new DateTime(2020, 3, 25, 18, 52, 50, 202, DateTimeKind.Unspecified).AddTicks(5403), new TimeSpan(0, -7, 0, 0, 0)), "", null, null, "LHC" },
                    { new Guid("1e5f0070-2bc0-4f26-9baf-b8b420d7d025"), "SYSTEM", new DateTimeOffset(new DateTime(2020, 3, 25, 18, 52, 50, 202, DateTimeKind.Unspecified).AddTicks(5410), new TimeSpan(0, -7, 0, 0, 0)), "", null, null, "MHC" },
                    { new Guid("6005c635-f9c2-474d-bbc2-1886f6fd4872"), "SYSTEM", new DateTimeOffset(new DateTime(2020, 3, 25, 18, 52, 50, 202, DateTimeKind.Unspecified).AddTicks(5416), new TimeSpan(0, -7, 0, 0, 0)), "", null, null, "AHC" },
                    { new Guid("24eb134d-a990-41ce-b601-aa741d748399"), "SYSTEM", new DateTimeOffset(new DateTime(2020, 3, 25, 18, 52, 50, 202, DateTimeKind.Unspecified).AddTicks(5423), new TimeSpan(0, -7, 0, 0, 0)), "", null, null, "SHHC" },
                    { new Guid("3ec90d4a-0d4b-4773-a092-3ba699c9742b"), "SYSTEM", new DateTimeOffset(new DateTime(2020, 3, 25, 18, 52, 50, 202, DateTimeKind.Unspecified).AddTicks(5429), new TimeSpan(0, -7, 0, 0, 0)), "", null, null, "SUNSET" }
                });

            migrationBuilder.InsertData(
                table: "PersonTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("e61d2dc9-3824-4376-a561-2e6350817f58"), "SYSTEM", new DateTimeOffset(new DateTime(2020, 3, 25, 18, 52, 50, 198, DateTimeKind.Unspecified).AddTicks(2684), new TimeSpan(0, -7, 0, 0, 0)), "", null, null, "Employee" },
                    { new Guid("c1a8a91c-7606-40e2-9291-4b7a1a6b23cc"), "SYSTEM", new DateTimeOffset(new DateTime(2020, 3, 25, 18, 52, 50, 198, DateTimeKind.Unspecified).AddTicks(2751), new TimeSpan(0, -7, 0, 0, 0)), "", null, null, "Visitor" },
                    { new Guid("e0a12ab9-3aa1-4ace-9ebb-0b8a5f52276f"), "SYSTEM", new DateTimeOffset(new DateTime(2020, 3, 25, 18, 52, 50, 198, DateTimeKind.Unspecified).AddTicks(2760), new TimeSpan(0, -7, 0, 0, 0)), "", null, null, "Client/Patient" }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Type", "JSONDocument" },
                values: new object[] { new Guid("4a478f30-00bd-4172-aa58-3ed61ddcbc7f"), "SYSTEM", new DateTimeOffset(new DateTime(2020, 3, 25, 18, 52, 50, 356, DateTimeKind.Unspecified).AddTicks(1417), new TimeSpan(0, -7, 0, 0, 0)), null, null, "HIRConfiguration", @"{
  ""complianceManager"": ""Korey_Rempel24@gmail.com"",
  ""himManager"": ""America.Huel51@gmail.com"",
  ""safetyCoordinator"": ""Lea.Kulas18@hotmail.com"",
  ""financeDirector"": ""Maggie.Denesik@gmail.com"",
  ""countyCouncil"": ""Kelvin84@gmail.com""
}" });

            migrationBuilder.CreateIndex(
                name: "IX_Actions_Complete",
                table: "Actions",
                column: "Complete");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_Date",
                table: "Actions",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_Actions_ReportId",
                table: "Actions",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_ReportId",
                table: "Attachments",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTypes_Deleted",
                table: "EventTypes",
                column: "Deleted");

            migrationBuilder.CreateIndex(
                name: "IX_EventTypes_Type",
                table: "EventTypes",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentEventType_EventTypeId",
                table: "IncidentEventType",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_Date",
                table: "Incidents",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_EmployeeId",
                table: "Incidents",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_IncidentTypeId",
                table: "Incidents",
                column: "IncidentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_LocationId",
                table: "Incidents",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_PersonTypeId",
                table: "Incidents",
                column: "PersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentTypes_Deleted",
                table: "IncidentTypes",
                column: "Deleted");

            migrationBuilder.CreateIndex(
                name: "IX_IncidentTypes_Name",
                table: "IncidentTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IncidentTypes_Type",
                table: "IncidentTypes",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Deleted",
                table: "Locations",
                column: "Deleted");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Name",
                table: "Locations",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Type",
                table: "Locations",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_PersonTypes_Deleted",
                table: "PersonTypes",
                column: "Deleted");

            migrationBuilder.CreateIndex(
                name: "IX_PersonTypes_Name",
                table: "PersonTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonTypes_Type",
                table: "PersonTypes",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_Deleted",
                table: "Settings",
                column: "Deleted");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_Type",
                table: "Settings",
                column: "Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "IncidentEventType");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "EventTypes");

            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropTable(
                name: "IncidentTypes");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "PersonTypes");
        }
    }
}
