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
        Global oNewGlobal = new Global();

        protected void Page_Load(object sender, EventArgs e)
        {
            User oUser = (User)Cache[Request.QueryString["ID"]];

            Users oUsers = new Users(oNewGlobal.Cnxn(), oNewGlobal.LogPath(), oUser.UserID);

            drdRecepient.DataSource = oUsers.Values;
            drdRecepient.DataTextField = "UserName";
            drdRecepient.DataValueField = "UserID";
            drdRecepient.DataBind();
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                User oUser = (User)Cache[Request.QueryString["ID"]];

                SentMessage oMessage = new SentMessage();
                oMessage.MessageID = 0;
                oMessage.Subject = txtSubject.Text;
                oMessage.Message = txtMessage.Text;
                oMessage.SenderID = oUser.UserID;
                oMessage.Recepients = drdRecepient.Text;

                litErrorMessages.Text = "Saving message before sending it...";
                litErrorMessages.Text = oMessage.SaveMessage(oNewGlobal.Cnxn(), oNewGlobal.LogPath());

                if (litErrorMessages.Text == "Message successfully saved!")
                {
                    litErrorMessages.Text = "<font color='green'> " + litErrorMessages.Text + "</font>";

                    UserMessage oSendMessage = new UserMessage();
                    oSendMessage.MessageID = oMessage.GeneratedIdWhenSent;
                    oSendMessage.UserID = Convert.ToInt32(drdRecepient.Text);
                    litErrorMessages.Text = oSendMessage.SendMessage(oNewGlobal.Cnxn(), oNewGlobal.LogPath());

                    if (litErrorMessages.Text == "Message successfully sent!")
                        litErrorMessages.Text = "<font color='green'> " + litErrorMessages.Text + "</font>";
                    else
                        litErrorMessages.Text = "<font color='red'> " + litErrorMessages.Text + "</font>";
                }
                else
                    litErrorMessages.Text = "<font color='red'> " + litErrorMessages.Text + "</font>";

            }
            catch (Exception ex)
            {
                litErrorMessages.Text = "<font color='red'> " + ex.Message + "</font>";
            }

        }
    }
}