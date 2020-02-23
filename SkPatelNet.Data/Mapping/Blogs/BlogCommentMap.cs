using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkPatelNet.Core.Domain.Blogs;

namespace SkPatelNet.Data.Mapping.Blogs
{
    public partial class BlogCommentMap:SkPatelNetEntityTypeConfiguration<BlogComment>
    {
        public override void Configure(EntityTypeBuilder<BlogComment> builder)
        {
            builder.ToTable(nameof(BlogComment));
            builder.HasKey(c=>c.Id);

            builder.HasOne(c => c.BlogPost)
                .WithMany(b => b.BlogComments)
                .HasForeignKey(c => c.BlogPostId)
                .IsRequired();

            builder.HasOne(c => c.Customer)
                .WithMany()
                .HasForeignKey(c => c.CustomerId)
                .IsRequired();
            base.Configure(builder);
        }
    }
}
