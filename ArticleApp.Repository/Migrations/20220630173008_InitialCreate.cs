using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArticleApp.Repository.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Summary = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    ArticleText = table.Column<string>(type: "nvarchar(3500)", maxLength: 3500, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "jakobnielsen@article.com", "Jakob Nielsen" },
                    { 2, "katemoran@article.com", "Kate Moran" },
                    { 3, "sarahgibbons@article.com", "Sarah Gibbons" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "A content strategy is an all-encompassing approach for creating content that drives key business objectives", "Content Strategy" },
                    { 2, "E-commerce (electronic commerce) is the buying and selling of goods and services, or the transmitting of funds or data, over an electronic network, primarily the internet.", "Ecommerce" },
                    { 3, "The Design Process is an approach for breaking down a large project into manageable chunks. Architects, engineers, scientists, and other thinkers use the design process to solve a variety of problems.", "Design Process" },
                    { 4, "agile is a group of methodologies that demonstrate a commitment to tight feedback cycles and continuous improvement.", "Agile" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleText", "AuthorId", "CategoryId", "Name", "Summary" },
                values: new object[,]
                {
                    { 1, "How much information is enough? How much is too much? And, most importantly, how much information is optimal?Information foraging gives us a way to formally model user trade-offs in deciding how much to read on your website. More precisely, diet selection is a modeling tool that tells us what food animals will eat and what articles users will read. In both scenarios, animals and people decide what to consume in a way that optimizes their benefits relative to the costs.For example, say a forest is inhabited by large and small rabbits. Which will the wolf eat? ", 1, 1, "Long vs. Short Articles as Content Strategy", "Information foraging shows how to calculate your content strategy's costs and benefits. A mixed diet that combines brief overviews and comprehensive coverage is often best." },
                    { 2, "Luxury brands maintain their status by being exclusive. Any brand that becomes perceived as too common or available risks losing its “luxury” character. Price is a factor in restricting availability, but many luxury brands remain exclusive through other strategies as well. One strategy is increasing demand by limiting supply, as illustrated by the Hermès Birkin bag. Hermès intentionally manufactures a tiny number of these bags each year, despite extremely high demand. By refusing to meet demand, Hermès maintains the bag’s identity as a status symbol.In addition, Hermès uses another strategy to maintain the Birkin bag’s status — the company intentionally makes it difficult to find and buy this line of bags. They are not sold online or displayed in stores. Hermès used to offer a years-long waiting list, but even that is no longer available. Besides paying tens or hundreds of thousands of US dollars to buy a resold bag from a third party, the only way to obtain a Birkin is to be deemed worthy by Hermès — only their top customers receive invitations to buy.", 2, 2, "Applying Luxury Principles to Ecommerce Design", "Luxury brands should use their digital channels to support and enhance their high-quality customer experiences. This requires providing product details that spark interest, balancing visual design with other priorities, and avoiding interruptions that risk cheapening the brand" },
                    { 3, "Most journey maps follow a similar format: at the top, a specific user, a specific scenario, and corresponding expectations or goals in the middle, high-level phases that are comprised of user actions, thoughts, and emotions;  at the bottom, the takeaways: opportunities, insights, and internal ownership.The terms ‘user journey map’ and ‘customer journey map’ can be used interchangeably. Both reference a visualization of a person using your product or service. While the argument can be made that the term ‘customer’ does a disservice to the method (because, especially for certain business-to-business products, not all of end users are technically customers, i.e., product buyers), alignment on what you call the map is far less important than alignment on the content within the map", 3, 3, "Journey Mapping 101", "A journey map is a visualization of the process that a person goes through in order to accomplish a goal." },
                    { 4, "Good UX documentation ensures that everyone stays informed and helps Agile projects run smoothly. When the right information is captured at the right level of detail and in the right places, it’s not wasteful. Good documentation leads to better and faster decision making, aids in presenting and justifying design decisions, and reduces the cognitive load for the team by acting as a form of external memory. Keeping thought processes organized also builds trust and credibility for UX with stakeholders. In large organizations, good UX documentation that’s properly shared also helps with crossfunctional coordination.", 3, 4, "UX Documentation in Agile", "Documenting UX processes and design decisions are organizational memory, so even Agile projects that emphasize minimal documentation benefit from two cases of lightweight UX documentation." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AuthorId",
                table: "Articles",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
