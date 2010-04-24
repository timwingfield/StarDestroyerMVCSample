using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StarDestroyer.DarkSide
{
    public partial class Sith : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var draggyDroppyContent = new List<string>();
            draggyDroppyContent.Add("Drag");
            draggyDroppyContent.Add("And");
            draggyDroppyContent.Add("Drop");
            draggyDroppyContent.Add("Baby!");

            this.GridView1.DataSource = draggyDroppyContent;
            this.GridView1.DataBind();
        }
    }
}
