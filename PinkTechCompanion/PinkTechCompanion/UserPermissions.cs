using System;
using System.Data;
using System.Data.SqlClient;


namespace PinkTechCompanion
{
    public class UserPermissions
    {
        public static string UserPermissionsReturnMessage { get; set; }

        public static User Login(string sCnxn, string sLogPath, string sUserName, string sPassword)
        {
            UserPermissionsReturnMessage = "";
            SqlConnection oCnxn = new SqlConnection(sCnxn);
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

                SqlCommand oCmd = new SqlCommand("spUserInfoFetchCredentials", oCnxn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                oCmd.Parameters.AddWithValue("@UserName", sUserName);
                oCmd.Parameters.AddWithValue("@Passwrd", sPassword);

                User oUser = new User();

                oCnxn.Open();
                SqlDataReader oReader = oCmd.ExecuteReader();

                if (oReader.HasRows)
                {
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
                        oUser.UserID = Convert.ToInt32(oReader["UserID"]);
                    }
                    if (oUser.UserName == sUserName && oUser.Passwrd == sPassword)
                        UserPermissionsReturnMessage = "SUCCESS!";
                    else if (oUser.UserName != sUserName)
                        UserPermissionsReturnMessage = "USERNAME Failed!"; //There is problem or typographical error in UserName.
                    else
                        UserPermissionsReturnMessage = "PASSWORD Failed!"; //There is problem or typographical error in Password.

                    oCnxn.Close();
                }
                else
                {
                    oCnxn.Close();

                    oCmd.CommandText = "spUserFetchByName";
                    oCmd.Parameters.Clear();
                    oCmd.Parameters.AddWithValue("@UserName", sUserName);
                    
                    oCnxn.Open();
                    SqlDataReader oNameDataReader = oCmd.ExecuteReader();

                    while (oNameDataReader.Read())
                    {
                        oUser.FirstName = oNameDataReader["FirstName"].ToString();
                        oUser.MiddleName = oNameDataReader["MiddleName"].ToString();
                        oUser.LastName = oNameDataReader["LastName"].ToString();
                        oUser.UserName = oNameDataReader["UserName"].ToString();
                        oUser.Email = oNameDataReader["Email"].ToString();
                        oUser.Passwrd = oNameDataReader["Passwrd"].ToString();
                        oUser.SecurityLevelName = oNameDataReader["SecurityLevelName"].ToString();
                        oUser.IsActive = Convert.ToBoolean(oNameDataReader["IsActive"]);
                        oUser.UserID = Convert.ToInt32(oNameDataReader["UserID"]);
                    }
                    if (oNameDataReader.HasRows)
                        UserPermissionsReturnMessage = oUser.Passwrd != sPassword ? "PASSWORD Failed!" : "SUCCESS!";
                    else
                        UserPermissionsReturnMessage = "LOGIN Failed"; //Both UserName and Password Fails.
                }
                return oUser;
            }
            catch (Exception ex)
            {
                Log oLog = new Log();
                oLog.LogError("Login: ", ex.Message, sLogPath);
                UserPermissionsReturnMessage = "Error Exeption found, Login FAILED!";
                return null;
            }
            finally
            {
                oCnxn.Close();
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
