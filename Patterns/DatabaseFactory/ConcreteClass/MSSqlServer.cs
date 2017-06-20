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
        public override IDbConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }

        public override IDbCommand CreateCommand()
        {
            return new SqlCommand();
        }

        public override IDbConnection CreateOpenConnection()
        {
            IDbConnection connection = new SqlConnection(connectionString);
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
    }
}
