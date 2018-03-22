using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ITSourceManagement
{
    public class RedisHelper
    {
        public static RedisConfigInfo GetConfig()
        {
            RedisConfigInfo section = (RedisConfigInfo)ConfigurationManager.GetSection("RedisConfig");
            return section;
        }
        public static RedisConfigInfo GetConfig(string sectionName)
        {
            RedisConfigInfo section = (RedisConfigInfo)ConfigurationManager.GetSection("RedisConfig");
            if(section==null)
            {
                throw new ConfigurationErrorsException("Section"+sectionName+"does not exist");
            }
            return section;
        }
    }


    public class RedisConfigInfo : IConfigurationSectionHandler
    {
        public int MaxWritePoolSize { get; set; }
        public int MaxReadPoolSize { get; set; }
        public bool AutoStart { get; set; }
        public string WriteServerList { get; set; }
        public string ReadServerList { get; set; }


        public object Create(object parent, object configContext, System.Xml.XmlNode section)
        {
            RedisConfigInfo config = new RedisConfigInfo();
            var writesize = section.SelectSingleNode("MaxWritePoolSize");
            config.MaxWritePoolSize = int.Parse(writesize.Attributes["Value"].Value);

            return config;
        }
    }
}