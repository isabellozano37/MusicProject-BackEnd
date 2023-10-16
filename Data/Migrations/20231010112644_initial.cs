using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id_Categories = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_Categories = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id_Categories);
                });

            migrationBuilder.CreateTable(
                name: "Roll",
                columns: table => new
                {
                    Id_Roll = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_Roll = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roll", x => x.Id_Roll);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id_Product = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagen = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    SongName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilmName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Audio = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Id_Categories = table.Column<int>(type: "int", nullable: false),
                    Id_Products = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id_Product);
                    table.ForeignKey(
                        name: "FK_Products_Categories_Id_Categories",
                        column: x => x.Id_Categories,
                        principalTable: "Categories",
                        principalColumn: "Id_Categories",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id_Users = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_Roll = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id_Users);
                    table.ForeignKey(
                        name: "FK_Users_Roll_Id_Roll",
                        column: x => x.Id_Roll,
                        principalTable: "Roll",
                        principalColumn: "Id_Roll",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MyLists",
                columns: table => new
                {
                    Id_MyLists = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_List = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_Users = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyLists", x => x.Id_MyLists);
                    table.ForeignKey(
                        name: "FK_MyLists_Users_Id_Users",
                        column: x => x.Id_Users,
                        principalTable: "Users",
                        principalColumn: "Id_Users",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailList",
                columns: table => new
                {
                    Id_DetailList = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_MyLists = table.Column<int>(type: "int", nullable: false),
                    Id_Product = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailList", x => x.Id_DetailList);
                    table.ForeignKey(
                        name: "FK_DetailList_MyLists_Id_MyLists",
                        column: x => x.Id_MyLists,
                        principalTable: "MyLists",
                        principalColumn: "Id_MyLists",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailList_Products_Id_Product",
                        column: x => x.Id_Product,
                        principalTable: "Products",
                        principalColumn: "Id_Product",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailList_Id_MyLists",
                table: "DetailList",
                column: "Id_MyLists");

            migrationBuilder.CreateIndex(
                name: "IX_DetailList_Id_Product",
                table: "DetailList",
                column: "Id_Product");

            migrationBuilder.CreateIndex(
                name: "IX_MyLists_Id_Users",
                table: "MyLists",
                column: "Id_Users");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Id_Categories",
                table: "Products",
                column: "Id_Categories");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id_Roll",
                table: "Users",
                column: "Id_Roll");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailList");

            migrationBuilder.DropTable(
                name: "MyLists");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Roll");
        }
    }
}
