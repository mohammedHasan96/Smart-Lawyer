using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using ParamtersMap = System.Collections.Generic.Dictionary<string, object>;

namespace SmartLawyer.Models
{
    static partial class DataAccess
    {
        public static String Host { get; set; } = "66.42.39.74";
        public static uint Port { get; set; } = 3306;
        public static String Database { get; set; } = "smart_lawyer";
        public static String UserID { get; set; } = "khateeb";
        public static String Password { get; set; } = "ZpIPqHnqYBTdoUfx@2018";

        public static MySqlConnection OpenConnection()
        {
            var builder = new MySqlConnectionStringBuilder()
            {
                Server = Host,
                Port = Port,
                UserID = UserID,
                Password = Password,
                Database = Database,
                SslMode = MySqlSslMode.None
            }.ToString();
            return new MySqlConnection(builder).With(x=>x.Open());
        }

        static void TestInsert()
        {
            var changedCount = Insert(out var ID, "customer", new ParamtersMap
            {
                ["CustomerName"] = "Ahmed",
                ["BD"] = new DateTime(1990, 4, 6),
            });
        }

        static void TestUpdate(int targetID)
        {

            /*
             Update CustomerTable set CustomerName = 'Ahmed', BD = '1990/...' , .... where customerID in [1005,950]
             
             */


            var changedCount = Update("customer", new ParamtersMap
            {
                ["CustomerName"] = "Ahmed",
                ["BD"] = new DateTime(1990, 4, 6),

            }, $"customerID={targetID}");
        }

