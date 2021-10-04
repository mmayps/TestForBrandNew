<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Transfer.aspx.cs" Inherits="TestForBrandNew.Transfer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Transfer</title>
    <script src="http://code.jquery.com/jquery-2.1.3.js"></script>
	<script src="http://code.jquery.com/ui/1.11.2/jquery-ui.js"></script>
    <script type="text/javascript">
        $(document).ready(function ()
        {
            $('#btnSave').click(function ()
            {
                var errV = '';
                if ($('#txtamount').val() == '') errV = 'please input amount \n';
                if ($('#ddlAcc').val() == '0') errV += 'please select Origianl account \n';
                if ($('#ddlTansfer').val() == '0') errV += 'please select Transfer account \n';
                if (errV != '') {
                    alert(errV);
                    return false;
                }
                else
                {
                    if ($('#ddlAcc').val() == $('#ddlTansfer').val())
                    {
                        alert('Account must not same!!');
                        return false;
                    }
                    else
                    {
                        var myval = []

                        myval.push($('#ddlAcc').val());
                        myval.push($('#ddlTansfer').val());
                        myval.push($('#txtamount').val());                      

                        PageMethods.Save(myval, onsub);
                    }
                }
            });
        });

        function onsub(a) {
            var msg = a;
            alert(msg);
            clearValue();
        }
        function clearValue()
        {
            $('#ddlAcc').val('');
            $('#txtamount').val('');
            $('#ddlTansfer').val('');        
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">

        </asp:ScriptManager>
        <div >
            <fieldset>
                <legend>Transfer Form</legend>
                <table>
                    <tr>
                        <td>
                            <label>Original Acccount</label>
                           <%-- <input id="txtOrgAcc" type="text" />--%>
                            <asp:DropDownList ID="ddlAcc" runat="server" Width="180px" OnSelectedIndexChanged="ddlAcc_SelectedIndexChanged"></asp:DropDownList>
                            <label id="lblorgacc" style="display:none"  />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>Transfer Acccount</label>
                            <%--<input id="txtToAcc" type="text" />--%>
                            <asp:DropDownList ID="ddlTansfer" runat="server" Width="180px"></asp:DropDownList>
                            <label id="lbltoacc" style="display:none"  />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label>Amount</label>
                            <input id="txtamount" type="number" min="0" />
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
