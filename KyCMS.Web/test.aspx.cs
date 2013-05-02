using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KyCMS.Web
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> de = new Dictionary<string, string>();
            de.Add("a1", "b");
            de.Add("a2", "b");
            de.Add("a3", "b");
            de.Add("a4", "b");
            foreach (string item in de.Keys)
            {
                Response.Write(item);
            }
        }
    }
}