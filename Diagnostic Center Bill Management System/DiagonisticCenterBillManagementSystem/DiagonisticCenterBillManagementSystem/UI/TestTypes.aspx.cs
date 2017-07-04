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
    public partial class TestTypes : System.Web.UI.Page
    {
        TestTypeManager typeManager = new TestTypeManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowAllType();
            }



        }

        protected void btnTypeSave_Click(object sender, EventArgs e)
        {
            string name = txtTypeName.Text;

            Types type = new Types(name);
            try
            {

                int rowAffected = typeManager.AddType(type);

                if (rowAffected > 0)
                {
                    lblMessage.Text = "Data Saved";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    ShowAllType();
                }


            }
            catch (Exception exception)
            {

                lblMessage.Text = exception.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            Clear();
        }

        private void Clear()
        {
            txtTypeName.Text = string.Empty;
        }
        private void ShowAllType()
        {
            List<Types> typeList = typeManager.GetAllTestType();
            testTypeGridView.DataSource = typeList.OrderBy(x => x.TypeName);
            testTypeGridView.DataBind();
        }
    }
}

        