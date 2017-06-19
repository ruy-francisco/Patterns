using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DatabaseFactory.CustomConfig
{    

    public sealed class DatabaseFactorySectionHandler : ConfigurationSection
    {
        [ConfigurationProperty("Name")]
        public String Name
        {
            get{
                return (string)base["Name"]; 
            }
        }

        [ConfigurationProperty("ConnectionStringName")]
        public string ConnectionStringName
        {
            get
            {
                return (string)base["ConnectionStringName"];
            }
        }

        public string ConnectionString
        {
            get
            {
                try
                {
                    return ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
                }
                catch(Exception e)
                {
                    throw new Exception("Connection string " + ConnectionStringName + " was not found in App.config file.", e);
                }
            }
        }
    }
}
