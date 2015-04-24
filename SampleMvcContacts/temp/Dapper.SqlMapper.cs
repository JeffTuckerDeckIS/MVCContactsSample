#region Assembly Dapper.dll, v1.12.1.1
// D:\__Projects\ePOD\dev\ApplicationResources\Assembly\Dapper\v1.13\net45\Dapper.dll
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Dapper
{
    // Summary:
    //     Dapper, a light weight object mapper for ADO.NET
    public static class SqlMapper
    {
        // Summary:
        //     How should connection strings be compared for equivalence? Defaults to StringComparer.Ordinal.
        //      Providing a custom implementation can be useful for allowing multi-tenancy
        //     databases with identical schema to share startegies. Note that usual equivalence
        //     rules apply: any equivalent connection strings MUST yield the same hash-code.
        public static IEqualityComparer<string> ConnectionStringComparer { get; set; }

        // Summary:
        //     Called if the query cache is purged via PurgeQueryCache
        public static event EventHandler QueryCachePurged;

        // Summary:
        //     Configire the specified type to be mapped to a given db-type
        public static void AddTypeMap(Type type, DbType dbType);
        //
        // Summary:
        //     Internal use only
        public static Action<IDbCommand, object> CreateParamInfoGenerator(SqlMapper.Identity identity, bool checkForDuplicates);
        public static int Execute(this IDbConnection cnn, string sql, dynamic param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        //
        // Summary:
        //     Internal use only
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is for internal usage only", true)]
        public static IDbDataParameter FindOrAddParameter(IDataParameterCollection parameters, IDbCommand command, string name);
        //
        // Summary:
        //     Return a list of all the queries cached by dapper
        //
        // Parameters:
        //   ignoreHitCountAbove:
        public static IEnumerable<Tuple<string, string, int>> GetCachedSQL(int ignoreHitCountAbove = 2147483647);
        //
        // Summary:
        //     Return a count of all the cached queries by dapper
        public static int GetCachedSQLCount();
        //
        // Summary:
        //     Deep diagnostics only: find any hash collisions in the cache
        public static IEnumerable<Tuple<int, int>> GetHashCollissions();
        //
        // Summary:
        //     Internal use only
        //
        // Parameters:
        //   type:
        //
        //   reader:
        //
        //   startBound:
        //
        //   length:
        //
        //   returnNullIfFirstMissing:
        public static Func<IDataReader, object> GetTypeDeserializer(Type type, IDataReader reader, int startBound = 0, int length = -1, bool returnNullIfFirstMissing = false);
        //
        // Summary:
        //     Gets type-map for the given type
        //
        // Returns:
        //     Type map implementation, DefaultTypeMap instance if no override present
        public static SqlMapper.ITypeMap GetTypeMap(Type type);
        //
        // Summary:
        //     Internal use only
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is for internal usage only", false)]
        public static void PackListParameters(IDbCommand command, string namePrefix, object value);
        //
        // Summary:
        //     Purge the query cache
        public static void PurgeQueryCache();
        public static IEnumerable<T> Query<T>(this IDbConnection cnn, string sql, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null);
        public static IEnumerable<dynamic> Query(this IDbConnection cnn, string sql, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null);
        public static IEnumerable<TReturn> Query<TFirst, TSecond, TReturn>(this IDbConnection cnn, string sql, Func<TFirst, TSecond, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);
        public static IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(this IDbConnection cnn, string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);
        public static IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(this IDbConnection cnn, string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);
        public static IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(this IDbConnection cnn, string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);
        public static IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TFourth, TReturn>(this IDbConnection cnn, string sql, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);
        public static IEnumerable<TReturn> Query<TFirst, TSecond, TThird, TReturn>(this IDbConnection cnn, string sql, Func<TFirst, TSecond, TThird, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);
        [DebuggerStepThrough]
        public static Task<IEnumerable<T>> QueryAsync<T>(this IDbConnection cnn, string sql, dynamic param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        public static Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TReturn>(this IDbConnection cnn, string sql, Func<TFirst, TSecond, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);
        [DebuggerStepThrough]
        public static Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(this IDbConnection cnn, string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);
        public static Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(this IDbConnection cnn, string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);
        public static Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(this IDbConnection cnn, string sql, Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);
        public static Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TFourth, TReturn>(this IDbConnection cnn, string sql, Func<TFirst, TSecond, TThird, TFourth, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);
        [DebuggerStepThrough]
        public static Task<IEnumerable<TReturn>> QueryAsync<TFirst, TSecond, TThird, TReturn>(this IDbConnection cnn, string sql, Func<TFirst, TSecond, TThird, TReturn> map, dynamic param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);
        public static SqlMapper.GridReader QueryMultiple(this IDbConnection cnn, string sql, dynamic param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
        //
        // Summary:
        //     Internal use only
        //
        // Parameters:
        //   value:
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is for internal usage only", false)]
        public static char ReadChar(object value);
        //
        // Summary:
        //     Internal use only
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is for internal usage only", false)]
        public static char? ReadNullableChar(object value);
        //
        // Summary:
        //     Set custom mapping for type deserializers
        //
        // Parameters:
        //   type:
        //     Entity type to override
        //
        //   map:
        //     Mapping rules impementation, null to remove custom map
        public static void SetTypeMap(Type type, SqlMapper.ITypeMap map);
        //
        // Summary:
        //     Throws a data exception, only used internally
        //
        // Parameters:
        //   ex:
        //
        //   index:
        //
        //   reader:
        public static void ThrowDataException(Exception ex, int index, IDataReader reader);

        // Summary:
        //     Implement this interface to pass an arbitrary db specific parameter to Dapper
        public interface ICustomQueryParameter
        {
            // Summary:
            //     Add the parameter needed to the command before it executes
            //
            // Parameters:
            //   command:
            //     The raw command prior to execution
            //
            //   name:
            //     Parameter name
            void AddParameter(IDbCommand command, string name);
        }

        // Summary:
        //     Implement this interface to pass an arbitrary db specific set of parameters
        //     to Dapper
        public interface IDynamicParameters
        {
            // Summary:
            //     Add all the parameters needed to the command just before it executes
            //
            // Parameters:
            //   command:
            //     The raw command prior to execution
            //
            //   identity:
            //     Information about the query
            void AddParameters(IDbCommand command, SqlMapper.Identity identity);
        }

        // Summary:
        //     Implements this interface to provide custom member mapping
        public interface IMemberMap
        {
            // Summary:
            //     Source DataReader column name
            string ColumnName { get; }
            //
            // Summary:
            //     Target field
            FieldInfo Field { get; }
            //
            // Summary:
            //     Target member type
            Type MemberType { get; }
            //
            // Summary:
            //     Target constructor parameter
            ParameterInfo Parameter { get; }
            //
            // Summary:
            //     Target property
            PropertyInfo Property { get; }
        }

        // Summary:
        //     Implement this interface to change default mapping of reader columns to type
        //     memebers
        public interface ITypeMap
        {
            // Summary:
            //     Finds best constructor
            //
            // Parameters:
            //   names:
            //     DataReader column names
            //
            //   types:
            //     DataReader column types
            //
            // Returns:
            //     Matching constructor or default one
            ConstructorInfo FindConstructor(string[] names, Type[] types);
            //
            // Summary:
            //     Gets mapping for constructor parameter
            //
            // Parameters:
            //   constructor:
            //     Constructor to resolve
            //
            //   columnName:
            //     DataReader column name
            //
            // Returns:
            //     Mapping implementation
            SqlMapper.IMemberMap GetConstructorParameter(ConstructorInfo constructor, string columnName);
            //
            // Summary:
            //     Gets member mapping for column
            //
            // Parameters:
            //   columnName:
            //     DataReader column name
            //
            // Returns:
            //     Mapping implementation
            SqlMapper.IMemberMap GetMember(string columnName);
        }

        // Summary:
        //     The grid reader provides interfaces for reading multiple result sets from
        //     a Dapper query
        public class GridReader : IDisposable
        {
            // Summary:
            //     Dispose the grid, closing and disposing both the underlying reader and command.
            public void Dispose();
            //
            // Summary:
            //     Read the next grid of results
            public IEnumerable<T> Read<T>(bool buffered = true);
            //
            // Summary:
            //     Read the next grid of results, returned as a dynamic object
            public IEnumerable<dynamic> Read(bool buffered = true);
            //
            // Summary:
            //     Read multiple objects from a single recordset on the grid
            public IEnumerable<TReturn> Read<TFirst, TSecond, TReturn>(Func<TFirst, TSecond, TReturn> func, string splitOn = "id", bool buffered = true);
            //
            // Summary:
            //     Read multiple objects from a single record set on the grid
            public IEnumerable<TReturn> Read<TFirst, TSecond, TThird, TFourth, TFifth, TReturn>(Func<TFirst, TSecond, TThird, TFourth, TFifth, TReturn> func, string splitOn = "id", bool buffered = true);
            //
            // Summary:
            //     Read multiple objects from a single record set on the grid
            public IEnumerable<TReturn> Read<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn>(Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TReturn> func, string splitOn = "id", bool buffered = true);
            //
            // Summary:
            //     Read multiple objects from a single record set on the grid
            public IEnumerable<TReturn> Read<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn>(Func<TFirst, TSecond, TThird, TFourth, TFifth, TSixth, TSeventh, TReturn> func, string splitOn = "id", bool buffered = true);
            //
            // Summary:
            //     Read multiple objects from a single record set on the grid
            public IEnumerable<TReturn> Read<TFirst, TSecond, TThird, TFourth, TReturn>(Func<TFirst, TSecond, TThird, TFourth, TReturn> func, string splitOn = "id", bool buffered = true);
            //
            // Summary:
            //     Read multiple objects from a single recordset on the grid
            public IEnumerable<TReturn> Read<TFirst, TSecond, TThird, TReturn>(Func<TFirst, TSecond, TThird, TReturn> func, string splitOn = "id", bool buffered = true);
        }

        // Summary:
        //     Identity of a cached query in Dapper, used for extensability
        public class Identity : IEquatable<SqlMapper.Identity>
        {
            // Summary:
            //     The command type
            public readonly CommandType? commandType;
            //
            public readonly string connectionString;
            //
            public readonly int gridIndex;
            //
            public readonly int hashCode;
            //
            public readonly Type parametersType;
            //
            // Summary:
            //     The sql
            public readonly string sql;
            //
            public readonly Type type;

            //
            // Parameters:
            //   obj:
            public override bool Equals(object obj);
            //
            // Summary:
            //     Compare 2 Identity objects
            //
            // Parameters:
            //   other:
            public bool Equals(SqlMapper.Identity other);
            //
            // Summary:
            //     Create an identity for use with DynamicParameters, internal use only
            //
            // Parameters:
            //   type:
            public SqlMapper.Identity ForDynamicParameters(Type type);
            //
            public override int GetHashCode();
        }
    }
}
