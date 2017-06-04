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
        protected void Publish_Click(object sender, EventArgs e)
        {
            BlogEngine.BlogEngine.PublishPost(Title.Text, Text.Text, Author.Text);

            Response.Redirect("~/default.aspx");
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/default.aspx");
        }
    }
}