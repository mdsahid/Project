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
    public partial class Patient : System.Web.UI.Page
    {
        PatientManager patientManager = new PatientManager();
        TestManager testManager = new TestManager();
        PatientTestRequestManager TestRequestManager = new PatientTestRequestManager();
        List<Tests> testList = new List<Tests>();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ShowTest();
            }
        }

        protected void Page_Render(object sender, EventArgs e)
        {


        }

        protected void btnTestRequst_Click(object sender, EventArgs e)
        {

            testList = (List<Tests>)ViewState["Test"];

            string name = txtPatientName.Text;
            DateTime dateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text);
            int mobileNo = Convert.ToInt32(txtMobileNo.Text);
            HiddenField1.Value = patientManager.Get8Digits();
            string billNo = HiddenField1.Value;
            DateTime billDate = System.DateTime.Now;
            decimal totalFee = testList.Sum(x => x.testFee);
            decimal PaidBill = 0;

            Patients patient = new Patients(name, dateOfBirth, mobileNo, billNo, billDate, totalFee, PaidBill);

            try
            {

                patientManager.AddPatient(patient);


            }
            catch (Exception exception)
            {
                lblMessage.Visible = true;
                lblMessage.Text = exception.Message;

            }
            int PatientId = patientManager.GetAllPatient().Max(x => x.ID);
            foreach (var test in testList)
            {
                int patientID = PatientId;
                int testID = test.ID;
                PatientTestRequest testRequest = new PatientTestRequest(patientID, testID);
                TestRequestManager.AddTestRequest(testRequest);

            }
            Clear();
            Generate_PDF();
            


        }

        protected void btnTestAdd_Click(object sender, EventArgs e)
        {
            AddToGrid();
        }

        public void ShowTest()
        {
            var test = testManager.GetAllTest();
            ddlTestName.DataTextField = "tName";
            ddlTestName.DataValueField = "ID";
            ddlTestName.DataSource = test;
            ddlTestName.DataBind();
            ddlTestName.Items.Insert(0, "--Select Test--");
        }



        protected void ddlTestName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTestName.SelectedIndex == 0)
            {
                txtFeeOfTest.Text = "";

            }
            else
            {
                var Value = Convert.ToInt32(ddlTestName.SelectedValue);
                decimal testFee = testManager.GetAllTest().SingleOrDefault(x => x.ID == Value).testFee;
                txtFeeOfTest.Text = testFee.ToString();
            }
        }

        public void AddToGrid()
        {

            if (ViewState["Test"] != null)
            {
                testList = (List<Tests>)ViewState["Test"];
            }
            Tests testReq = new Tests();
            testReq.tName = ddlTestName.SelectedItem.Text;
            testReq.ID = Convert.ToInt32(ddlTestName.SelectedValue);
            testReq.testFee = Convert.ToDecimal(txtFeeOfTest.Text);

            testList.Add(testReq);
            decimal total = 0;
            total = testList.Sum(x => x.testFee);
            txtTotalTestAmount.Text = total.ToString();
            ViewState["Test"] = testList;
            GridOfTestRequest.DataSource = testList;
            GridOfTestRequest.DataBind();
        }


        private void Generate_PDF()
        {

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            StringBuilder sb = new StringBuilder();
            StringBuilder sb1 = new StringBuilder();

            //Generate Invoice (Bill) Header.
            sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
            sb.Append("<tr><td align='center' style='background-color:blue colspan = '2'><b>Bill Report</b></td></tr>");
            sb.Append("<tr><td colspan = '2'></td></tr>");
            sb.Append("<tr><td><b>Bill No: </b>");
            sb.Append(HiddenField1.Value);
            sb.Append("</td><td align = 'right'><b>Date: </b>");
            sb.Append(DateTime.Now);
            sb.Append(" </td></tr>");
            sb.Append("</table>");
            sb.Append("<br />");


            GridOfTestRequest.RenderControl(hw);

            StringReader sr = new StringReader(sw.ToString());
            StringReader sr1 = new StringReader(sb.ToString());
            sb1.Append("<table border='1'>");
            sb1.Append("<tr><td align = 'right' colspan = '");
            sb1.Append(GridOfTestRequest.HeaderRow.Cells.Count - 1);
            sb1.Append("'>Total</td>");
            sb1.Append("<td>");
            sb1.Append(testList.Sum(x => x.testFee));
            sb1.Append("</td>");
            sb1.Append("</tr></table>");


            StringReader sr2 = new StringReader(sb1.ToString());


            Document pdfDoc = new Document(PageSize.A5, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);

            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr1);
            htmlparser.Parse(sr);

            htmlparser.Parse(sr2);

            pdfDoc.Close();

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Sharp.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            Response.Write(pdfDoc);

            Response.Flush();
            HttpContext.Current.ApplicationInstance.CompleteRequest();




        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        public void Clear()
        {
            txtPatientName.Text = "";
            txtMobileNo.Text = "";
            txtDateOfBirth.Text = "";
            txtFeeOfTest.Text = "";
            txtTotalTestAmount.Text = "";
            ddlTestName.SelectedIndex = 0;
            GridOfTestRequest.DataSource = null;
            GridOfTestRequest.DataBind();
            //testList.Clear();
            ViewState["Test"] = null;

        }

       

    }
}