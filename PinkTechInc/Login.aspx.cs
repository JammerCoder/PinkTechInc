using PinkTechCompanion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PinkTechInc
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            
            this.litLoginMessage.Text = "";

            //string sCnxn = "ConnectionString";
            //string sLogPath = "LogPath";

            string sCnxn = ConfigurationManager.AppSettings["Cnxn"];
            string sLogPath = ConfigurationManager.AppSettings["LogPath"];

            UserPermissions oUsers = new UserPermissions(sCnxn,sLogPath,this.txtUserName.Text,this.txtPassword.Text);

            this.litLoginMessage.Text = oUsers.UserPermissionsReturnMessage + " Redirecting... " ;

            /*if (oUsers.UserPermissionsReturnMessage == "SUCCESS!")
            {
                Response.Redirect("Home.aspx" + "?" + Guid.NewGuid().ToString());
            }*/
        }
    }
}