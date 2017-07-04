using DiagonisticCenterBillManagementSystem.BLL;
using DiagonisticCenterBillManagementSystem.Models;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DiagonisticCenterBillManagementSystem.UI
{
    public partial class TypeReport : System.Web.UI.Page
    {
        TestTypeManager typeManager = new TestTypeManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnShowType_Click(object sender, EventArgs e)
        {
            DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
            DateTime toDate = Convert.ToDateTime(txtToDate.Text);
            List<TypeReports> TypeReport = typeManager.GetReportByTypeName(fromDate, toDate);
            TypeReportGridView.DataSource = TypeReport;
            TypeReportGridView.DataBind();

            decimal sumOfAmount = 0;
            foreach (var type in TypeReport)
            {
                sumOfAmount += type.TotalAmount;
            }
            HiddenField1.Value = sumOfAmount.ToString();
            txtTypeTotal.Text = HiddenField1.Value;

            Clear();
        }

        private void Clear()
        {
            txtFromDate.Text = "";
            txtToDate.Text = "";
        }


        protected void btnPDFShow_Click(object sender, EventArgs e)
        {
            ExportGridToPDF();
        }
        private void ExportGridToPDF()
        {

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            StringBuilder sb = new StringBuilder();
            StringBuilder sb1 = new StringBuilder();
            sb.Append("<table width = '100%' cellspacing='0' cellpadding ='2'>");
            sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>Type Report</b></td></tr></table>");
            sb.Append("</br>");
            TypeReportGridView.RenderControl(hw);
            sb1.Append("<table border = '1'>");
            sb1.Append("<tr><td align = 'right' colspan = '");
            sb1.Append(TypeReportGridView.HeaderRow.Cells.Count - 1);
            sb1.Append("'>Total</td>");
            sb1.Append("<td>");
            sb1.Append(HiddenField1.Value);
            sb1.Append("</td>");
            sb1.Append("</tr></table>");


            StringReader sr2 = new StringReader(sb1.ToString());
            StringReader sr1 = new StringReader(sb.ToString());
            StringReader sr = new StringReader(sw.ToString());

            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr1);
            htmlparser.Parse(sr);
            htmlparser.Parse(sr2);
            pdfDoc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=TestType.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.Flush();

            Response.Clear();
            Response.End();

        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }
    }
}