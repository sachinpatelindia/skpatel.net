namespace SkPatelNet.Core.Domain.Blogs
{
    public class BlogCommentApprovedEvent
    {
        public BlogCommentApprovedEvent(BlogComment blogComment)
        {
            BlogComment = blogComment;
        }

        public BlogComment BlogComment { get; }
    }
}
