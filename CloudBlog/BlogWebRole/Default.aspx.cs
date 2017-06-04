using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebRole1
{
    public partial class _Default : System.Web.UI.Page
    {
        /// <summary>
        /// DataSource is querying data...
        /// </summary>
        protected void PostSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            // get posts from blog engine
            var posts = BlogEngine.BlogEngine.GetBlogPosts();

            // pass the posts to the datasource.
            e.Result = posts;
        }
    }
}