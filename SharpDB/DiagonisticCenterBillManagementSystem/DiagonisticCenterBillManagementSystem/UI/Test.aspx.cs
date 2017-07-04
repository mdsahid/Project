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
    public partial class Test : System.Web.UI.Page
    {
        TestTypeManager typeManager = new TestTypeManager();
        TestManager testManager = new TestManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowType();
            }
            ShowTest();
        }



        protected void btnTestSave_Click(object sender, EventArgs e)
        {


            string name = txtTestName.Text;
            int typeId = Convert.ToInt32(ddlTestType.SelectedItem.Value);
            decimal Number;
            bool IsExistsNumber = decimal.TryParse(txtTestFee.Text, out Number);

            if (IsExistsNumber)
            {

                if (Number >= 0)
                {

                    decimal testFee = Number;

                    Tests test = new Tests(name, testFee, typeId);
                    try
                    {

                        int rowAffected = testManager.AddTest(test);

                        if (rowAffected > 0)
                        {
                            lblMessage.Text = "Data saved";
                            lblMessage.ForeColor = System.Drawing.Color.Green;
                            ShowTest();
                        }

                    }
                    catch (Exception exception)
                    {

                        lblMessage.Text = exception.Message;
                        lblMessage.ForeColor = System.Drawing.Color.Red;

                    }
                }
                else
                {

                    lblMessage.Text = "Fee cannot be negative ";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }

            }
            else
            {

                lblMessage.Text = "Fee must be numeric";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }

            Clear();

        }







        public void ShowTest()
        {
            GridViewTest.DataSource = testManager.GetAllTestWithType().OrderBy(x => x.Test);

            GridViewTest.DataBind();
        }
        public void ShowType()
        {
            List<Types> type = typeManager.GetAllTestType().ToList();

            ddlTestType.DataTextField = "typeName";
            ddlTestType.DataValueField = "ID";
            ddlTestType.DataSource = type;
            ddlTestType.DataBind();

            ddlTestType.Items.Insert(0, "--Select Type--");



        }

        private void Clear()
        {
            txtTestFee.Text = string.Empty;
            txtTestName.Text = string.Empty;
            ddlTestType.SelectedIndex = 0;
        }




    }
}