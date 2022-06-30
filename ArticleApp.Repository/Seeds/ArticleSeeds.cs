using ArticleApp.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArticleApp.Repository.Seeds
{
    public class ArticleSeeds : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            //Jakob Nielsen
            //Content Strategy
            builder.HasData(
                new Article
                {
                    Id = 1,
                    AuthorId = 1,
                    CategoryId = 1,
                    Name = "Long vs. Short Articles as Content Strategy",
                    Summary = "Information foraging shows how to calculate your content strategy's costs and benefits. A mixed diet that combines brief overviews and comprehensive coverage is often best.",
                    ArticleText = "How much information is enough? How much is too much? And, most importantly, how much information is optimal?Information foraging gives us a way to formally model user trade-offs in deciding how much to read on your website. More precisely, diet selection is a modeling tool that tells us what food animals will eat and what articles users will read. In both scenarios, animals and people decide what to consume in a way that optimizes their benefits relative to the costs.For example, say a forest is inhabited by large and small rabbits. Which will the wolf eat? "
                },
                //Kate Moran 
                //Ecommerce
                new Article
                {
                    Id = 2,
                    AuthorId = 2,
                    CategoryId = 2,
                    Name = "Applying Luxury Principles to Ecommerce Design",
                    Summary = "Luxury brands should use their digital channels to support and enhance their high-quality customer experiences. This requires providing product details that spark interest, balancing visual design with other priorities, and avoiding interruptions that risk cheapening the brand",
                    ArticleText = "Luxury brands maintain their status by being exclusive. Any brand that becomes perceived as too common or available risks losing its “luxury” character. Price is a factor in restricting availability, but many luxury brands remain exclusive through other strategies as well. One strategy is increasing demand by limiting supply, as illustrated by the Hermès Birkin bag. Hermès intentionally manufactures a tiny number of these bags each year, despite extremely high demand. By refusing to meet demand, Hermès maintains the bag’s identity as a status symbol.In addition, Hermès uses another strategy to maintain the Birkin bag’s status — the company intentionally makes it difficult to find and buy this line of bags. They are not sold online or displayed in stores. Hermès used to offer a years-long waiting list, but even that is no longer available. Besides paying tens or hundreds of thousands of US dollars to buy a resold bag from a third party, the only way to obtain a Birkin is to be deemed worthy by Hermès — only their top customers receive invitations to buy."
                },
                //Sarah Gibbons  
                //Design Process
                new Article
                {
                    Id = 3,
                    AuthorId = 3,
                    CategoryId = 3,
                    Name = "Journey Mapping 101",
                    Summary = "A journey map is a visualization of the process that a person goes through in order to accomplish a goal.",
                    ArticleText = "Most journey maps follow a similar format: at the top, a specific user, a specific scenario, and corresponding expectations or goals in the middle, high-level phases that are comprised of user actions, thoughts, and emotions;  at the bottom, the takeaways: opportunities, insights, and internal ownership.The terms ‘user journey map’ and ‘customer journey map’ can be used interchangeably. Both reference a visualization of a person using your product or service. While the argument can be made that the term ‘customer’ does a disservice to the method (because, especially for certain business-to-business products, not all of end users are technically customers, i.e., product buyers), alignment on what you call the map is far less important than alignment on the content within the map"
                },
                //Sarah Gibbons  
                //Agile
                new Article
                {
                    Id = 4,
                    CategoryId = 4,
                    AuthorId = 3,
                    Name = "UX Documentation in Agile",
                    Summary = "Documenting UX processes and design decisions are organizational memory, so even Agile projects that emphasize minimal documentation benefit from two cases of lightweight UX documentation.",
                    ArticleText = "Good UX documentation ensures that everyone stays informed and helps Agile projects run smoothly. When the right information is captured at the right level of detail and in the right places, it’s not wasteful. Good documentation leads to better and faster decision making, aids in presenting and justifying design decisions, and reduces the cognitive load for the team by acting as a form of external memory. Keeping thought processes organized also builds trust and credibility for UX with stakeholders. In large organizations, good UX documentation that’s properly shared also helps with crossfunctional coordination."
                }
            );
        }
    }
}