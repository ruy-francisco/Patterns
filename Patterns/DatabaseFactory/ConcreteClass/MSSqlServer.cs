using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DatabaseFactory.Abstract.Class;


namespace DatabaseFactory.ConcreteClass
{
    public class MSSqlServer: Database
    {
        #region Overrided methods

        public override string FormatConnectionString(string rawConnectionString)
        {
            string formatedConnectionString = "";

            Dictionary<string, string> aspConnectionStringDictionary =
                               ConnectionStringToDictionary(rawConnectionString);

            if(aspConnectionStringDictionary.ContainsKey("User Id"))
            {
                formatedConnectionString = CreateLegacyConnectionString(
                        aspConnectionStringDictionary["Data Source"],
                        aspConnectionStringDictionary["Initial Catalog"],
                        aspConnectionStringDictionary["User Id"],
                        aspConnectionStringDictionary["Password"]
                    );
            }
            else
            {
                formatedConnectionString = CreateLegacyConnectionString(
                        aspConnectionStringDictionary["Data Source"],
                        aspConnectionStringDictionary["Initial Catalog"]
                    );
            }

            return formatedConnectionString;
        }

        public override IDbConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public override IDbCommand CreateCommand()
        {
            return new SqlCommand();
        }

        public override IDbConnection CreateOpenConnection()
        {
            IDbConnection connection = new SqlConnection(ConnectionString);
            connection.Open();

            return connection;
        }

        public override IDbCommand CreateCommand(string textCommand, IDbConnection connection)
        {
            return new SqlCommand(textCommand, (SqlConnection)connection);
        }

        public override IDbCommand CreateStoredProcCommand(string procName, IDbConnection connection)
        {
            return new SqlCommand(procName, (SqlConnection)connection);
        }

        public override IDataParameter CreateParameter(string parameterName, object parameterValue)
        {
            return new SqlParameter(parameterName, parameterValue);
        }

        #endregion

        #region Auxiliar methods

        /// <summary>
        /// Cria a connection string com usuário e senha
        /// </summary>
        /// <param name="dataSource">servidor</param>
        /// <param name="initialCatalog">base de dados</param>
        /// <param name="userId">usuario</param>
        /// <param name="password">password</param>
        /// <returns></returns>
        protected string CreateLegacyConnectionString(string dataSource, string initialCatalog, string userId = "", string password = "")
        {
            string connectionString;
            if(String.IsNullOrEmpty(userId))
                connectionString = String.Format("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog={0};Data Source={1}", initialCatalog, dataSource);
            else
                connectionString = String.Format("Data Source={0};User Id={1};Password={2};Initial Catalog={3}", dataSource, userId, password, initialCatalog);

            return connectionString;
        }

        /// <summary>
        /// Sala as connection strings em um dicionário
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns>Dicionarios</returns>
        protected Dictionary<string, string> ConnectionStringToDictionary(string connectionString)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            string[] connectionStringArray = connectionString.Split(';');
            foreach(string token in connectionStringArray)
            {
                string[] tokenArray = token.Split('=');
                if(tokenArray.Length != 2)
                {
                    throw new Exception("Invalid Connection String");
                }
                dictionary.Add(tokenArray[0], tokenArray[1]);
            }
            return dictionary;
        }

        #endregion
    }
}
