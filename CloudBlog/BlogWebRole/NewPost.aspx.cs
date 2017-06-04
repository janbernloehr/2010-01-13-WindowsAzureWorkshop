using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebRole1
{
    public partial class NewPost : System.Web.UI.Page
    {
        
        /// <summary>
        /// Publish button clicked.
        /// </summary>
        protected void Publish_Click(object sender, EventArgs e)
        {
            // Publish post.
            BlogEngine.BlogEngine.PublishPost(Title.Text, Text.Text, Author.Text);

            // Redirect to startpage.
            Response.Redirect("~/default.aspx");
        }

        /// <summary>
        /// Cancel button clicked.
        /// </summary>
        protected void Cancel_Click(object sender, EventArgs e)
        {
            // Redirect to startpage.
            Response.Redirect("~/default.aspx");
        }
    }
}