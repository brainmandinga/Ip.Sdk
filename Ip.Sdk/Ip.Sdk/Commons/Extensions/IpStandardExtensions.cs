using Ip.Sdk.ErrorHandling;
using System;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Ip.Sdk.Commons.Extensions
{
    public static class IpStandardExtensions
    {
        /// <summary>
        /// Returns a concatenated string of the exception details
        /// </summary>
        /// <param name="ex">The Exception</param>
        /// <returns></returns>
        public static string FullExceptionMsg(this Exception ex, string message = null)
        {
            var serialException = new SerializableException(ex, message);
            return serialException.SerializeException();
        }

        /// <summary>
        /// Extension method to change the type of an object with null safety
        /// </summary>
        /// <typeparam name="T">The type to convert to</typeparam>
        /// <param name="value">The value to convert</param>
        /// <returns>An object of Type T</returns>
        public static T ChangeType<T>(this object value)
        {
            var type = typeof(T);

            if (type == typeof(bool))
            {
                return (T)Convert.ChangeType(value.ToBool(), type);
            }

            if (value == null || value is DBNull)
            {
                return default(T);
            }

            if (IsNullableValueType<T>())
            {
                return (T)Convert.ChangeType(value, Nullable.GetUnderlyingType(type));
            }

            return (T)Convert.ChangeType(value, type);
        }

        /// <summary>
        /// Converts a string to an Enumeration
        /// </summary>
        /// <typeparam name="T">The type of enum</typeparam>
        /// <param name="s">The string to convert</param>
        /// <returns>A string parsed to an enum</returns>
        public static T ToEnum<T>(this string s) where T : struct
        {
            //If the enumeration is not defined, return the default
            if (!Enum.IsDefined(typeof(T), s))
            {
                return default(T);
            }

            //Parse and return the enum
            return (T)Enum.Parse(typeof(T), s);
        }

        /// <summary>
        /// Converts a string to an Enumeration
        /// </summary>
        /// <typeparam name="T">The type of enum</typeparam>
        /// <param name="s">The string to convert</param>
        /// <param name="defaultValue">The default enumeration value to use if the string is not defined</param>
        /// <returns>A string parsed to an enum</returns>
        public static T ToEnum<T>(this string s, T defaultValue) where T : struct
        {
            //If the string is null or empty, return the deafult
            if (string.IsNullOrWhiteSpace(s))
            {
                return defaultValue;
            }

            //If the enumeration is not defined, return the specified default
            if (!Enum.IsDefined(typeof(T), s))
            {
                return defaultValue;
            }

            //Parse and return the enum
            return (T)Enum.Parse(typeof(T), s);
        }

        /// <summary>
        /// Returns an Enumerators Description string
        /// </summary>
        /// <param name="value">The Enumerator to parse</param>
        /// <returns>Description string</returns>
        public static string ToDescription(this Enum value)
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);
            var field = type.GetField(name);

            // Check for the Description Attribute.
            var attributes = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Any() ? attributes[0].Description : name;
        }

        /// <summary>
        /// Converts a string to a date time
        /// </summary>
        /// <param name="value">The value to convert</param>
        /// <param name="isTimestamp">Is the string a timestamp format</param>
        /// <returns>A converted DateTime object</returns>
        public static DateTime ToDateTime(this string value, bool isTimestamp = false)
        {
            if (isTimestamp)
            {
                return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(value.ToLong()).ToLocalTime();
            }

            DateTime result;
            DateTime.TryParse(value, out result);
            return result;
        }

        /// <summary>
        /// Converts a string to a decimal
        /// </summary>
        /// <param name="value">The string to convert</param>
        /// <returns>A converted decimal object</returns>
        public static decimal ToDecimal(this string value)
        {
            decimal.TryParse(value, out decimal result);
            return result;
        }

        /// <summary>
        /// Converts a string to a double
        /// </summary>
        /// <param name="value">The string to convert</param>
        /// <returns>A converted double object</returns>
        public static double ToDouble(this string value)
        {
            double.TryParse(value, out double result);
            return result;
        }

        /// <summary>
        /// Converts a string to an int
        /// </summary>
        /// <param name="value">The string to convert</param>
        /// <returns>A converted int object</returns>
        public static int ToInt(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return 0;
            }

            if (value.Contains("."))
            {
                value = value.Substring(0, value.IndexOf(".", StringComparison.Ordinal));
            }

            int.TryParse(value, out int result);
            return result;
        }

        /// <summary>
        /// Converts a string to a long
        /// </summary>
        /// <param name="value">The string to convert</param>
        /// <returns>A converted long object</returns>
        public static long ToLong(this string value)
        {
            if (value.Contains("."))
            {
                value = value.Substring(0, value.IndexOf(".", StringComparison.Ordinal));
            }

            long.TryParse(value, out long result);
            return result;
        }

        /// <summary>
        /// Converts a string to a bool
        /// </summary>
        /// <param name="value">The string to convert</param>
        /// <returns>A converted bool object</returns>
        public static bool ToBool(this string value)
        {
            return IsTrue(value);
        }

        /// <summary>
        /// Converts an object to a boolean, handles strings "true", "false" and numeric values of 0 or greater than 0 as well as boolean objects
        /// </summary>
        /// <param name="oValue">The object to convert</param>
        /// <returns>A boolean representation of the object</returns>
        public static bool ToBool(this object oValue)
        {
            if (oValue is int || oValue is long)
            {
                return Convert.ToInt64(oValue) > 0;
            }

            if (oValue is string)
            {
                return IsTrue(oValue.ToString());
            }

            if (oValue is bool)
            {
                return (bool)oValue;
            }

            return false;
        }

        /// <summary>
        /// Parses an XElement value to a specified Type
        /// </summary>
        /// <typeparam name="T">The Type to convert to</typeparam>
        /// <param name="element">The element to convert</param>
        /// <returns>The Element value as Type T</returns>
        public static T ParseXElementValue<T>(this XElement element)
        {
            if (element == null)
            {
                return default(T);
            }

            try
            {
                return element.Value.ChangeType<T>();
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// Converts to a DateTime from a UNIX Epoch
        /// </summary>
        /// <param name="epoch">The UNIX Epoch Value</param>
        /// <returns>A DateTime</returns>
        public static DateTime FromEpoch(this int epoch)
        {
            //Create the base date Epoch and return it
            var retVal = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            return retVal.AddSeconds(epoch);
        }

        /// <summary>
        /// Converts a DateTime to a UNIX Epoch
        /// </summary>
        /// <param name="date">The DateTime Value</param>
        /// <returns>A UNIX Epoch</returns>
        public static int ToEpoch(this DateTime date)
        {
            //Subtract the date from the unix epoch and return the floor of the total seconds
            var timespan = date.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc));
            return (int)Math.Floor(timespan.TotalSeconds);
        }

        /// <summary>
        /// Converts to a nullable UNIX Epoch from a DateTime
        /// </summary>
        /// /// <param name="date">The DateTime Value</param>        
        /// <returns>A UNIX Epoch</returns>
        public static int? ToEpoch(this DateTime? date)
        {
            if (!date.HasValue)
            {
                return null;
            }

            return date.Value.ToEpoch();
        }

        /// <summary>
        /// Converts a UNIX Epoch to a Nullable DateTime
        /// </summary>
        /// <param name="epoch">The UNIX Epoch Value</param>
        /// <returns>A nullable DateTime</returns>
        public static DateTime? FromEpoch(this int? epoch)
        {
            if (!epoch.HasValue)
            {
                return null;
            }

            return epoch.Value.FromEpoch();
        }

        #region Helpers
        /// <summary>
        /// Use this method to check value types as being nullable, eg... DateTime?
        /// </summary>
        /// <typeparam name="T">The Type to check</typeparam>
        /// <returns>True if it's nullable</returns>
        public static bool IsNullableValueType<T>()
        {
            return typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        /// <summary>
        /// Checks non-boolean values to see if they would evaluate to true
        /// </summary>
        /// <param name="value">The value to evaluate</param>
        /// <returns>Whether or not it evaluates to true</returns>
        public static bool IsTrue(string value)
        {
            return value.Equals("true", StringComparison.OrdinalIgnoreCase) ||
                   value.Equals("yes", StringComparison.OrdinalIgnoreCase) ||
                   value.Equals("on", StringComparison.OrdinalIgnoreCase) ||
                   value.Equals("1");
        }
        #endregion
    }
}
