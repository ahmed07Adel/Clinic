using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinic.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BedTypeId = table.Column<int>(type: "int", nullable: false),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false),
                    BedType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ward = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Room = table.Column<int>(type: "int", nullable: false),
                    BedNumber = table.Column<int>(type: "int", nullable: false),
                    BedBillingClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdmissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PadiatricandNeonates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PadiatricandNeonates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Admissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdmissionRequestNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddminssionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientTypeId = table.Column<int>(type: "int", nullable: false),
                    PatientSubTypeId = table.Column<int>(type: "int", nullable: false),
                    TrafficScheme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimatedLengthOfDays = table.Column<int>(type: "int", nullable: false),
                    AdmittingDoctor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoctorInCharge = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ERAdmission = table.Column<bool>(type: "bit", nullable: false),
                    HasPatientMobile = table.Column<bool>(type: "bit", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialInstructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BedId = table.Column<int>(type: "int", nullable: false),
                    ServiceAdviced = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MedicalIsolation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admissions_Beds_BedId",
                        column: x => x.BedId,
                        principalTable: "Beds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Admissions_PatientTypes_PatientSubTypeId",
                        column: x => x.PatientSubTypeId,
                        principalTable: "PatientTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Admissions_PatientTypes_PatientTypeId",
                        column: x => x.PatientTypeId,
                        principalTable: "PatientTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdmissionPadiatricandNeonates",
                columns: table => new
                {
                    AdmissionId = table.Column<int>(type: "int", nullable: false),
                    PadiatricandNeonateId = table.Column<int>(type: "int", nullable: false),
                    AdmissionId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmissionPadiatricandNeonates", x => new { x.AdmissionId, x.PadiatricandNeonateId });
                    table.ForeignKey(
                        name: "FK_AdmissionPadiatricandNeonates_Admissions_AdmissionId1",
                        column: x => x.AdmissionId1,
                        principalTable: "Admissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdmissionPadiatricandNeonates_PadiatricandNeonates_PadiatricandNeonateId",
                        column: x => x.PadiatricandNeonateId,
                        principalTable: "PadiatricandNeonates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionPadiatricandNeonates_AdmissionId1",
                table: "AdmissionPadiatricandNeonates",
                column: "AdmissionId1");

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionPadiatricandNeonates_PadiatricandNeonateId",
                table: "AdmissionPadiatricandNeonates",
                column: "PadiatricandNeonateId");

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_BedId",
                table: "Admissions",
                column: "BedId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_PatientSubTypeId",
                table: "Admissions",
                column: "PatientSubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_PatientTypeId",
                table: "Admissions",
                column: "PatientTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdmissionPadiatricandNeonates");

            migrationBuilder.DropTable(
                name: "Admissions");

            migrationBuilder.DropTable(
                name: "PadiatricandNeonates");

            migrationBuilder.DropTable(
                name: "Beds");

            migrationBuilder.DropTable(
                name: "PatientTypes");
        }
    }
}
