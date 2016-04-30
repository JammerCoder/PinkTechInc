using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;

namespace PinkTechCompanion
{
    public class UserPermissions : Dictionary<int, UserPermission>
    {
        public string UserPermissionsReturnMessage { get; set; }

        static UserPermissions()
        {
        }
        
        public UserPermission Login(string sCnxn, string sLogPath, string sUserName, string sPassword)
        {
            UserPermissionsReturnMessage = "";

            try
            {
                
                #region History
                /*if (sUserName.ToUpper() == "SUCCESS")
                {
                    if (sGUID.ToUpper() == "SUCCESS")
                        UserPermissionsReturnMessage = "SUCCESS!";
                    else
                        UserPermissionsReturnMessage = "PASSWORD failed!";
                }
                else
                    UserPermissionsReturnMessage = "LOGIN Name not found!";
                 * */
                #endregion History

                var oCnxn = new SqlConnection(sCnxn);
                var oCmd = new SqlCommand("spUserInfoFetchCredentials", oCnxn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                oCmd.Parameters.AddWithValue("@UserName", sUserName);
                oCmd.Parameters.AddWithValue("@Passwrd", sPassword);

                oCnxn.Open();                
                var oReader = oCmd.ExecuteReader();

                int count = 0;
                
                UserPermission oNewUserPermission = new UserPermission();

                while (oReader.Read())
                {
                    oNewUserPermission.FirstName = oReader["FirstName"].ToString();
                    oNewUserPermission.MiddleName = oReader["MiddleName"].ToString();
                    oNewUserPermission.LastName = oReader["LastName"].ToString();
                    oNewUserPermission.UserName = oReader["UserName"].ToString();
                    oNewUserPermission.Email = oReader["Email"].ToString();
                    oNewUserPermission.Passwrd = oReader["Passwrd"].ToString();
                    oNewUserPermission.SecurityLevelName = oReader["SecurityLevelName"].ToString();
                    oNewUserPermission.IsActive = Convert.ToBoolean(oReader["IsActive"]);

                    if (!ContainsKey(oNewUserPermission.UserID))
                    {
                        Add(oNewUserPermission.UserID, oNewUserPermission);
                    }

                    count += 1;
                }
                oCnxn.Close();
                UserPermissionsReturnMessage = count == 0 ? "FAILED!" : "SUCCESS!";
                return oNewUserPermission;
            }
            catch (Exception ex)
            {
                Log oLog = new Log();
                oLog.LogError("UserPermissions: " + sUserName + ", " + sPassword + "-> ",
                    ex.Message, sLogPath);
                UserPermissionsReturnMessage = "FAILED!";
                return null;
            }
        }
        
    }

    public class UserPermission
    {
        #region Properties

        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Passwrd { get; set; }
        public string SecurityLevelName { get; set; }
        public bool IsActive { get; set; }
        #endregion Properties
    }
}
