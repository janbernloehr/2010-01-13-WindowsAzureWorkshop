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
        protected void PostSource_Selecting(object sender, LinqDataSourceSelectEventArgs e)
        {
            var posts = BlogEngine.BlogEngine.GetBlogPosts();

            e.Result = posts;
        }
    }
}