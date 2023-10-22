using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NoteMDBackend.Migrations
{
    /// <inheritdoc />
    public partial class afterdeleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ImageURL = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ProgramEnrolled = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Designation = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Markdown = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Visibility = table.Column<string>(type: "text", nullable: false),
                    CourseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notes_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Message = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    NoteId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Notes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Notes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NoteLikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    NoteId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoteLikes_Notes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Notes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NoteLikes_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    NoteId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Notes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Notes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Description", "Designation", "FirstName", "ImageURL", "LastName", "ProgramEnrolled", "Status", "UpdatedAt", "Username" },
                values: new object[] { "1", new DateTimeOffset(new DateTime(2023, 10, 22, 12, 47, 2, 954, DateTimeKind.Unspecified).AddTicks(5948), new TimeSpan(0, -4, 0, 0, 0)), "Admin", "Admin", "Admin", "https://i.imgur.com/6VBx3io.png", "Admin", "Admin", "Active", new DateTimeOffset(new DateTime(2023, 10, 22, 12, 47, 2, 954, DateTimeKind.Unspecified).AddTicks(6013), new TimeSpan(0, -4, 0, 0, 0)), "admin" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Code", "CreatedAt", "CreatedBy", "Description", "Name", "Status" },
                values: new object[,]
                {
                    { 1, "C#", new DateTimeOffset(new DateTime(2023, 10, 22, 12, 47, 2, 954, DateTimeKind.Unspecified).AddTicks(6130), new TimeSpan(0, -4, 0, 0, 0)), "1", "C#", "C#", "Active" },
                    { 2, "Java", new DateTimeOffset(new DateTime(2023, 10, 22, 12, 47, 2, 954, DateTimeKind.Unspecified).AddTicks(6140), new TimeSpan(0, -4, 0, 0, 0)), "1", "Java", "Java", "Active" },
                    { 3, "Python", new DateTimeOffset(new DateTime(2023, 10, 22, 12, 47, 2, 954, DateTimeKind.Unspecified).AddTicks(6143), new TimeSpan(0, -4, 0, 0, 0)), "1", "Python", "Python", "Active" },
                    { 4, "C++", new DateTimeOffset(new DateTime(2023, 10, 22, 12, 47, 2, 954, DateTimeKind.Unspecified).AddTicks(6146), new TimeSpan(0, -4, 0, 0, 0)), "1", "C++", "C++", "Active" },
                    { 5, "JavaScript", new DateTimeOffset(new DateTime(2023, 10, 22, 12, 47, 2, 954, DateTimeKind.Unspecified).AddTicks(6149), new TimeSpan(0, -4, 0, 0, 0)), "1", "JavaScript", "JavaScript", "Active" },
                    { 6, "PHP", new DateTimeOffset(new DateTime(2023, 10, 22, 12, 47, 2, 954, DateTimeKind.Unspecified).AddTicks(6152), new TimeSpan(0, -4, 0, 0, 0)), "1", "PHP", "PHP", "Active" },
                    { 7, "HTML", new DateTimeOffset(new DateTime(2023, 10, 22, 12, 47, 2, 954, DateTimeKind.Unspecified).AddTicks(6155), new TimeSpan(0, -4, 0, 0, 0)), "1", "HTML", "HTML", "Active" },
                    { 8, "CSS", new DateTimeOffset(new DateTime(2023, 10, 22, 12, 47, 2, 954, DateTimeKind.Unspecified).AddTicks(6158), new TimeSpan(0, -4, 0, 0, 0)), "1", "CSS", "CSS", "Active" },
                    { 9, "SQL", new DateTimeOffset(new DateTime(2023, 10, 22, 12, 47, 2, 954, DateTimeKind.Unspecified).AddTicks(6164), new TimeSpan(0, -4, 0, 0, 0)), "1", "SQL", "SQL", "Active" },
                    { 10, "Ruby", new DateTimeOffset(new DateTime(2023, 10, 22, 12, 47, 2, 954, DateTimeKind.Unspecified).AddTicks(6167), new TimeSpan(0, -4, 0, 0, 0)), "1", "Ruby", "Ruby", "Active" },
                    { 11, "Swift", new DateTimeOffset(new DateTime(2023, 10, 22, 12, 47, 2, 954, DateTimeKind.Unspecified).AddTicks(6170), new TimeSpan(0, -4, 0, 0, 0)), "1", "Swift", "Swift", "Active" }
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "CourseId", "CreatedAt", "CreatedBy", "Markdown", "Status", "Title", "UpdatedAt", "Visibility" },
                values: new object[,]
                {
                    { new Guid("0167c287-2b4f-4c26-a7cc-dca28c001b1b"), 4, new DateTimeOffset(new DateTime(2023, 10, 22, 12, 47, 2, 954, DateTimeKind.Unspecified).AddTicks(6274), new TimeSpan(0, -4, 0, 0, 0)), "1", "C++", "Active", "C++", new DateTimeOffset(new DateTime(2023, 10, 22, 12, 47, 2, 954, DateTimeKind.Unspecified).AddTicks(6277), new TimeSpan(0, -4, 0, 0, 0)), "Public" },
                    { new Guid("25892878-bf0d-4e67-8945-602ae857ec56"), 6, new DateTimeOffset(new DateTime(2023, 10, 22, 12, 47, 2, 954, DateTimeKind.Unspecified).AddTicks(6296), new TimeSpan(0, -4, 0, 0, 0)), "1", "PHP", "Active", "PHP", new DateTimeOffset(new DateTime(2023, 10, 22, 12, 47, 2, 954, DateTimeKind.Unspecified).AddTicks(6298), new TimeSpan(0, -4, 0, 0, 0)), "Public" },
                    { new Guid("30273311-ea4b-4e91-8284-f6f95c8ff75e"), 5, new DateTimeOffset(new DateTime(2023, 10, 22, 12, 47, 2, 954, DateTimeKind.Unspecified).AddTicks(6285), new TimeSpan(0, -4, 0, 0, 0)), "1", "JavaScript", "Active", "JavaScript", new DateTimeOffset(new DateTime(2023, 10, 22, 12, 47, 2, 954, DateTimeKind.Unspecified).AddTicks(6288), new TimeSpan(0, -4, 0, 0, 0)), "Public" },
                    { new Guid("3d1433b8-61d6-4bac-8fda-9dd8bd5a3395"), 7, new DateTimeOffset(new DateTime(2023, 10, 22, 12, 47, 2, 954, DateTimeKind.Unspecified).AddTicks(6307), new TimeSpan(0, -4, 0, 0, 0)), "1", "HTML", "Active", "HTML", new DateTimeOffset(new DateTime(2023, 10, 22, 12, 47, 2, 954, DateTimeKind.Unspecified).AddTicks(6310), new TimeSpan(0, -4, 0, 0, 0)), "Public" },
                    { new Guid("46394a2b-3edb-426a-b034-94ba2bb1d3c4"), 1, new DateTimeOffset(new DateTime(2023, 10, 22, 12, 47, 2, 954, DateTimeKind.Unspecified).AddTicks(6219), new TimeSpan(0, -4, 0, 0, 0)), "1", "C#", "Active", "C#", new DateTimeOffset(new DateTime(2023, 10, 22, 12, 47, 2, 954, DateTimeKind.Unspecified).AddTicks(6222), new TimeSpan(0, -4, 0, 0, 0)), "Public" },
                    { new Guid("7bdd5353-b4e1-4a9f-b53f-33c70a9a7481"), 2, new DateTimeOffset(new DateTime(2023, 10, 22, 12, 47, 2, 954, DateTimeKind.Unspecified).AddTicks(6251), new TimeSpan(0, -4, 0, 0, 0)), "1", "Java", "Active", "Java", new DateTimeOffset(new DateTime(2023, 10, 22, 12, 47, 2, 954, DateTimeKind.Unspecified).AddTicks(6254), new TimeSpan(0, -4, 0, 0, 0)), "Public" },
                    { new Guid("eb1c56dd-6211-463b-acb0-8f69eb653140"), 3, new DateTimeOffset(new DateTime(2023, 10, 22, 12, 47, 2, 954, DateTimeKind.Unspecified).AddTicks(6263), new TimeSpan(0, -4, 0, 0, 0)), "1", "Python", "Active", "Python", new DateTimeOffset(new DateTime(2023, 10, 22, 12, 47, 2, 954, DateTimeKind.Unspecified).AddTicks(6266), new TimeSpan(0, -4, 0, 0, 0)), "Public" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CreatedBy",
                table: "Comments",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_NoteId",
                table: "Comments",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CreatedBy",
                table: "Courses",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_NoteLikes_CreatedBy",
                table: "NoteLikes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_NoteLikes_NoteId",
                table: "NoteLikes",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_CourseId",
                table: "Notes",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_CreatedBy",
                table: "Notes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Products_NoteId",
                table: "Products",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId",
                table: "Products",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ProductId",
                table: "Sales",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_UserId",
                table: "Sales",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "NoteLikes");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
