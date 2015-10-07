using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationUtilities.Utils
{
    class Setings
    {
        private static string sectionName = "TestInstances/" + System.Configuration.ConfigurationManager.AppSettings["instance"]; 
        
        private static Lazy<ServerConfigurationSection> instance =
           new Lazy<ServerConfigurationSection>(() =>
           {
               return (ServerConfigurationSection)
                   System.Configuration.ConfigurationManager.GetSection(sectionName);
           });
        private Setings()
        {

        }

        public static ServerConfigurationSection Instance
        {
            get
            {
               return instance.Value;
            }
        }
    }
}
