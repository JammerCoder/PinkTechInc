using System.Configuration;

namespace PinkTechInc
{
    public class Global
    {
        public string Cnxn()
        {
            return ConfigurationManager.AppSettings["Cnxn"];
        }

        public string LogPath()
        {
            return ConfigurationManager.AppSettings["LogPath"];
        }
        
    }
}