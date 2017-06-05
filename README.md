# ClosedXML.Extensions.AspNet
ASP.NET Extensions for ClosedXML

## Usage
There are two extension methods: one for `HttpResponse` and one for `XLWorkbook`. Both deliver the relevant `ClosedXML` workbook to the response stream.

```c#

using (var wb = GenerateClosedXMLWorkbook())
{
    var response = this.Response;
    response.DeliverWorkbook(wb, "generatedFile.xlsx");
    
    // or specify the content type:
    response.DeliverWorkbook(wb, "generatedFile.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
}
```

or

```c#
using (var wb = GenerateClosedXMLWorkbook())
{
    wb.DeliverToHttpResponse(this.Response, "generatedFile.xlsx");
    
    // or specify the content type:
    wb.DeliverToHttpResponse(this.Response, "generatedFile.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
}
```
