using System.IO;

#if _NETFRAMEWORK_
using System.Web;
#else
using Microsoft.AspNetCore.Http;
#endif

namespace ClosedXML.Extensions
{
    internal static class HttpExtensions
    {

#if !_NETFRAMEWORK_
        public static void AddHeader(this HttpResponse httpResponse, string key, string value)
        {
            httpResponse.Headers.Add(key, value);
        }

        public static void End(this HttpResponse httpResponse)
        {
            // Nothing
        }
#endif

        public static Stream BodyStream(this HttpResponse httpResponse)
        {
#if _NETFRAMEWORK_
            return httpResponse.OutputStream;
#else
            return httpResponse.Body;
#endif
        }
    }
}