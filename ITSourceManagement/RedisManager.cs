using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ITSourceManagement
{
    public class RedisManager
    {
        private static RedisConfigInfo redisConfigInfo;

        private static PooledRedisClientManager prcm;
        public RedisManager()
        {
            CreateManager();
        }

        /// <summary>
        /// 创建连接池管理对象
        /// </summary>
        private static void CreateManager()
        {
            redisConfigInfo = RedisHelper.GetConfig();
            string[] writeServerList = SplitString(redisConfigInfo.WriteServerList,",");
            string[] readServerList = SplitString(redisConfigInfo.ReadServerList, ",");
            prcm = new PooledRedisClientManager(readServerList, writeServerList, new RedisClientManagerConfig { 
                 AutoStart = redisConfigInfo.AutoStart,
                 MaxReadPoolSize = redisConfigInfo.MaxReadPoolSize,
                 MaxWritePoolSize = redisConfigInfo.MaxWritePoolSize,
            });
        }

        private static string[] SplitString(string strSource, string split)
        {
            return strSource.Split(split.ToArray());
        }  

        /// <summary>
        /// 客户端缓存操作对象
        /// </summary>
        /// <returns></returns>
        public static IRedisClient GetClient()
        {
            if(prcm == null)
            {
                CreateManager();
            }
            return prcm.GetClient();
        }
    }
}