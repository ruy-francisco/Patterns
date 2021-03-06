﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Configuration;
using DatabaseFactory.Abstract.Class;
using System.Collections.Specialized;

namespace DatabaseFactory.ConcreteClass
{
    public sealed class DatabaseFactory
    {
        private DatabaseFactory(){ }
        public static Database CreateDatabase(string dbSystem, string connectionString)
        {
            var sectionHandler = ConfigurationManager.GetSection("DatabaseFactory") as NameValueCollection;

            if(sectionHandler[dbSystem].Length == 0)
                throw new Exception("Database name not defined in DatabaseFactoryConfiguration section of App.config");

            try
            {
                Type database = Type.GetType(Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Name == dbSystem).FirstOrDefault().FullName);
                ConstructorInfo constructor = database.GetConstructor(new Type[] { });

                Database databaseObject = (Database)constructor.Invoke(null);
                databaseObject.ConnectionString = connectionString;

                return databaseObject;
            }
            catch(Exception e)
            {
                throw new Exception("Error instantiating database " + dbSystem + ". ", e);
            }
        }

    }
}
