using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
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

            Users oUsers = new Users(oNewGlobal.Cnxn(), oNewGlobal.LogPath(),oUser.UserID);

            /*drdRecepient.DataSource = oUsers.Values;
            drdRecepient.DataTextField = "UserName";
            drdRecepient.DataValueField = "UserID";
            drdRecepient.DataBind();
            drdRecepient.Items.Insert(0, "-Select-");*/

            lstRecepient.DataSource = oUsers.Values;
            lstRecepient.DataTextField = "UserName";
            lstRecepient.DataValueField = "UserID";
            lstRecepient.DataBind();
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string selected = lstRecepient.SelectedValue;

            }
            catch (Exception ex)
            {
                txtSubject.Text = ex.Message;
            }
        }

        protected void lstRecepient_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                litErrorMessages.Text = lstRecepient.SelectedItem.ToString();

            }
            catch (Exception ex)
            {
                litErrorMessages.Text = ex.Message;
            }
        }
    }
}