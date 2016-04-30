using System;
using PinkTechCompanion;

namespace PinkTechInc
{
    public partial class UserHome : System.Web.UI.Page
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