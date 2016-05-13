using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PinkTechCompanion;

namespace PinkTechInc.Admin
{
    public partial class Outbox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User oUser = (User)Cache[Request.QueryString["ID"]];
            Global oNewGlobal = new Global();
            Messages oSentMessagesFetch = new Messages();
            Dictionary<int, SentMessage> oSentMessages = oSentMessagesFetch.SentMessages(oNewGlobal.Cnxn(), oNewGlobal.LogPath(), oUser.UserID);

            grdSent.DataSource = oSentMessages.Values;
            grdSent.DataBind();
        }
    }
}