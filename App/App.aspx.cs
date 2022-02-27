using System;
using System.Web.Script.Serialization;
using App.Endpoints;
using App.Models;

namespace App
{
    public partial class App : System.Web.UI.Page
    {
        Endpoint _endpoint = new Endpoint();
        protected string Values;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            EmployeeDependents employeeDependents = new EmployeeDependents();
            //Get the Employee Name
            employeeDependents.EmployeeName = txtEmployeeName.Text;


            //Get the Dependent Names
            string[] dependentNames = Request.Form.GetValues("DynamicTextBox");
            if (dependentNames != null && dependentNames.Length > 0)
            {
                foreach (var dependent in dependentNames)
                {
                    employeeDependents.Dependents.Add(dependent);
                }
            }          

            //Call the endpoint with allthese things
            var result =  _endpoint.CalculateBenefits(employeeDependents).Result;
            lblResults.Text = result;
        }
        protected void Post(object sender, EventArgs e)
        {
            string[] textboxValues = Request.Form.GetValues("DynamicTextBox");
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            this.Values = serializer.Serialize(textboxValues);
            string message = "";
            foreach (string textboxValue in textboxValues)
            {
                message += textboxValue + "\\n";
            }
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + message + "');", true);

        }
    }
}