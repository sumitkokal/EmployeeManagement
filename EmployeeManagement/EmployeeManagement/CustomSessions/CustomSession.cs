using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace EmployeeManagement.CustomSessions
{
    public static class CustomSession
    {
        public static void SetSessionObject<T>(this ISession session, string key, T value)
        {
            var data = JsonSerializer.Serialize(value);
            session.SetString(key, data);
        }

        public static T GetCLRObject<T>(this ISession session, string key)
        {
            var stringData = session.GetString(key);
            if (stringData != null)
            {
                T data = JsonSerializer.Deserialize<T>(stringData);
                if (data == null)
                    return default(T); // Return DEfault Instance of the CLR Object

                return data;
            }
            else
            {
                return default(T);
            }
        }
    }
}
