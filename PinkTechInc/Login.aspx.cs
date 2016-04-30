using PinkTechCompanion;
using System;
using System.Configuration;
using System.Web.UI;

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

                //User oUser = new User();
                UserPermissions oUserPermissions = new UserPermissions(sCnxn, sLogPath, txtUserName.Text, txtPassword.Text);
                litLoginMessage.Text = oUserPermissions.UserPermissionsReturnMessage;
                
                string sGuid = Guid.NewGuid().ToString();
                //Cache[sGuid] = userPermission;
                
                /*if (oUser.UserPermissionsReturnMessage == "SUCCESS!")
                {
                    litLoginMessage.Text = "Good day, " + userPermission.UserName + " Redirecting... "; //Just for checking... You can remove me....

                    switch (userPermission.SecurityLevelName.ToUpper())
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
                    litLoginMessage.Text = " <font color='Red'> UserName or Password Failed! </font>";*/
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