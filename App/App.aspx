<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="App.aspx.cs" Inherits="App.App" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Paylocity</title>


<script type="text/javascript" src="/Scripts/jquery-3.4.1.min.js"></script>
<script type="text/javascript">

    $(function () {
        var values = eval('<%=Values%>');
           if (values != null) {
               var html = "";
               $(values).each(function () {
                   var div = $("<div />");
                   div.html(GetDynamicTextBox(this));
                   $("#TextBoxContainer").append(div);
               });
           }
           $("#btnAdd").bind("click", function () {
               var div = $("<div />");
               div.html(GetDynamicTextBox(""));
               $("#TextBoxContainer").append(div);
           });
           $("body").on("click", ".remove", function () {
               $(this).closest("div").remove();
           });
       });
    function GetDynamicTextBox(value) {
        return '<div><label for="DynamicTextBoxFName">Name (First Last) </label> <input name = "DynamicTextBox" type="text" value = "' + value + '" />  &nbsp;' +
                    
               '<input type="button" value="Remove" class="remove" />  </div>'
    }

</script>

</head>
<body>
 <form id="form1" runat="server">
      
    <div>
        <div>
        <asp:Label ID="lblEmployeeName" runat="server" Text="Employee Name (First Last)"></asp:Label>
        </div>
        <div>
        <asp:TextBox ID="txtEmployeeName" runat="server" Width="268px"></asp:TextBox>        
        </div>
    </div> 
       
    <p></p>
    <div>
        <input id="btnAdd" type="button" value="Add Dependent" onclick="AddTextBox()" />
    </div>
    <p></p>
    <div id="TextBoxContainer">      
    </div>
   <p></p>
   <div>
        <asp:Button ID="btnSubmit" runat="server" Text="Calculate" OnClick="btnSubmit_Click" />        
   </div>
     <div>
         <asp:Label ID="lblResults" runat="server" Text=""></asp:Label>
     </div>
    </form>
</body>
</html>
