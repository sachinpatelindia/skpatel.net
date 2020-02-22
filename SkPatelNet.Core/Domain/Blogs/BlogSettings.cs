using System;
using System.Collections.Generic;
using System.Text;

namespace SkPatelNet.Core.Domain.Blogs
{
    public class BlogSettings:ISettings
    {
        public bool Enabled { get; set; }
        public int PostPageSize { get; set; }
        public bool AllowNotRegisteredUsersToLeaveComments { get; set; }
        public bool NotifyAboutNewBlogComments { get; set; }
        public int NumberOfTags { get; set; }
        public bool ShowHeaderRssUrl { get; set; }
        public bool BlogCommentsMustBeApproved { get; set; }
    }
}
