using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntegralService146.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    Answer1 = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Answer2 = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Answer3 = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Answer4 = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    RightAnswer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
