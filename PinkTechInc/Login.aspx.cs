using System;
using System.Web.UI;
using PinkTechCompanion;

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

                Global oNewGlobal = new Global();
                
                User oUser = UserPermissions.Login(oNewGlobal.Cnxn(), oNewGlobal.LogPath(), txtUserName.Text, txtPassword.Text);
                
                if (UserPermissions.UserPermissionsReturnMessage == "SUCCESS!")
                {
                    //litLoginMessage.Text = "Good day, " + oUser.UserName + " Redirecting... "; //Just for checking... You can remove me....
                    string sGuid = Guid.NewGuid().ToString();
                    Cache[sGuid] = oUser;

                    switch (oUser.SecurityLevelName.ToUpper())
                    {
                        case "SUPERADMIN":
                            Response.Redirect("Admin/AdminMenu.aspx?ID="+sGuid);
                            break;
                        case "ADMIN":
                            Response.Redirect("Admin/AdminMenu.aspx?ID=" + sGuid);
                            break;
                        default:
                            Response.Redirect("Users/AdminMenu.aspx?ID="+sGuid);
                            break;
                    }
                }
                else
                    litLoginMessage.Text = " <font color='Red'>" + UserPermissions.UserPermissionsReturnMessage + "</font>";
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