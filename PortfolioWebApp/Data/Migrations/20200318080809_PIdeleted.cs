using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PortfolioWebApp.Data.Migrations
{
    public partial class PIdeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_CategoryId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "PostImages");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Posts",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "FifthImageUrl",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstImageUrl",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FourthImageUrl",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondImageUrl",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SixthImageUrl",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThirdImageUrl",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Categories_CategoryId",
                table: "Posts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_CategoryId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "FifthImageUrl",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "FirstImageUrl",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "FourthImageUrl",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "SecondImageUrl",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "SixthImageUrl",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ThirdImageUrl",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Posts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "PostImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FifthImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FourthImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    SecondImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SixthImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThirdImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostImages_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostImages_PostId",
                table: "PostImages",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Categories_CategoryId",
                table: "Posts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
