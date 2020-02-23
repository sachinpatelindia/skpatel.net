using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkPatelNet.Core.Domain.Blogs;

namespace SkPatelNet.Data.Mapping.Blogs
{
    public partial class BlogPostMap:SkPatelNetEntityTypeConfiguration<BlogPost>
    {
        public override void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.ToTable(nameof(BlogPost));
            builder.HasKey(b=>b.Id);
            builder.Property(b => b.Title).IsRequired();
            builder.Property(b => b.Body).IsRequired();
            builder.Property(b => b.MetaKeywords).HasMaxLength(400);
            builder.Property(b => b.MetaTitle).HasMaxLength(400);
            base.Configure(builder);
        }
    }
}
