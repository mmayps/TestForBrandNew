<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addAccount.aspx.cs" Inherits="TestForBrandNew.addAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Account</title>
     <script src="http://code.jquery.com/jquery-2.1.3.js"></script>
	 <script src="http://code.jquery.com/ui/1.11.2/jquery-ui.js"></script>

      <script type="text/javascript">
          $(document).ready(function ()
          {
              $('#btnSave').click(function ()
              {
                  var errV = '';
                  if ($('#txtFirstname').val() == '') errV = 'please input first name \n';
                  if ($('#txtlastname').val() == '') errV += 'please input last name \n';
                  if ($('#txtphone').val() == '') errV += 'please input phone \n';
                  if ($('#txtage').val() == '') errV += 'please input age\n';
                  if ($('#txtAddress').val() == '') errV += 'please input address \n';
                  if ($('#txtfirstamount').val() == '') errV += 'please input amount ';
                  if ($('#ddl').val() == '0') errV += 'please select gender ';

                  if (errV != '') {
                      alert(errV);
                      return false;
                  }
                  else
                  {
                      var myval = []

                      myval.push($('#txtibn').val());
                      myval.push($('#txtFirstname').val());
                      myval.push($('#txtlastname').val());
                      myval.push($('#txtphone').val());
                      myval.push($('#ddl').val());
                      myval.push($('#txtage').val());
                      myval.push($('#txtAddress').val());
                      myval.push($('#txtfirstamount').val());

                      PageMethods.Save(myval, onSub);
                  }
              });

              $('#btncancel').click(function ()
              {
                  window.location.href = "default.aspx";
              });

              $('#btnIBN').click(function () {
                  
              });
          });

          function onSub(a)
          {
              var msg = a;
              alert(msg);
              clearValue();
          }

          function clearValue() {
              $('#ddl').val('');
              $('#txtibn').val('');
              $('#txtFirstname').val('');
              $('#txtlastname').val('')
              $('#txtphone').val('')
              $('#txtage').val('')
              $('#txtAddress').val('')
              $('#txtfirstamount').val('')
          }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">

        </asp:ScriptManager>
        <div>
        <fieldset>
            <legend>Registration Form</legend>
            <table>
                <tr>
                    <td>
                        <label >IBN : </label>
                        <asp:TextBox runat="server" id="txtibn" Enabled="true"/>
                        <button id="btnIBN" >Generate IBN</button>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label >First Name : </label>
                        <input type="text" id="txtFirstname" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label >Last Name : </label>
                        <input type="text"  id="txtlastname" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Phone : </label>
                        <input type="text" id="txtphone"  />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Gender : </label>
                        <asp:DropDownList ID="ddl" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                       <label>Age : </label>
                        <input type="number" id="txtage" min="0"  />
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Address :</label>
                        <input type="text"  id="txtAddress" />        
                    </td>                         
                </tr>
                <tr>
                    <td>
                        <label>First amout :</label>
                        <input type="number"  id="txtfirstamount" min="0.00" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <button id="btnSave" >save</button>
                        <asp:Button id="btncancel" runat="server" Text="cancel" OnClick="btncancel_Click" />
                    </td>
                </tr>
            </table>      
      
        </fieldset>
     </div>      
    </form>
</body>
</html>
