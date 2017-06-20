using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseFactory.ConcreteClass;

namespace DatabaseFactory.ConcreteClass
{
    public class DatabaseHandler: DataWorker
    {
        public static bool CreateTable(string tableName)
        {
            try
            {
                using(var openConnection = database.CreateOpenConnection())
                {
                    string sqlCommand = "create table @name(id int identity)";

                    var command = database.CreateCommand(sqlCommand, openConnection);
                    command.Parameters.Add(database.CreateParameter("@name", tableName));

                    command.ExecuteNonQuery();

                    return true;
                }
            }
            catch(Exception e)
            {
                throw e;
            }            
        }
    }
}
