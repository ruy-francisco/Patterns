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
            throw new NotImplementedException();
        }

        public override IDbConnection CreateOpenConnection()
        {
            throw new NotImplementedException();
        }

        public override IDbCommand CreateCommand(string textCommand, IDbConnection connection)
        {
            throw new NotImplementedException();
        }

        public override IDbCommand CreateStoredProcCommand(string procName, IDbConnection connection)
        {
            throw new NotImplementedException();
        }

        public override IDataParameter CreateParameter(string parameterName, object parameterValue)
        {
            throw new NotImplementedException();
        }
    }
}
