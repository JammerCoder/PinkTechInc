﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PinkTechCompanion;

namespace PinkTechInc.Admin
{
    public partial class AdminMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User oUser = (User)Cache[Request.QueryString["ID"]];

            litAccountName.Text = oUser.FirstName + " " + oUser.MiddleName + " " + oUser.LastName;
            //litAddress.Text = oUser.Address
            litContact.Text = oUser.Email;
            litRole.Text = oUser.SecurityLevelName;
            
        }
    }
}