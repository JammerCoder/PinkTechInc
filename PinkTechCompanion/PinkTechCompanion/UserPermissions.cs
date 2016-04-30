using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Threading;

namespace PinkTechCompanion
{
    public class UserPermissions : Dictionary<int, User>
    {
        public string UserPermissionsReturnMessage { get; set; }
        private static string sUserNameStatic;
        private static string sPasswordStatic;
        private static string sCnxnStatic;
        private static string sLogPathStatic;
        private static string sLoginMessage;

        public UserPermissions()
        {
        }

        public UserPermissions(string sCnxn, string sLogPath, string sUserName, string sPassword)
        {
            try
            {
                #region History

                #endregion History

                sUserNameStatic = sUserName;
                sPasswordStatic = sPassword;

                UserPermissionsReturnMessage = Login();

            }
            catch (Exception ex)
            {
                Log oLog = new Log();
                oLog.LogError("UserPermissions: " + sUserName + ", " + sPassword + "-> ",
                    ex.Message, sLogPath);
                UserPermissionsReturnMessage = "FAILED!";
                //return null;
            }
        }

        static string Login()
        {
            try
            {
                #region History

                #endregion History
                
                SqlConnection oCnxn = new SqlConnection(sCnxnStatic);
                SqlCommand oCmd = new SqlCommand("spUserInfoFetchCredentials", oCnxn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                oCmd.Parameters.AddWithValue("@UserName", sUserNameStatic);
                oCmd.Parameters.AddWithValue("@Passwrd", sPasswordStatic);

                oCnxn.Open();
                SqlDataReader oReader = oCmd.ExecuteReader();

                while (oReader.Read())
                {
                    User oUser = new User();
                    oUser.FirstName = oReader["FirstName"].ToString();
                    oUser.MiddleName = oReader["MiddleName"].ToString();
                    oUser.LastName = oReader["LastName"].ToString();
                    oUser.UserName = oReader["UserName"].ToString();
                    oUser.Email = oReader["Email"].ToString();
                    oUser.Passwrd = oReader["Passwrd"].ToString();
                    oUser.SecurityLevelName = oReader["SecurityLevelName"].ToString();
                    oUser.IsActive = Convert.ToBoolean(oReader["IsActive"]);
                    oUser.UserID = Convert.ToInt32(oReader["UserID"]);

                    if(oUser.UserName == sUserNameStatic)
                        sLoginMessage = oUser.Passwrd == sPasswordStatic ? "SUCCESS!" : "PASSWORD Failed!";
                    else
                        sLoginMessage = "USERNAME Failed!";
                }
                oCnxn.Close();
                return sLoginMessage;
            }
            catch (Exception ex)
            {
                Log oLog = new Log();
                oLog.LogError("Login",ex.Message, sLogPathStatic);
                return "Login FAILED!";
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
