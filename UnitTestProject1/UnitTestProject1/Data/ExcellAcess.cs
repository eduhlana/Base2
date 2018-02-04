using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using Dapper;

namespace UnitTestProject1.Data
{
    public class ExcellAcess
    {


        public static string TestDataFileConnection()
        {
            var fileName = ConfigurationManager.AppSettings["DataPath"];
            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 12.0;", fileName);
            return con;
        }

        public static LoginData GetLoginData(string keyName)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from [Planilha$] where key='{0}'", keyName);
                var value = connection.Query<LoginData>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }

    }
}
