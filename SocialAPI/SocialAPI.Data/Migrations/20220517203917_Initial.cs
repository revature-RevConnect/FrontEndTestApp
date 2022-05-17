using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialAPI.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "RevSocial");

            migrationBuilder.CreateTable(
                name: "Posts",
                schema: "RevSocial",
                columns: table => new
                {
                    postID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    authID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.postID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "RevSocial",
                columns: table => new
                {
                    userID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    authID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    profilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    aboutMe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    linkedin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    twitter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    github = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userID);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                schema: "RevSocial",
                columns: table => new
                {
                    commentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    authID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    postID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.commentID);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_postID",
                        column: x => x.postID,
                        principalSchema: "RevSocial",
                        principalTable: "Posts",
                        principalColumn: "postID");
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                schema: "RevSocial",
                columns: table => new
                {
                    likeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    authID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    postID = table.Column<int>(type: "int", nullable: true),
                    commentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.likeID);
                    table.ForeignKey(
                        name: "FK_Likes_Comments_commentID",
                        column: x => x.commentID,
                        principalSchema: "RevSocial",
                        principalTable: "Comments",
                        principalColumn: "commentID");
                    table.ForeignKey(
                        name: "FK_Likes_Posts_postID",
                        column: x => x.postID,
                        principalSchema: "RevSocial",
                        principalTable: "Posts",
                        principalColumn: "postID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_postID",
                schema: "RevSocial",
                table: "Comments",
                column: "postID");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_commentID",
                schema: "RevSocial",
                table: "Likes",
                column: "commentID");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_postID",
                schema: "RevSocial",
                table: "Likes",
                column: "postID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Likes",
                schema: "RevSocial");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "RevSocial");

            migrationBuilder.DropTable(
                name: "Comments",
                schema: "RevSocial");

            migrationBuilder.DropTable(
                name: "Posts",
                schema: "RevSocial");
        }
    }
}
