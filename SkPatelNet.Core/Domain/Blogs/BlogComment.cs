using SkPatelNet.Core.Domain.Customers;
using System;

namespace SkPatelNet.Core.Domain.Blogs
{
    public class BlogComment : BaseEntity
    {
        public int CustomerId { get; set; }
        public int BlogPostId { get; set; }
        public string CommentText { get; set; }
        public bool IsApproved { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual BlogPost BlogPost { get; set; }

    }
}