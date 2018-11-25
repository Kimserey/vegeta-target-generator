﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace VegetaTargetGeneratorCS
{
    public class Program
    {
        static string Serialize(object data)
        {
            return JsonConvert.SerializeObject(data, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
        }

        static string EncodeBase64(string data)
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(data));
        }

        static ITarget FindTarget(string name)
        {
            var target =
                Assembly.GetExecutingAssembly().GetTypes()
                    .Where(t => typeof(ITarget).IsAssignableFrom(t) && t.IsClass)
                    .Select(t =>
                    {
                        var obj = Activator.CreateInstance(t);
                        var found = t.GetProperty("Name").GetValue(obj).ToString() == name;
                        return (obj, found);
                    })
                    .Where(res => res.found)
                    .Select(res => res.obj)
                    .FirstOrDefault();

            if (target == null)
            {
                throw new NotSupportedException("Target named " + name + " could not be found");
            }

            return target as ITarget;
        }

        static void Main(string[] args)
        {
            var rate = Convert.ToInt32(args[0]);
            var duration = Convert.ToInt32(args[1]);

            var target = FindTarget("person");

            for (int i = 0; i < rate * duration; i++)
            {
                var body = target.MakeBody();
                var vegetaTarget = new {
                    url = target.Url,
                    header = target.Header,
                    method = target.Method,
                    body = EncodeBase64(Serialize(body))
                };
                Console.WriteLine(Serialize(vegetaTarget));
            }
        }
    }
}
