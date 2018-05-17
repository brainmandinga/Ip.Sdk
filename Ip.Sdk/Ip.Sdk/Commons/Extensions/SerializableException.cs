using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Ip.Sdk.Commons.Extensions
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SerializableException
    {
        private List<SerializableException> _innerExceptions;

        [JsonProperty("customMessage")]
        public string CustomMessage { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("hresult")]
        public int HResult { get; set; }

        [JsonProperty("helpLink")]
        public string HelpLink { get; set; }

        [JsonProperty("stackTrace")]
        public string StackTrace { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("innerExceptions")]
        public List<SerializableException> InnerExceptions
        {
            get { return _innerExceptions = (_innerExceptions ?? new List<SerializableException>()); }
            set { _innerExceptions = value; }
        }

        public SerializableException() { }

        public SerializableException(Exception ex, string customMessage = null)
        {
            if (!string.IsNullOrWhiteSpace(customMessage))
                CustomMessage = customMessage;

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

        public SerializableException AddInnerException(Exception ex)
        {
            return new SerializableException(ex);
        }

        public string SerializeException()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
