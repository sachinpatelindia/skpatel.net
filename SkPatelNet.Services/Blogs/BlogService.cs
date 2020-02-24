using SkPatelNet.Core.Domain.Blogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkPatelNet.Services.Blogs
{
    public partial class BlogService : IBlogService
    {
        public void DeleteBlogPost(BlogPost blogPost)
        {
            throw new NotImplementedException();
        }

        public IList<BlogPost> GetAllBlogPostTags(bool showHiddedn = true)
        {
            throw new NotImplementedException();
        }

        public BlogPost GetBlogPostById(int blogPostId)
        {
            throw new NotImplementedException();
        }

        public IList<BlogPost> GetBlogPostsByIds(int[] blogPostIds)
        {
            throw new NotImplementedException();
        }

        public IList<BlogPost> GetPostsByDate(IList<BlogPost> blogPosts, DateTime dateFrom, DateTime dateTo)
        {
            throw new NotImplementedException();
        }

        public void InsertBlogPost(BlogPost blogPost)
        {
            throw new NotImplementedException();
        }

        public IList<string> ParseTags(BlogPost blogPost)
        {
            throw new NotImplementedException();
        }

        public void UpdateBlogPost(BlogPost blogPost)
        {
            throw new NotImplementedException();
        }
    }
}
