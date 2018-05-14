using ClosedXML.Excel;
using System.IO;

#if _NETFRAMEWORK_
using System.Web;
#else
using Microsoft.AspNetCore.Http;
#endif


namespace ClosedXML.Extensions
{
    public static class ResponseExtensions
    {
        public static void DeliverWorkbook(this HttpResponse httpResponse, XLWorkbook workbook, string fileName, string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
        {
            httpResponse.Clear();
            httpResponse.ContentType = contentType;
            httpResponse.AddHeader("content-disposition", $"attachment;filename=\"{fileName}\"");

            // Flush the workbook to the Response.OutputStream
            using (var memoryStream = new MemoryStream())
            {
                workbook.SaveAs(memoryStream);
                memoryStream.WriteTo(httpResponse.BodyStream());
                memoryStream.Close();
            }

            httpResponse.End();
        }
    }


    public static class XLWorkbookExtensions
    {
        public static void DeliverToHttpResponse(this XLWorkbook workbook, HttpResponse httpResponse, string fileName, string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
        {
            httpResponse.Clear();
            httpResponse.ContentType = contentType;
            httpResponse.AddHeader("content-disposition", $"attachment;filename=\"{fileName}\"");

            // Flush the workbook to the Response.OutputStream
            using (var memoryStream = new MemoryStream())
            {
                workbook.SaveAs(memoryStream);
                memoryStream.WriteTo(httpResponse.BodyStream());
                memoryStream.Close();
            }

            httpResponse.End();
        }
    }
}
