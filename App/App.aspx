<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="App.aspx.cs" Inherits="App.App" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>


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
        return '<div><input name = "DynamicTextBox" type="text" value = "' + value + '" />  &nbsp;' +
            '<label for="DynamicTextBoxFName">Name (First Last) </label> </div>' +
            //'<div><input name = "DynamicTextBoxLName" type="text" value = "' + value + '" />  &nbsp;' +
            //'<label for="DynamicTextBoxLName"> Last Name </label> </div>' +
               '<input type="button" value="Remove" class="remove" />'
    }

</script>

</head>
<body>
 <form id="form1" runat="server">
      
        <div>
            <asp:TextBox ID="txtEmployeeName" runat="server" Width="268px"></asp:TextBox>
            <asp:Label ID="lblEmployeeName" runat="server" Text="Employee Name (First Last)"></asp:Label>
        </div> 
       

          <div>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            <asp:Label ID="lblResult" runat="server" Text="Result"></asp:Label>
        </div>
      
        <div>
            <input id="btnAdd" type="button" value="add" onclick="AddTextBox()" />
        </div>
     <div id="TextBoxContainer">
        <!--Textboxes will be added here -->
    </div>
     </form>
</body>
</html>
