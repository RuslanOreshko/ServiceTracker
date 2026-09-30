using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Periods_UserId",
                table: "Periods",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GetEvents_UserId",
                table: "GetEvents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Achivements_UserId",
                table: "Achivements",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Achivements_Users_UserId",
                table: "Achivements",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GetEvents_Users_UserId",
                table: "GetEvents",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Periods_Users_UserId",
                table: "Periods",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrivacySettings_Users_UserId",
                table: "PrivacySettings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Users_UserId",
                table: "Profiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                table: "RefreshTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achivements_Users_UserId",
                table: "Achivements");

            migrationBuilder.DropForeignKey(
                name: "FK_GetEvents_Users_UserId",
                table: "GetEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_Periods_Users_UserId",
                table: "Periods");

            migrationBuilder.DropForeignKey(
                name: "FK_PrivacySettings_Users_UserId",
                table: "PrivacySettings");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Users_UserId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshTokens_Users_UserId",
                table: "RefreshTokens");

            migrationBuilder.DropIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Periods_UserId",
                table: "Periods");

            migrationBuilder.DropIndex(
                name: "IX_GetEvents_UserId",
                table: "GetEvents");

            migrationBuilder.DropIndex(
                name: "IX_Achivements_UserId",
                table: "Achivements");
        }
    }
}
