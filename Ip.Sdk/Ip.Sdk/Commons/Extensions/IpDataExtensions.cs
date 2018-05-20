using Ip.Sdk.ErrorHandling.CustomExceptions;
using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Ip.Sdk.Commons.Extensions
{
    public static class IpDataExtensions
    {   
        /// <summary>
        /// Gets a value from a data reader and converts the type to the specified generic type
        /// </summary>
        /// <typeparam name="T">The Type to convert to</typeparam>
        /// <param name="reader">The reader value</param>
        /// <param name="columnName">The column to read from the reader</param>
        /// <param name="allowNull">Should nulls be allowed, defaults to true</param>
        /// <param name="defaultValue">The Default Value to use if NULL</param>
        /// <returns>An object of Type T from the specified column in the reader</returns>
        public static T GetReaderValue<T>(this IDataReader reader, string columnName, bool allowNull = true, T defaultValue = default(T))
        {
            var value = defaultValue;

            try
            {
                if (DoesColumnExist(reader, columnName))
                {
                    var oValue = reader[columnName];

                    if (oValue != DBNull.Value)
                    {
                        value = oValue.ChangeType<T>();
                    }
                }

                //If the Type is nullable and is null, but we don't want to allow nulls, then throw an exception
                if (!allowNull && IpStandardExtensions.IsNullableValueType<T>() && Equals(value, default(T)))
                {
                    throw new IpDataExtensionException("Value cannot be null, if this error is invalid, please change the allowNull to true when calling the method");
                }
            }
            catch (Exception ex)
            {
                throw new IpDataExtensionException(string.Format("GetReaderValue() failed for columnName: {0}, type: {1}", columnName, typeof(T)), ex);
            }

            return value;
        }

        /// <summary>
        /// Gets a value from a data record and converts the type to the specified generic type
        /// </summary>
        /// <typeparam name="T">The Type to convert to</typeparam>
        /// <param name="reader">The record value</param>
        /// <param name="columnName">The column to read from the record</param>
        /// <param name="allowNull">Should nulls be allowed, defaults to true</param>
        /// <param name="defaultValue">The Default Value to use if NULL</param>
        /// <returns>An object of Type T from the specified column in the record</returns>
        public static T GetReaderValue<T>(this IDataRecord reader, string columnName, bool allowNull = true, T defaultValue = default(T))
        {
            var value = defaultValue;

            try
            {
                if (DoesColumnExist(reader, columnName))
                {
                    var oValue = reader[columnName];

                    if (oValue != DBNull.Value)
                    {
                        value = oValue.ChangeType<T>();
                    }
                }

                //If the Type is nullable and is null, but we don't want to allow nulls, then throw an exception
                if (!allowNull && IpStandardExtensions.IsNullableValueType<T>() && Equals(value, default(T)))
                {
                    throw new IpDataExtensionException("Value cannot be null, if this error is invalid, please change the allowNull to true when calling the method");
                }
            }
            catch (Exception ex)
            {
                throw new IpDataExtensionException(string.Format("GetReaderValue() failed for columnName: {0}, type: {1}", columnName, typeof(T)), ex);
            }

            return value;
        }

        /// <summary>
        /// Gets a DateTime from a Timestamp column in a data record
        /// </summary>
        /// <param name="reader">The record to look at</param>
        /// <param name="columnName">The column to look for in the record</param>
        /// <param name="allowNull">Should nulls be allowed, defaults to false</param>
        /// <returns>Returns a DateTime object from a Timestamp</returns>
        public static DateTime GetReaderTimestampDateTime(this IDataRecord reader, string columnName, bool allowNull = false)
        {
            return DoesColumnExist(reader, columnName) ?
                reader.GetReaderValue<string>(columnName, allowNull).ToDateTime(true) :
                new DateTime();
        }

        /// <summary>
        /// Gets a DateTime from a Timestamp column in a data reader
        /// </summary>
        /// <param name="reader">The reader to look at</param>
        /// <param name="columnName">The column to look for in the reader</param>
        /// <param name="allowNull">Should nulls be allowed, defaults to false</param>
        /// <returns>Returns a DateTime object from a Timestamp</returns>
        public static DateTime GetReaderTimestampDateTime(this IDataReader reader, string columnName, bool allowNull = false)
        {
            return DoesColumnExist(reader, columnName) ?
                reader.GetReaderValue<string>(columnName, allowNull).ToDateTime(true) :
                new DateTime();
        }

        /// <summary>
        /// Gets a Byte Array from a Data Record
        /// </summary>
        /// <param name="reader">IDataRecord object</param>
        /// <param name="columnName">The Column to read</param>
        /// <returns>A Byte Array</returns>
        public static byte[] GetReaderBytes(this IDataRecord reader, string columnName)
        {
            //TODO: This needs serious fixing
            try
            {
                if (DoesColumnExist(reader, columnName))
                {
                    var oValue = reader[columnName];

                    if (oValue == DBNull.Value)
                    {
                        return null;
                    }

                    using (var stream = new MemoryStream())
                    {
                        var formatter = new BinaryFormatter();
                        formatter.Serialize(stream, oValue);
                        return stream.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new IpDataExtensionException(string.Format("GetReaderValue() failed for columnName: {0}", columnName), ex);
            }

            return null;
        }

        /// <summary>
        /// Gets a Byte Array from a Data Reader
        /// </summary>
        /// <param name="reader">IDataRecord object</param>
        /// <param name="columnName">The Column to read</param>
        /// <returns>A Byte Array</returns>
        public static byte[] GetReaderBytes(this IDataReader reader, string columnName)
        {
            //TODO: This needs serious fixing
            try
            {
                if (DoesColumnExist(reader, columnName))
                {
                    var oValue = reader[columnName];

                    if (oValue == DBNull.Value)
                    {
                        return null;
                    }

                    using (var stream = new MemoryStream())
                    {
                        var formatter = new BinaryFormatter();
                        formatter.Serialize(stream, oValue);
                        return stream.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new IpDataExtensionException(string.Format("GetReaderValue() failed for columnName: {0}", columnName), ex);
            }

            return null;
        }

        /// <summary>
        /// Gets a Data Type from a Data Reader and performs necessary conversions
        /// </summary>
        /// <param name="reader">The Data Reader</param>
        /// <param name="readerIndex">The Index of the Field</param>
        /// <param name="defaultType">The Default Type to make the data</param>
        /// <returns>A Type</returns>
        public static Type GetReaderDataType(this IDataRecord reader, int readerIndex, Type defaultType)
        {
            var type = reader.GetFieldType(readerIndex);

            //If the type is null, return the specified default
            if (type == null)
            {
                return defaultType;
            }

            if (type.Name.Equals("MySqlDateTime", StringComparison.OrdinalIgnoreCase))
            {
                return typeof(DateTime);
            }

            return type;
        }

        #region Helpers
        /// <summary>
        /// Checks if a data reader column exists
        /// </summary>
        /// <param name="reader">The reader to check</param>
        /// <param name="columnName">The column name to look for</param>
        /// <returns>True if the column exists</returns>
        private static bool DoesColumnExist(IDataReader reader, string columnName)
        {
            for (var i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i) == columnName)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if a data record column exists
        /// </summary>
        /// <param name="reader">The record to check</param>
        /// <param name="columnName">The column name to look for</param>
        /// <returns>True if the column exists</returns>
        private static bool DoesColumnExist(IDataRecord reader, string columnName)
        {
            for (var i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i) == columnName)
                    return true;
            }

            return false;
        }
        #endregion
    }
}
