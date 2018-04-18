using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using Dapper;

namespace RegressaoGCP.Data
{
    public class ExcellAcess : Planilha
    {
        public Planilha Planilha = new Planilha();
        public static string TestDataFileConnection()
        {
            var fileName = ConfigurationManager.AppSettings["DataPath"];
            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 12.0;", fileName);
            return con;
        }

        public static Planilha PegaLinha(string keyName)
        {
            using (var connection = new OleDbConnection(TestDataFileConnection()))
            {
                connection.Open();
                var query = string.Format("select * from [Comercial$] where Teste='{0}'", keyName);
                var value = connection.Query<Planilha>(query).FirstOrDefault();
                connection.Close();
                return value;
            }
        }

    }
}
