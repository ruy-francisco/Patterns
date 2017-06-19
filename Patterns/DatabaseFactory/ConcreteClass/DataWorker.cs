using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseFactory.Abstract.Class;

namespace DatabaseFactory.ConcreteClass
{
    public class DataWorker
    {
        private static Database _database = null;

        static DataWorker()
        {
            try
            {
                _database = DatabaseFactory.CreateDatabase();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public static Database database
        {
            get
            {
                return _database;
            }
        }
    }
}
