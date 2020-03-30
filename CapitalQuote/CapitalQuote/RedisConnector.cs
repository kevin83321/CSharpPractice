using System;
using System.Collections.Generic;
using System.Text;
using StackExchange.Redis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CapitalQuote
{
    class RedisConnector
    {
        // Property
        private ConnectionMultiplexer redis;
        private IDatabase db;
        // method for using redis
        // redis.publish("test", new Dictionary<string, dynamic> { {"a","b" } });
        // redis.rpush("test", "the first test message!");
        // Console.WriteLine("from C# "+redis.lpop("test"));
        // Constructor
        public RedisConnector(string host="192.168.2.191", string port="6379", string pwd ="j7629864",int db=0)
        {
            ConfigurationOptions config = ConfigurationOptions.Parse(String.Format("{0}:{1},allowAdmin=true,password={2}", host, port, pwd));
            redis = ConnectionMultiplexer.Connect(config.ToString());
        }

        public void publish(string key, dynamic value)
        {
            db = this.redis.GetDatabase();
            db.PublishAsync(key, JsonSerializer.Serialize<dynamic>(value));
        }

        public void rpush(string key, dynamic value)
        {
            db = this.redis.GetDatabase();
            db.ListRightPushAsync(key, JsonSerializer.Serialize<dynamic>(value));
        }

        public dynamic lpop(string key)
        {
            db = this.redis.GetDatabase();
            return JsonSerializer.Deserialize<dynamic>(db.ListLeftPop(key));
        }

        //public void addListener(string key, Func<dynamic, dynamic> func)
        public void addListener(string key, Action<dynamic> func)
        {
            // add for subscriber
            var sub = this.redis.GetSubscriber();
            sub.SubscribeAsync(key, (channel, message) => func(JsonSerializer.Deserialize<dynamic>(message)));
        }
    }
}
