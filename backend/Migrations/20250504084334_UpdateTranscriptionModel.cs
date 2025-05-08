using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTranscriptionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Transcriptions_AudioId",
                table: "Transcriptions",
                column: "AudioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transcriptions_AudioFiles_AudioId",
                table: "Transcriptions",
                column: "AudioId",
                principalTable: "AudioFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transcriptions_AudioFiles_AudioId",
                table: "Transcriptions");

            migrationBuilder.DropIndex(
                name: "IX_Transcriptions_AudioId",
                table: "Transcriptions");
        }
    }
}
