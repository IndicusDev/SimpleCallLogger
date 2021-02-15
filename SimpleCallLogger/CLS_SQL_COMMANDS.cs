using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCallLogger
{
    class CLS_SQL_COMMANDS
    {
        /// <summary>
        /// Holds the connection string and SQL commands used throughtout the application
        /// </summary>

        //Connection String
        public static string CONN_STRING = "Data Source=C:\\Users\\Ross\\source\\repos\\SimpleCallLogger\\SimpleCallLogger\\obj\\SimpleCallLoggerDB.db";

        /// 
        /// MainWindow
        /// 
            //W_MAIN_Loaded
                //Get Server Version
                    public static string GetServVers = "SELECT SERV_VERS FROM [T_SERV_VERS]";
                //Get Purpose
                public static string GetPurpose = "SELECT DB_ID, CALL_PURPOSE FROM T_CALL_PURPOSE WHERE PURPOSE_ACT = 1 ORDER BY CALL_PURPOSE";

    }
}
