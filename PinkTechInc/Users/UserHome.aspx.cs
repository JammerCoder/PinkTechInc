using System;
using PinkTechCompanion;

namespace PinkTechInc
{
    public partial class UserHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User oUser = (User)Cache[Request.QueryString["ID"]];
            Global oNewGlobal = new Global();
            Messages oNewMessages = new Messages(oNewGlobal.Cnxn(), oNewGlobal.LogPath(), oUser.UserID);

            lblUserName.Text = oUser.UserName;
            if (oNewMessages.Count > 1)
                lblNewMessage.Text = oNewMessages.Count.ToString();

            grdInbox.DataSource = oNewMessages.Values;
            grdInbox.DataBind();

            Messages oSentMessages = new Messages();
            oSentMessages.SentMessages(oNewGlobal.Cnxn(), oNewGlobal.LogPath(), oUser.UserID);

            grdSent.DataSource = oSentMessages.Values;
            grdSent.DataBind();
        }
    }
}