using SkPatelNet.Core.Domain.Blogs;
using System;
using System.Collections.Generic;

namespace SkPatelNet.Services.Blogs
{
    public partial interface IBlogService
    {
        void InsertBlogPost(BlogPost blogPost);
        void UpdateBlogPost(BlogPost blogPost);
        void DeleteBlogPost(BlogPost blogPost);
        BlogPost GetBlogPostById(int blogPostId);
        IList<BlogPost> GetBlogPostsByIds(int[] blogPostIds);
        IList<BlogPost> GetAllBlogPostTags(bool showHiddedn=true);
        IList<BlogPost> GetPostsByDate(IList<BlogPost> blogPosts , DateTime dateFrom, DateTime dateTo);
        IList<string> ParseTags(BlogPost blogPost);

    }
}
