using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PinkTechCompanion;

namespace PinkTechInc
{
    public partial class AdminMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = (User)Cache[Request.QueryString["ID"]];
            lblUserName.Text = user.UserName;
            lblFullName.Text = user.FirstName + " " + user.LastName;
            lblUserRole.Text = user.SecurityLevelName;
        }
    }
}