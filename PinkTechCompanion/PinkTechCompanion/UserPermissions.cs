using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinkTechCompanion
{
    public class UserPermissions : Dictionary<int,UserPermission>
    {
        private string _UserPermissionsReturnMessage;

        public string UserPermissionsReturnMessage
        {
            get { return _UserPermissionsReturnMessage; }
            set { _UserPermissionsReturnMessage = value; }
        }

        public UserPermissions()
        {
        }

        public UserPermissions(string sCnxn, string sLogPath, string sUserName, string sGUID)
        {            
            try
            {
                UserPermissionsReturnMessage = "";


                if (sUserName.ToUpper() == "SUCCESS") 
                {
                    if (sGUID.ToUpper() == "SUCCESS") 
                        UserPermissionsReturnMessage = "SUCCESS!";
                    else
                        UserPermissionsReturnMessage = "PASSWORD failed!";
                }                    
                else
                    UserPermissionsReturnMessage = "LOGIN Name not found!";
            }
            catch (Exception ex)
            {
                Log oLog = new Log();
                oLog.LogError("UserPermissions", ex.Message, sLogPath);
            }            
        }
    }

    public class UserPermission
    {

    }
}
