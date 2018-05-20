using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Ip.Sdk.ErrorHandling
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SerializableException
    {
        private List<SerializableException> _innerExceptions;

        /// <summary>
        /// A custom message for the object
        /// </summary>
        [JsonProperty("customMessage")]
        public string CustomMessage { get; set; }

        /// <summary>
        /// The standard message for the object
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// The HResult
        /// </summary>
        [JsonProperty("hresult")]
        public int HResult { get; set; }

        /// <summary>
        /// The Help Link
        /// </summary>
        [JsonProperty("helpLink")]
        public string HelpLink { get; set; }

        /// <summary>
        /// The Stack Trace
        /// </summary>
        [JsonProperty("stackTrace")]
        public string StackTrace { get; set; }

        /// <summary>
        /// The Source of the Exception
        /// </summary>
        [JsonProperty("source")]
        public string Source { get; set; }

        /// <summary>
        /// A collection of serializable inner exceptions
        /// </summary>
        [JsonProperty("innerExceptions")]
        public List<SerializableException> InnerExceptions
        {
            get { return _innerExceptions = (_innerExceptions ?? new List<SerializableException>()); }
            set { _innerExceptions = value; }
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SerializableException() { }

        /// <summary>
        /// Overloaded constructor that takes in an exception and builds up an object for serialization
        /// </summary>
        /// <param name="ex">The exception</param>
        /// <param name="customMessage">A custom message to include</param>
        public SerializableException(Exception ex, string customMessage = null)
        {
            if (!string.IsNullOrWhiteSpace(customMessage))
            {
                CustomMessage = customMessage;
            }

            Message = ex.Message;
            HResult = ex.HResult;
            HelpLink = ex.HelpLink;
            StackTrace = ex.StackTrace;
            Source = ex.Source;

            if (ex.InnerException != null)
            {
                InnerExceptions.Add(AddInnerException(ex.InnerException));
            }
        }

        /// <summary>
        /// Adds an inner exception to the object
        /// </summary>
        /// <param name="ex">The inner exception</param>
        /// <returns>The inner exception as serializable</returns>
        public SerializableException AddInnerException(Exception ex)
        {
            return new SerializableException(ex);
        }

        /// <summary>
        /// Serializes the entire exception object
        /// </summary>
        /// <returns>Returns a JSON string of the exception's entire hierarchy</returns>
        public string SerializeException()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
