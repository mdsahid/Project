using DiagonisticCenterBillManagementSystem.BLL;
using DiagonisticCenterBillManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DiagonisticCenterBillManagementSystem.UI
{
    public partial class Payment : System.Web.UI.Page
    {
        PatientManager patientManager = new PatientManager();
        PatientTestRequestManager testRequest = new PatientTestRequestManager();
        TestManager testManager = new TestManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ShowPayment();
        }

        protected void paySave_Click(object sender, EventArgs e)
        {

            if (txtAmount.Text != "" && txtAmount.Text != null)
            {
                Patients patient = new Patients();
                patient.BillNo = HiddenFieldBillNo.Value;
                decimal Amount;
                bool IsExistsAmount = decimal.TryParse(txtAmount.Text, out Amount);
                if (IsExistsAmount)
                {
                    if (Amount >= 0)
                    {
                        lblPaymentMsg.Visible = false;
                        patient.PaidBill = Amount;
                        patientManager.GetPatientUpdate(patient);
                        lblPaid.Text = patientManager.GetPatientUpdateBill(patient.BillNo, Convert.ToDecimal(patient.PaidBill));
                        lblDue.Text = patientManager.GetPatientDueBill(patient.BillNo, Convert.ToDecimal(patient.PaidBill));

                    }
                    else
                    {
                        lblPaymentMsg.Visible = true;
                        lblPaymentMsg.Text = "Amount cannot be negative";
                        lblPaymentMsg.ForeColor = System.Drawing.Color.Red;
                    }

                }
                else
                {
                    lblPaymentMsg.Visible = true;
                    lblPaymentMsg.Text = "Amount must be numeric";
                    lblPaymentMsg.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblPaymentMsg.Visible = true;
                lblPaymentMsg.Text = "Amount is required";
                lblPaymentMsg.ForeColor = System.Drawing.Color.Red;
            }

            txtAmount.Text = "";
        }

        public void ShowPayment()
        {
            try
            {
                lblBillMessage.Visible = false;
                List<Payments> PatientdetailsList = patientManager.GetPatientDetails(txtBillNoSearch.Text);
                PaymentGridView.DataSource = PatientdetailsList.ToList();
                PaymentGridView.DataBind();

                foreach (var item in PatientdetailsList)
                {
                    HiddenFieldBillNo.Value = item.BillNo.ToString();
                    lblBillDate.Text = item.BillDate.ToString();
                    lblTotalFee.Text = item.TotalFee.ToString();
                    lblPaid.Text = item.PaidBill.ToString();
                    lblDue.Text = (item.TotalFee - item.PaidBill).ToString();
                }
            }
            catch (Exception ex)
            {
                lblBillMessage.Visible = true;
                lblBillMessage.Text = ex.Message;
                lblBillMessage.ForeColor = System.Drawing.Color.Red;
            }





        }




    }
}