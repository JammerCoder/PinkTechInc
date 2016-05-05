using System;
using System.Collections.Generic;
using System.Data;
using PinkTechCompanion;

namespace PinkTechInc
{
    public partial class AdminMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User oUser = (User)Cache[Request.QueryString["ID"]];
            Global oNewGlobal = new Global();
            Messages oNewMessages = new Messages(oNewGlobal.Cnxn(), oNewGlobal.LogPath(), oUser.UserID);

            lblUserName.Text = oUser.UserName;
            if (oNewMessages.Count > 1)
                lblNewMessage.Text = oNewMessages.Count.ToString();

            litAccountName.Text = oUser.FirstName + " " + oUser.MiddleName + " " + oUser.LastName;
            //litAddress.Text = oUser.Address
            litContact.Text = oUser.Email;
            litRole.Text = oUser.SecurityLevelName;

            grdInbox.DataSource = oNewMessages.Values;
            grdInbox.DataBind();

            Messages oSentMessagesFetch = new Messages();
            Dictionary<int,SentMessage> oSentMessages = oSentMessagesFetch.SentMessages(oNewGlobal.Cnxn(), oNewGlobal.LogPath(), oUser.UserID);
            
            grdSent.DataSource = oSentMessages.Values;
            grdSent.DataBind();
        }
    }
}