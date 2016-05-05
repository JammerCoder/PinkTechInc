using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinkTechCompanion
{
    public class Messages : Dictionary<int, Message>
    {
        public Messages()
        {
        }

        public Messages(string sCnxn, string sLogPath, int iUserID)
        {
            SqlConnection oCnxn = new SqlConnection(sCnxn);
            try
            {
                SqlCommand oCmd = new SqlCommand("spUserMessagesFetchByID", oCnxn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                oCmd.Parameters.AddWithValue("@UserID", iUserID);

                oCnxn.Open();
                SqlDataReader oReader = oCmd.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        Message oNewMessage = new Message();

                        oNewMessage.MessageID = Convert.ToInt32(oReader["MessageID"]);
                        oNewMessage.Subject = oReader["Subject"].ToString();
                        oNewMessage.Sender = oReader["Sender"].ToString();
                        oNewMessage.CreatedDate = oReader["CreatedDate"].ToString();
                        oNewMessage.Status = Convert.ToBoolean(oReader["Status"]);
                        oNewMessage.UserID = Convert.ToInt32(oReader["UserID"]);

                        if (!ContainsKey(oNewMessage.UserID))
                            Add(oNewMessage.MessageID, oNewMessage);
                    }
                }
                //return oNewMessage;
            }
            catch (Exception ex)
            {
                Log oLog = new Log();
                oLog.LogError("Messages: ", ex.Message, sLogPath);
                //return null;
            }
            finally
            {
                oCnxn.Close();
            }
        }

        public DataTable SentMessages(string sCnxn, string sLogPath, int iUserID)
        {
            /*Moved from BookList*/
            //Instantiating new connection object
            SqlConnection oCnxn = new SqlConnection(sCnxn);

            try
            {
                List<SentMessage> oSentMessages = new List<SentMessage>();
                Dictionary<int, SentMessage> oSentMessagesNew = new Dictionary<int, SentMessage>();

                #region Code Block Can be Refactored

                //Instantiating Sql Command Object 
                //Requires the Connection Information above and CommandText
                SqlCommand oCmd = new SqlCommand();
                oCmd.Connection = oCnxn;
                oCmd.CommandType = CommandType.StoredProcedure;
                #endregion

                oCmd.CommandText = "spSentMessagesFetchByID";
                oCmd.Parameters.AddWithValue("@SenderID", iUserID);
                

                //Instantiating new DataTable
                DataTable dtSentMessages = new DataTable();
                //Instantiating new SqlDataAdapter
                SqlDataAdapter daNewMessages = new SqlDataAdapter();
                daNewMessages.SelectCommand = oCmd;

                //Connection Gate
                oCnxn.Open();
                daNewMessages.SelectCommand.ExecuteNonQuery();
                daNewMessages.Fill(dtSentMessages);
                oCnxn.Close();

                return (dtSentMessages);
            }
            catch (Exception ex)
            {
                Log oLog = new Log();
                oLog.LogError("SentMessages: ", ex.Message, sLogPath);
                return null;
            }
            finally
            {
                oCnxn.Close();
            }
        }
    }

    public class Message
    {
        #region Properties
        public int UserID { get; set; }
        public int MessageID { get; set; }
        public string Subject { get; set; }
        public string Sender { get; set; }
        public string CreatedDate { get; set; }
        public bool Status { get; set; }
        #endregion Properties
    }
    public class SentMessage
    {
        #region Properties

        public int MessageID { get; set; }
        public int SenderID { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Recepients { get; set; }
        public string CreatedDate { get; set; }
        public bool Status { get; set; }
        #endregion Properties
    }


}
