using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PinkTechCompanion;

namespace PinkTechInc.Admin
{
    public partial class SendMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User oUser = (User)Cache[Request.QueryString["ID"]];

            Global oNewGlobal = new Global();
            Users oUsers = new Users(oNewGlobal.Cnxn(), oNewGlobal.LogPath(), oUser.UserID);

            lstRecepient.DataSource = oUsers.Values;
            lstRecepient.DataTextField = "UserName";
            lstRecepient.DataValueField = "UserID";
            lstRecepient.DataBind();
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {

        }
    }
}