using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class initialcommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    PKRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    created = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Role__B96213F4837A76E6", x => x.PKRoleId);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    PKUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    created = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    FKRoleId = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserProf__CCB89530EAC38D6B", x => x.PKUserId);
                    table.ForeignKey(
                        name: "FK_UserProfile_Role",
                        column: x => x.FKRoleId,
                        principalTable: "Role",
                        principalColumn: "PKRoleId");
                });

            migrationBuilder.CreateTable(
                name: "Hostel",
                columns: table => new
                {
                    PKHostelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HostelName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    created = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    FKCreatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Hostel__EB7BBC4A0FB5BEF7", x => x.PKHostelId);
                    table.ForeignKey(
                        name: "FK_Hostel_UserProfile",
                        column: x => x.FKCreatedBy,
                        principalTable: "UserProfile",
                        principalColumn: "PKUserId");
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    PKBranchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Location = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    FKCreatedBy = table.Column<int>(type: "int", nullable: true),
                    FKHostelId = table.Column<int>(type: "int", nullable: true),
                    created = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Branch__A699DE14FF64BD75", x => x.PKBranchId);
                    table.ForeignKey(
                        name: "FK_Branch_Hostel",
                        column: x => x.FKHostelId,
                        principalTable: "Hostel",
                        principalColumn: "PKHostelId");
                    table.ForeignKey(
                        name: "FK_Branch_UserProfile",
                        column: x => x.FKCreatedBy,
                        principalTable: "UserProfile",
                        principalColumn: "PKUserId");
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    PKRoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    RoomStatus = table.Column<byte>(type: "tinyint", nullable: true),
                    FKBranchId = table.Column<int>(type: "int", nullable: true),
                    created = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    FKHostelId = table.Column<int>(type: "int", nullable: false),
                    NumberOfBeds = table.Column<int>(type: "int", nullable: true),
                    IsGuestRoom = table.Column<bool>(type: "bit", nullable: true),
                    RoomType = table.Column<byte>(type: "tinyint", nullable: true),
                    FilledBeds = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Room__4D64ACC37C5529DE", x => x.PKRoomId);
                    table.ForeignKey(
                        name: "FK_Room_Branch_FKBranchId",
                        column: x => x.FKBranchId,
                        principalTable: "Branch",
                        principalColumn: "PKBranchId");
                    table.ForeignKey(
                        name: "FK_Room_Hostel_FKHostelId",
                        column: x => x.FKHostelId,
                        principalTable: "Hostel",
                        principalColumn: "PKHostelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomBed",
                columns: table => new
                {
                    PKBedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BedName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    IsActive = table.Column<byte>(type: "tinyint", nullable: true),
                    FKRoomId = table.Column<int>(type: "int", nullable: true),
                    created = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    FKCreatedby = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    FKModifiedBy = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RoomBed__14EF6E39FD9903B5", x => x.PKBedId);
                    table.ForeignKey(
                        name: "FK_RoomBed_Room",
                        column: x => x.FKRoomId,
                        principalTable: "Room",
                        principalColumn: "PKRoomId");
                });

            migrationBuilder.CreateTable(
                name: "Tenant",
                columns: table => new
                {
                    PKTenantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    MobileNo = table.Column<long>(type: "bigint", nullable: false),
                    EmailId = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    PhotoURL = table.Column<byte[]>(type: "image", nullable: true),
                    ProofName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    ProofID = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Designation = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    OfficeAddress = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    HomeAddress = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    RegisteredDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    MonthlyFee = table.Column<decimal>(type: "money", nullable: true),
                    IsActive = table.Column<byte>(type: "tinyint", nullable: true),
                    created = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    FKCreatedby = table.Column<int>(type: "int", nullable: true),
                    FKModifiedBy = table.Column<int>(type: "int", nullable: true),
                    DocumentUrl = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    AdvancePayment = table.Column<decimal>(type: "money", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    IsCoLiveIn = table.Column<bool>(type: "bit", nullable: true),
                    FKRoomId = table.Column<int>(type: "int", nullable: false),
                    FoodCard = table.Column<byte>(type: "tinyint", nullable: true),
                    Gender = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tenant__C9A21FB50CA9CAFB", x => x.PKTenantId);
                    table.ForeignKey(
                        name: "FK_Tenant_Room",
                        column: x => x.FKRoomId,
                        principalTable: "Room",
                        principalColumn: "PKRoomId");
                    table.ForeignKey(
                        name: "FK_Tenant_UserProfile",
                        column: x => x.FKCreatedby,
                        principalTable: "UserProfile",
                        principalColumn: "PKUserId");
                    table.ForeignKey(
                        name: "FK_Tenant1_UserProfile",
                        column: x => x.FKModifiedBy,
                        principalTable: "UserProfile",
                        principalColumn: "PKUserId");
                });

            migrationBuilder.CreateTable(
                name: "FeeDetails",
                columns: table => new
                {
                    PKFeeDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeeAmount = table.Column<decimal>(type: "money", nullable: true),
                    DueAmount = table.Column<decimal>(type: "money", nullable: true),
                    FeeDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    FeeMode = table.Column<byte>(type: "tinyint", nullable: true),
                    TransactionId = table.Column<int>(type: "int", nullable: false),
                    TransactionType = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    FKTenantId = table.Column<int>(type: "int", nullable: true),
                    created = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    FKCreatedby = table.Column<int>(type: "int", nullable: true),
                    FKModifiedBy = table.Column<int>(type: "int", nullable: true),
                    AdditionalAmount = table.Column<decimal>(type: "money", nullable: true),
                    status = table.Column<byte>(type: "tinyint", nullable: true),
                    PaidDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    FoodBill = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FeeDetai__88B3EF8CE37A962B", x => x.PKFeeDetailsId);
                    table.ForeignKey(
                        name: "FK_FeeDetails_Tenant",
                        column: x => x.FKTenantId,
                        principalTable: "Tenant",
                        principalColumn: "PKTenantId");
                    table.ForeignKey(
                        name: "FK_FeeDetails1_UserProfile",
                        column: x => x.FKCreatedby,
                        principalTable: "UserProfile",
                        principalColumn: "PKUserId");
                    table.ForeignKey(
                        name: "FK_FeeDetails2_UserProfile",
                        column: x => x.FKModifiedBy,
                        principalTable: "UserProfile",
                        principalColumn: "PKUserId");
                });

            migrationBuilder.CreateTable(
                name: "TenantBedMapping",
                columns: table => new
                {
                    PKTenantBedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKBedId = table.Column<int>(type: "int", nullable: true),
                    FKTenantId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    created = table.Column<DateTime>(type: "datetime", nullable: true),
                    modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    FKCreatedby = table.Column<int>(type: "int", nullable: true),
                    FKModifiedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TenantBe__31CF726F407417E2", x => x.PKTenantBedId);
                    table.ForeignKey(
                        name: "FK_TenantBedMapping_RoomBed",
                        column: x => x.FKBedId,
                        principalTable: "RoomBed",
                        principalColumn: "PKBedId");
                    table.ForeignKey(
                        name: "FK_TenantBedMapping1_Tenant",
                        column: x => x.FKTenantId,
                        principalTable: "Tenant",
                        principalColumn: "PKTenantId");
                    table.ForeignKey(
                        name: "FK_TenantBedMapping2_UserProfile",
                        column: x => x.FKCreatedby,
                        principalTable: "UserProfile",
                        principalColumn: "PKUserId");
                    table.ForeignKey(
                        name: "FK_TenantBedMapping3_UserProfile",
                        column: x => x.FKModifiedBy,
                        principalTable: "UserProfile",
                        principalColumn: "PKUserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branch_FKCreatedBy",
                table: "Branch",
                column: "FKCreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_FKHostelId",
                table: "Branch",
                column: "FKHostelId");

            migrationBuilder.CreateIndex(
                name: "IX_FeeDetails_FKCreatedby",
                table: "FeeDetails",
                column: "FKCreatedby");

            migrationBuilder.CreateIndex(
                name: "IX_FeeDetails_FKModifiedBy",
                table: "FeeDetails",
                column: "FKModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_FeeDetails_FKTenantId",
                table: "FeeDetails",
                column: "FKTenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Hostel_FKCreatedBy",
                table: "Hostel",
                column: "FKCreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Room_FKBranchId",
                table: "Room",
                column: "FKBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_FKHostelId",
                table: "Room",
                column: "FKHostelId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomBed_FKRoomId",
                table: "RoomBed",
                column: "FKRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenant_FKCreatedby",
                table: "Tenant",
                column: "FKCreatedby");

            migrationBuilder.CreateIndex(
                name: "IX_Tenant_FKModifiedBy",
                table: "Tenant",
                column: "FKModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Tenant_FKRoomId",
                table: "Tenant",
                column: "FKRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantBedMapping_FKBedId",
                table: "TenantBedMapping",
                column: "FKBedId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantBedMapping_FKCreatedby",
                table: "TenantBedMapping",
                column: "FKCreatedby");

            migrationBuilder.CreateIndex(
                name: "IX_TenantBedMapping_FKModifiedBy",
                table: "TenantBedMapping",
                column: "FKModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_TenantBedMapping_FKTenantId",
                table: "TenantBedMapping",
                column: "FKTenantId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_FKRoleId",
                table: "UserProfile",
                column: "FKRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeeDetails");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "TenantBedMapping");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "RoomBed");

            migrationBuilder.DropTable(
                name: "Tenant");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "Hostel");

            migrationBuilder.DropTable(
                name: "UserProfile");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
