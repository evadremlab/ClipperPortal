using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace ClipperPortal.Extensions
{
    public static class MySqlDataReaderExtensions
    {
        public static T GetValueOfType<T>(this MySqlDataReader reader, string propertyName)
        {
            int ordinal = reader.GetOrdinal(propertyName);

            if (reader.IsDBNull(ordinal))
            {
                return default(T);
            }
            else
            {
                if (typeof(T).IsEnum)
                {
                    return (T)Enum.Parse(typeof(T), reader.GetString(ordinal));
                }
                else
                {
                    return (T)Convert.ChangeType(reader.GetValue(ordinal), typeof(T));
                }
            }
        }
    }
}