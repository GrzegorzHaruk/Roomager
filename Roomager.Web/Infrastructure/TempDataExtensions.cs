using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace Roomager.Web.Infrastructure
{
    public static class TempDataExtensions
    {
        public static void Put<T>(this ITempDataDictionary tempdata, string key, T value) where T : class
        {            
            tempdata[key] = JsonConvert.SerializeObject(value);
        }

        public static T Get<T>(this ITempDataDictionary tempdata, string key) where T : class
        {
            object tempObj;
            tempdata.TryGetValue(key, out tempObj);
            return tempObj == null ? null : JsonConvert.DeserializeObject<T>((string)tempObj);
        }
    }
}
