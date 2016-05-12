using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinkTechCompanion
{
    public class User
    {
        #region Properties

        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SecurityLevelName { get; set; }
        public int SecurityLevelID { get; set; }
        public bool IsActive { get; set; }
        #endregion Properties
    }

    public class Users : Dictionary<int, User>
    {
        public Users()
        {
        }

        public Users(string sCnxn, string sLogPath)
        {
            SqlConnection oCnxn = new SqlConnection(sCnxn);
            try
            {
                SqlCommand oCmd = new SqlCommand()
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "spUserInfoFetchAll",
                    Connection = oCnxn
                };

                oCnxn.Open();
                SqlDataReader oReader = oCmd.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        User oUser = new User();
                        oUser.UserName = oReader["UserName"].ToString();
                        oUser.FirstName = oReader["FirstName"].ToString();
                        oUser.MiddleName = oReader["MiddleName"].ToString();
                        oUser.LastName = oReader["LastName"].ToString();
                        oUser.UserName = oReader["UserName"].ToString();
                        oUser.Email = oReader["Email"].ToString();
                        oUser.Password = oReader["Password"].ToString();
                        oUser.SecurityLevelName = oReader["SecurityLevelName"].ToString();
                        oUser.SecurityLevelID = Convert.ToInt32(oReader["SecurityLevelID"]);
                        oUser.IsActive = Convert.ToBoolean(oReader["IsActive"]);
                        oUser.UserID = Convert.ToInt32(oReader["UserID"]);

                        if (!ContainsKey(oUser.UserID))
                            Add(oUser.UserID, oUser);
                    }
                }
            }
            catch (Exception ex)
            {
                Log oLog = new Log();
                oLog.LogError("Users: ", ex.Message, sLogPath);
            }
            finally
            {
                oCnxn.Close();
            }
        }

        public Users(string sCnxn, string sLogPath, int iUserID)
        {
            SqlConnection oCnxn = new SqlConnection(sCnxn);
            try
            {
                SqlCommand oCmd = new SqlCommand()
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "spUserInfoFetchAll",
                    Connection = oCnxn
                };

                oCnxn.Open();
                SqlDataReader oReader = oCmd.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        User oUser = new User();
                        oUser.UserName = oReader["UserName"].ToString();
                        oUser.FirstName = oReader["FirstName"].ToString();
                        oUser.MiddleName = oReader["MiddleName"].ToString();
                        oUser.LastName = oReader["LastName"].ToString();
                        oUser.UserName = oReader["UserName"].ToString();
                        oUser.Email = oReader["Email"].ToString();
                        oUser.Password = oReader["Password"].ToString();
                        oUser.SecurityLevelName = oReader["SecurityLevelName"].ToString();
                        oUser.SecurityLevelID = Convert.ToInt32(oReader["SecurityLevelID"]);
                        oUser.IsActive = Convert.ToBoolean(oReader["IsActive"]);
                        oUser.UserID = Convert.ToInt32(oReader["UserID"]);

                        if (oUser.UserID != iUserID)
                            if (!ContainsKey(oUser.UserID))
                                Add(oUser.UserID, oUser);
                    }
                }
            }
            catch (Exception ex)
            {
                Log oLog = new Log();
                oLog.LogError("Users: ", ex.Message, sLogPath);
            }
            finally
            {
                oCnxn.Close();
            }
        }

    }
}
