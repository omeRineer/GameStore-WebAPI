using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class newDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameImages_ImageCategories_CategoryId",
                table: "GameImages");

            migrationBuilder.DropIndex(
                name: "IX_GameImages_CategoryId",
                table: "GameImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageCategories",
                table: "ImageCategories");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "GameImages");

            migrationBuilder.RenameTable(
                name: "ImageCategories",
                newName: "ImageCategory");

            migrationBuilder.AlterColumn<bool>(
                name: "State",
                table: "GameImages",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "ImageCategoryId",
                table: "GameImages",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageCategory",
                table: "ImageCategory",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_GameImages_ImageCategoryId",
                table: "GameImages",
                column: "ImageCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameImages_ImageCategory_ImageCategoryId",
                table: "GameImages",
                column: "ImageCategoryId",
                principalTable: "ImageCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameImages_ImageCategory_ImageCategoryId",
                table: "GameImages");

            migrationBuilder.DropIndex(
                name: "IX_GameImages_ImageCategoryId",
                table: "GameImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageCategory",
                table: "ImageCategory");

            migrationBuilder.DropColumn(
                name: "ImageCategoryId",
                table: "GameImages");

            migrationBuilder.RenameTable(
                name: "ImageCategory",
                newName: "ImageCategories");

            migrationBuilder.AlterColumn<bool>(
                name: "State",
                table: "GameImages",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "GameImages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageCategories",
                table: "ImageCategories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_GameImages_CategoryId",
                table: "GameImages",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameImages_ImageCategories_CategoryId",
                table: "GameImages",
                column: "CategoryId",
                principalTable: "ImageCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
