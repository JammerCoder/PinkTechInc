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
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                litLoginMessage.Text = "";

                string sCnxn = ConfigurationManager.AppSettings["Cnxn"];
                string sLogPath = ConfigurationManager.AppSettings["LogPath"];

                UserPermissions oUserPermissions = new UserPermissions();
                
                User oUser = oUserPermissions.Login(sCnxn, sLogPath, txtUserName.Text, txtPassword.Text);
                
                string sGuid = Guid.NewGuid().ToString();
                Cache[sGuid] = oUser;
                
                if (oUserPermissions.UserPermissionsReturnMessage == "SUCCESS!")
                {
                    litLoginMessage.Text = "Good day, " + oUser.UserName + " Redirecting... "; //Just for checking... You can remove me....

                    switch (oUser.SecurityLevelName.ToUpper())
                    {
                        case "SUPERADMIN":
                            Response.Redirect("AdminMenu.aspx?ID="+sGuid);
                            break;
                        case "ADMIN":
                            Response.Redirect("AdminMenu.aspx?ID=" + sGuid);
                            break;
                        default:
                            Response.Redirect("UserHome.aspx?ID="+sGuid);
                            break;
                    }
                }
                else
                    litLoginMessage.Text = " <font color='Red'>" + oUserPermissions.UserPermissionsReturnMessage + "</font>";
            }
            catch (Exception ex)
            {
                litLoginMessage.Text = ex.Message;
            }

        }

        protected void txtPassword_TextChanged(object sender, EventArgs e)
        {
            litLoginMessage.Text = "";
        }
    }
}