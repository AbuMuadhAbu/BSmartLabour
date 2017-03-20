<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE html>
<html>
<head >

    <meta name="viewport" content="width=device-width" />
    <title>ReportViwer in MVC4 Application</title>    
    <script >
        void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<SmartLabours.Models.Labour> customers = null;
                using (SmartLabours.Models.SmartLabourEntities  dc = new SmartLabours.Models.SmartLabourEntities())
                {
                    string mimeType;
                    string encoding;
                    Warning[] warnings;
                    string[] streams;
                    //byte[] renderedBytes;
                    string extension;
                    customers = dc.Labours.OrderBy(a => a.LabourID).ToList();
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/CourseStarted.rdlc");
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportDataSource rdc = new ReportDataSource("CourseStartedReport", customers);
                    ReportViewer1.LocalReport.DataSources.Add(rdc);
                  //  ReportViewer viewer = new ReportViewer();
                 //   ReportViewer1.ProcessingMode = ProcessingMode.Local;
                 //   ReportViewer1.LocalReport.ReportPath = "YourReportHere.rdlc";


                    byte[] bytes = ReportViewer1.LocalReport.Render("PDF",null, out mimeType, out encoding, out extension, out streams, out warnings);


                    // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
                    Response.Buffer = true;
                    Response.Clear();
                    Response.ContentType = mimeType;
                    Response.AddHeader("content-disposition", "attachment; filename=" + "DFGH" + "." + extension);
                    Response.BinaryWrite(bytes); // create the file
                    Response.Flush();             
                   // ReportViewer1.LocalReport.Refresh();
                }
            }
        }
    </script>

</head>
<body>
    <form id="form2" >
    <div>
        <asp:ScriptManager ID="ScriptManager1" ></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1"  AsyncRendering="false" SizeToReportContent="true">
        </rsweb:ReportViewer>        
    </div>
    </form>
</body>
</html>