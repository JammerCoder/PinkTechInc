using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;

namespace PinkTechCompanion
{
    public class UserPermissions : Dictionary<int, User>
    {
        public string UserPermissionsReturnMessage { get; set; }

        public UserPermissions()
        {
        }

        public User Login(string sCnxn, string sLogPath, string sUserName, string sPassword)
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

                SqlConnection oCnxn = new SqlConnection(sCnxn);
                SqlCommand oCmd = new SqlCommand("spUserInfoFetchCredentials", oCnxn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                oCmd.Parameters.AddWithValue("@UserName", sUserName);
                oCmd.Parameters.AddWithValue("@Passwrd", sPassword);

                oCnxn.Open();
                SqlDataReader oReader = oCmd.ExecuteReader();

                User oUser = new User();

                while (oReader.Read())
                {
                    oUser.FirstName = oReader["FirstName"].ToString();
                    oUser.MiddleName = oReader["MiddleName"].ToString();
                    oUser.LastName = oReader["LastName"].ToString();
                    oUser.UserName = oReader["UserName"].ToString();
                    oUser.Email = oReader["Email"].ToString();
                    oUser.Passwrd = oReader["Passwrd"].ToString();
                    oUser.SecurityLevelName = oReader["SecurityLevelName"].ToString();
                    oUser.IsActive = Convert.ToBoolean(oReader["IsActive"]);

                    if (!ContainsKey(oUser.UserID))
                        this.Add(oUser.UserID, oUser);
                }
                
                if(oUser.UserName == sUserName && oUser.Passwrd == sPassword)
                    UserPermissionsReturnMessage = "SUCCESS!";
                else
                {
                    UserPermissionsReturnMessage = "Login ";
                    if (oUser.UserName != sUserName && oUser.Passwrd == sPassword)
                        UserPermissionsReturnMessage += "NAME Failed!";

                    if (oUser.UserName == sUserName && oUser.Passwrd != sPassword)
                        UserPermissionsReturnMessage += "PASSWORD Failed!";

                    if (oUser.UserName != sUserName && oUser.Passwrd != sPassword)
                        UserPermissionsReturnMessage += "NAME and PASSWORD Failed!";
                }
                oCnxn.Close();
                return oUser;
            }
            catch (Exception ex)
            {
                Log oLog = new Log();
                oLog.LogError("UserPermissions: " + sUserName + ", " + sPassword + "-> ",
                    ex.Message, sLogPath);
                UserPermissionsReturnMessage = "Login FAILED!";
                return null;
            }
        }
    }

    public class User
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