        static int Insert(out long insertID, string tableName, ParamtersMap values)
        {
            using (var conn = OpenConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    var nanmes = values.Select(x => x.Key).Aggregate((x, y) => $"{x},{y}");
                    var prms = values.Select(x => $"@{x.Key}").Aggregate((x, y) => $"{x},{y}");
                    cmd.CommandText = $"INSERT INTO {tableName} ({nanmes}) VALUES({prms})";
                    foreach (var item in values)
                        cmd.Parameters.Add(new MySqlParameter(item.Key, item.Value));
                    cmd.Prepare();
                    var changedCount = cmd.ExecuteNonQuery();
                    insertID = cmd.LastInsertedId;
                    return changedCount;
                }
            }
        }
        static int Update(string tableName, Dictionary<string, object> values, string condition, Dictionary<string, object> conditionParamerters = null)
        {
            using (var conn = OpenConnection())
            {
                using (var cmd = conn.CreateCommand())
                {

                    var pairs = values.Select(x => $"{x.Key} = @{x.Key}").Aggregate((x, y) => $"{x},{y}");

                    cmd.CommandText = $"UPDATE {tableName} SET {pairs} WHERE {condition}";

                    foreach (var item in values)
                        cmd.Parameters.Add(new MySqlParameter(item.Key, item.Value));

                    if (conditionParamerters != null)
                        foreach (var item in conditionParamerters)
                            cmd.Parameters.Add(new MySqlParameter(item.Key, item.Value));
                    cmd.Prepare();
                    var changedCount = cmd.ExecuteNonQuery();
                    return changedCount;
                }
            }
        }
        static int Delete(string tableName, string condition, Dictionary<string, object> conditionParamerters = null)
        {
            using (var conn = OpenConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"DELETE FROM {tableName} WHERE {condition}";

                    if (conditionParamerters != null)
                        foreach (var item in conditionParamerters)
                            cmd.Parameters.Add(new MySqlParameter(item.Key, item.Value));
                    cmd.Prepare();

                    var changedCount = cmd.ExecuteNonQuery();
                    return changedCount;
                }
            }
        }

        public static IEnumerable<ParamtersMap> RunSelectQ(string query, ParamtersMap parameters)
        {
            using (var con = OpenConnection())
            {
                using (var cmd = con.CreateCommand())
                {
                    cmd.CommandText = query;
                    foreach (var c in parameters)
                        cmd.Parameters.Add(new MySqlParameter($"@{c.Key}", c.Value));
                    cmd.Prepare();
                    
                    using (var reader = cmd.ExecuteReader())
                    {
                        //var columns = Enumerable.Range(0, reader.FieldCount)
                        //    .Select(x => reader.GetName(x)).ToList();

                        while (reader.Read())
                        {
                            yield return Enumerable.Range(0, reader.FieldCount)
                                .ToDictionary(x => reader.GetName(x), x => reader.GetValue(x));
                        }
                    }
                }
            }
        }




        public static IEnumerable<Type> MeAndBaseTypes(this Type t)
        {
            while (t != null)
            {
                yield return t;
                t = t.BaseType;
            }
        }
        //TODO:: Use The Table Mapping
        public static T ReadAs<T>(this ParamtersMap src, bool ignoreCase = true) where T : new()
        {
            var r = new T();
            var map = src;
            if (ignoreCase)
                map = map.ToDictionary(x => x.Key?.ToLower(), x => x.Value);

            var bndFlags = System.Reflection.BindingFlags.GetProperty |
                 System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public;
            var props = typeof(T).MeAndBaseTypes().SelectMany(x => x.GetProperties(bndFlags));
            foreach (var p in props)
            {
                var propName = p.Name;
                if (ignoreCase) propName = propName?.ToLower();

                if (map.TryGetValue(propName, out var value))
                {
                    var propType = p.PropertyType;
                    if (value is DBNull) value = null;

                    SetProperty(p, r, value);
                }
            }
            return r;
        }


        public static T ReadAs<T>(this ParamtersMap src, Type ColumnInfoType, bool ignoreCase = false)
            where T : new()
        {
            var dict = ColumnInfoType.GetProperties(System.Reflection.BindingFlags.GetProperty |
                 System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public)
                 .Where(x => x.PropertyType == typeof(ColumnInfo))
                 .ToDictionary(x => x.Name, x => (ColumnInfo)x.GetValue(null, null));
            return src.ReadAs<T>(dict, ignoreCase);
        }
        public static T ReadAs<T>(this ParamtersMap src, Dictionary<string, ColumnInfo> columns, bool ignoreCase = false) where T : new()
        {
            var r = new T();
            var map = src;
            if (ignoreCase)
                map = map.ToDictionary(x => x.Key?.ToLower(), x => x.Value);

            var bndFlags = System.Reflection.BindingFlags.GetProperty |
               System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public;
            var props = typeof(T).MeAndBaseTypes().SelectMany(x => x.GetProperties(bndFlags));


            bool Equals(string a, string b)
            {
                return CultureInfo.InvariantCulture.CompareInfo.Compare
                (a, b, ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None) == 0;
            }
            foreach (var kv in src)
            {
                var name = columns
                    .FirstOrDefault(x => Equals(x.Value.Name, kv.Key) && props.Any(pr => Equals(pr.Name, x.Key)))
                    .Key ?? kv.Key;



                var p = props.FirstOrDefault(x => Equals(x.Name, name));
                if (p == null) continue;


                var propName = p.Name;
                if (ignoreCase) propName = propName?.ToLower();


                var value = kv.Value;
                try
                {
                    SetProperty(p, r, value);
                }
                catch (Exception exp)
                {
                    throw new Exception($"Error Setting Property [{p.Name}:{p.PropertyType}] of class [{typeof(T).Name}] to value [{value?.GetType()}:{value}]", exp);
                }
            }
            return r;
        }
        static void SetProperty(PropertyInfo prop, object target, object value)
        {
            if (prop.Name == "LastScanDate")
            {

            }
            var propType = prop.PropertyType;
            if (value is DBNull) value = null;

            object dValue = null;
            if (value == null && (dValue = propType.DefaultValue()) != null)
                value = dValue;


            var valueType = value?.GetType();

            if (valueType != null && propType != valueType
                && value is IConvertible vconv && typeof(IConvertible).IsAssignableFrom(propType))
                //if (propType == typeof(DateTime) && value.ToString() == "0")
                //    value = DateTime.MinValue;
                //else
                value = vconv.ToType(propType, null);

            prop.SetValue(target, value, null);
        }
        public static T DefaultValueOf<T>() => default(T);
        public static object DefaultValue(this Type t)
        {
            Func<int> dInt = DefaultValueOf<int>;
            var gen = dInt.Method.GetGenericMethodDefinition();
            var getOfT = gen.MakeGenericMethod(t);
            return getOfT.Invoke(null, null);
        }




        public static T With<T>(this T value, Action<T> action)
        {
            action?.Invoke(value);
            return value;
        }

        public static T As<T>(this object v) => (v is T) ? (T)v : default(T);





        public static IEnumerable<T> SQLSelectTableAs<T>(string tableName, ParamtersMap prms = null, bool mappingIgnoreCase = true, Action<ParamtersMap> itemCallBack = null)
                   where T : new()
        {

            return SQLSelectAs<T>($"select * from {tableName}", prms, mappingIgnoreCase, itemCallBack);
        }


        public static IEnumerable<T> SQLSelectAs<T>(string query, ParamtersMap prms = null, bool mappingIgnoreCase = true, Action<ParamtersMap> itemCallBack = null)
                   where T : new()
        {
            return RunSelectQ(query, prms ?? new ParamtersMap())
                .Select(x => x.With(v => itemCallBack?.Invoke(v))
                .ReadAs<T>(mappingIgnoreCase));
        }

        public static IEnumerable<T> SQLSelectAs<T>(string query,  Type tabelMapping,ParamtersMap prms = null, bool mappingIgnoreCase = true,
            Action<ParamtersMap> itemCallBack = null)
           where T : new()
        {
            return RunSelectQ(query, prms ?? new ParamtersMap()).Select(x => x.With(v => itemCallBack?.Invoke(v)).ReadAs<T>(tabelMapping, mappingIgnoreCase));
        }
    }
}
