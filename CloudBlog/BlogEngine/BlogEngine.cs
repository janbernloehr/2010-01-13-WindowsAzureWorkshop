using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogEngine
{
    /// <summary>
    /// Engine to publish and receive blog posts.
    /// </summary>
    public class BlogEngine
    {
        /// <summary>
        /// Create DataContext (O/R Mapper Context, to access database)
        /// </summary>
        private static BlogStorageDataContext CreateContext()
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["AzureWorkshop"];

            if (connectionString == null) throw new ApplicationException("ConnectionString 'AzureWorkshop' requried.");

            return new BlogStorageDataContext(connectionString.ConnectionString);
        }

        /// <summary>
        /// Publish a new blog post.
        /// </summary>
        public static void PublishPost(string title, string text, string author)
        {
            // check parameters
            if (string.IsNullOrEmpty(title)) throw new ArgumentNullException("title");
            if (string.IsNullOrEmpty(text)) throw new ArgumentNullException("text");
            if (string.IsNullOrEmpty(author)) throw new ArgumentNullException("author");

            // insert "blogpost" row
            using (var dbx = CreateContext())
            {
                int? id = 0;

                dbx.BlogPostsInsert(ref id, title, text, author, DateTime.Now);
            }
        }

        /// <summary>
        /// Get blog posts.
        /// </summary>
        public static BlogPost[] GetBlogPosts()
        {
            using (var dbx = CreateContext())
            {
                // linq query to receive posts
                var query = from x in dbx.BlogPosts
                            orderby x.DateCreated descending
                            select new BlogPost()
                            {
                                Title = x.Title,
                                Author = x.Author,
                                Text = x.Text,
                                DateCreated = x.DateCreated
                            };

                // return query results as array.
                return query.ToArray();
            }
        }
    }

    public class BlogPost
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
