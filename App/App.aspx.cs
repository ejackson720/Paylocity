using System;
using System.Web.Script.Serialization;
using App.Endpoints;

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
            //Get the Employee Name

            //Get the Dependent Names
            string[] dependentNames = Request.Form.GetValues("DynamicTextBox");

            //Call the endpoint with allthese things
            var result =  _endpoint.SubmitToApi().Result;
            lblResult.Text = result;
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