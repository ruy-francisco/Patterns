using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Configuration;
using DatabaseFactory.CustomConfig;
using DatabaseFactory.Abstract.Class;

namespace DatabaseFactory.ConcreteClass
{
    public sealed class DatabaseFactory
    {
        public static DatabaseFactorySectionHandler sectionHandler = (DatabaseFactorySectionHandler)ConfigurationManager.GetSection("customConfigurations/DatabaseFactorySectionHandler");
        private DatabaseFactory(){}
        public static Database CreateDatabase()
        {
            if(sectionHandler.Name.Length == 0)
            {
                throw new Exception("Database name not defined in DatabaseFactoryConfiguration section of App.config");
            }

            try
            {
                Type database = Type.GetType(sectionHandler.Name);
                ConstructorInfo constructor = database.GetConstructor(new Type[] { });

                Database databaseObject = (Database)constructor.Invoke(null);
                databaseObject.connectionString = sectionHandler.ConnectionString;

                return databaseObject;
            }
            catch(Exception e)
            {
                throw new Exception("Error instantiating database " + sectionHandler.Name + ". ", e);
            }
        }

    }
}
