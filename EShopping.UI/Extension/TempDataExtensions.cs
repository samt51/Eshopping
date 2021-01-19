﻿using System;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace EShopping.UI.Extension
{
    public static class TempDataExtensions
    {
       public static void Put<T>(this ITempDataDictionary tempdata,string key,T value)
        {
            tempdata[key] = JsonConvert.SerializeObject(value);

        }
        public static T Get<T>(this ITempDataDictionary tempdata,string key)where T : class
        {
            object o;
            tempdata.TryGetValue(key, out o);
            return o == null ? null : JsonConvert.DeserializeObject<T>((string)o);
        }
    }
}
