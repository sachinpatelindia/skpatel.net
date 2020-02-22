using System;
using System.Collections.Generic;
using System.Text;

namespace SkPatelNet.Core.Domain.Blogs
{
    public partial class BlogPost:BaseEntity
    {
        private ICollection<BlogComment> blogComments;
        public bool IncludeInSitemap { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string BodyOverview { get; set; }
        public bool AllowComments { get; set; }
        public string Tags { get; set; }
        public DateTime? StartDateUtc { get; set; }
        public DateTime? EndDateUtc { get; set; }
        public DateTime? CreatedOnUtc { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public virtual ICollection<BlogComment> BlogComments
        {
            get => blogComments ?? (blogComments = new List<BlogComment>());
            protected set => blogComments = value;
        }
    }
}
