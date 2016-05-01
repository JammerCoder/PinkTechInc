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

                oCnxn.Open();
                SqlDataReader oReader = oCmd.ExecuteReader();

                int iRecCounter = 0;

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
                    oUser.UserID = Convert.ToInt32(oReader["UserID"]);

                    iRecCounter++;
                }
                oCnxn.Close();

                if (iRecCounter > 0)
                {
                    if (oUser.UserName == sUserName && oUser.Passwrd == sPassword)
                        UserPermissionsReturnMessage = "SUCCESS!";
                    else if (oUser.UserName != sUserName)
                        UserPermissionsReturnMessage = "USERNAME Failed!"; //There is typographical error in UserName.
                    else
                        UserPermissionsReturnMessage = "PASSWORD Failed!"; //There is typographical error in Password.

                }
                else
                {
                    oCmd.CommandText = "spUserFetchByName";
                    oCmd.Parameters.Clear();
                    oCmd.Parameters.AddWithValue("@UserName", sUserName);

                    oCnxn.Open();
                    SqlDataReader oNameDataReaderReader = oCmd.ExecuteReader();

                    while (oNameDataReaderReader.Read())
                    {
                        oUser.FirstName = oNameDataReaderReader["FirstName"].ToString();
                        oUser.MiddleName = oNameDataReaderReader["MiddleName"].ToString();
                        oUser.LastName = oNameDataReaderReader["LastName"].ToString();
                        oUser.UserName = oNameDataReaderReader["UserName"].ToString();
                        oUser.Email = oNameDataReaderReader["Email"].ToString();
                        oUser.Passwrd = oNameDataReaderReader["Passwrd"].ToString();
                        oUser.SecurityLevelName = oNameDataReaderReader["SecurityLevelName"].ToString();
                        oUser.IsActive = Convert.ToBoolean(oNameDataReaderReader["IsActive"]);
                        oUser.UserID = Convert.ToInt32(oNameDataReaderReader["UserID"]);

                        iRecCounter++;
                    }
                    if (iRecCounter > 0)
                        UserPermissionsReturnMessage = oUser.Passwrd != sPassword ? "PASSWORD Failed!" : "SUCCESS!";
                    else
                        UserPermissionsReturnMessage = "LOGIN Failed"; //Both UserName and Password Fails.
                }
                //Reminder: Recreate this function for better performance, after it functions properly....
                //Recreate: DataReader can be to the least instance.
                return oUser;
            }
            catch (Exception ex)
            {
                Log oLog = new Log();
                oLog.LogError("Login: " + sUserName + ", " + sPassword + "-> ",
                    ex.Message, sLogPath);
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
